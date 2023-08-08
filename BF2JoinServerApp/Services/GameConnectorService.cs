using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Controls;

namespace BF2JoinServerApp
{
    class GameConnectorService
    {
        private int _port = 55551;
        public string HostIP { get; set; }
        private ManualResetEvent hostFoundEvent = new ManualResetEvent(false);
        private const int MaxThreads = 50;


        public void HostGame()
        {
            string hostIP = "";
            foreach (NetworkInterface netwIntrf in NetworkInterface.GetAllNetworkInterfaces())
            {
                //if interface is not Up and running OR it is a Loopback address, then skip to next net interface
                if (netwIntrf.OperationalStatus != OperationalStatus.Up || netwIntrf.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                    continue;

                //get current IP Address(es)
                foreach (UnicastIPAddressInformation uniIpInfo in netwIntrf.GetIPProperties().UnicastAddresses)
                {
                    //if Address Family is IPv6: skip
                    if (uniIpInfo.Address.AddressFamily == AddressFamily.InterNetworkV6)
                        continue;

                    hostIP = uniIpInfo.Address.ToString();
                }
            }

            TcpListener server = new TcpListener(IPAddress.Parse(hostIP), _port);
            server.Start();
            while (true)
            {
                using TcpClient client = server.AcceptTcpClient();
            }
        }

        public bool GetHostIP()
        {
            foreach (NetworkInterface netwIntrf in NetworkInterface.GetAllNetworkInterfaces())
            {
                //if interface is not Up and running OR it is a Loopback address, then skip to next net interface
                if (netwIntrf.OperationalStatus != OperationalStatus.Up || netwIntrf.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                    continue;

                //get current IP Address(es)
                foreach (UnicastIPAddressInformation uniIpInfo in netwIntrf.GetIPProperties().UnicastAddresses)
                {
                    //if Address Family is IPv6: skip
                    if (uniIpInfo.Address.AddressFamily == AddressFamily.InterNetworkV6)
                        continue;

                    //get the subnet mask and the IP address as bytes
                    byte[] subnetMask = uniIpInfo.IPv4Mask.GetAddressBytes();
                    byte[] ipAddr = uniIpInfo.Address.GetAddressBytes();

                    // we reverse the byte-array if we are dealing with littl endian.
                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(subnetMask);
                        Array.Reverse(ipAddr);
                    }

                    //we convert the subnet mask as uint (just for didactic purposes (to check everything is ok now and next - use thecalculator in programmer mode)
                    uint maskAsInt = BitConverter.ToUInt32(subnetMask, 0);

                    //we convert the ip addres as uint (just for didactic purposes (to check everything is ok now and next - use thecalculator in programmer mode)
                    uint ipAsInt = BitConverter.ToUInt32(ipAddr, 0);

                    //we negate the subnet to determine the maximum number of host possible in this subnet
                    uint validHostsEndingMax = ~BitConverter.ToUInt32(subnetMask, 0);

                    //we convert the start of the ip addres as uint (the part that is fixed wrt the subnet mask - from here we calculate each new address by incrementing with 1 and converting to byte[] afterwards 
                    uint validHostsStart = BitConverter.ToUInt32(ipAddr, 0) & BitConverter.ToUInt32(subnetMask, 0);

                    var poolSize = (validHostsEndingMax - 1) / MaxThreads + 1;
                    var blockSize = 0;
                    var addressBlock = new List<IPAddress>();
                    var blocks = new List<IPAddress>[MaxThreads];
                    blocks[0] = new List<IPAddress>();
                    int threadIndex = 0;

                    //starting at 2 because .1 will most always be gateway address and not the Host address we are looking for.
                    for (uint i = 2; i <= validHostsEndingMax; i++)
                    {

                        if (blockSize >= poolSize)
                        {
                            Thread worker = new Thread(new ParameterizedThreadStart(ProcessAddressBlock));
                            worker.Start(blocks[threadIndex]);
                            threadIndex++;
                            blocks[threadIndex] = new List<IPAddress>();
                            blockSize = 0;
                        }

                        uint host = validHostsStart + i;
                        //byte[] hostAsBytes = BitConverter.GetBytes(host);
                        byte[] hostBytes = BitConverter.GetBytes(host);
                        if (BitConverter.IsLittleEndian)
                        {
                            Array.Reverse(hostBytes);
                        }

                        //this is the candidate IP address in "readable format" 
                        String ipCandidate = Convert.ToString(hostBytes[0]) + "." + Convert.ToString(hostBytes[1]) + "." + Convert.ToString(hostBytes[2]) + "." + Convert.ToString(hostBytes[3]);
                        // Debug.WriteLine("Trying: " + ipCandidate);   

                        string targetIP = ipCandidate;
                        blocks[threadIndex].Add(IPAddress.Parse(targetIP));
                        blockSize++;
                    }

                    if (blockSize > 0 && addressBlock.Count > 0)
                    {
                        Task.Run(() => ProcessAddressBlock(addressBlock.ToArray().ToList()));
                        addressBlock = new List<IPAddress>();
                        blockSize = 0;
                    }
                    if (hostFoundEvent.WaitOne(5000) == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void SignalFoundHost(string address)
        {
            lock (this)
            {
                hostFoundEvent.Set();
                HostIP = address;
            }
        }

        public void ProcessAddressBlock(object addresses)
        {

            Debug.WriteLine("Starting new Workerthread");
            foreach (IPAddress address in (List<IPAddress>)addresses)
            {
                if (hostFoundEvent.WaitOne(TimeSpan.FromMilliseconds(1)) == true) break;
                using TcpClient client = new TcpClient();
                try
                {

                    Debug.WriteLine("Trying: " + address.ToString());

                    var result = client.BeginConnect(address, _port, null, null);
                    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(100), false);

                    if (success)
                    {
                        Debug.WriteLine($"Port {_port} is open on {address}");
                        SignalFoundHost(address.ToString());
                        client.EndConnect(result);
                        break;
                    }

                }
                catch (SocketException sex)
                {
                    // The port is not open on this host
                    Debug.WriteLine(sex);
                }
                finally
                {
                    if (client != null)
                        client.Close();
                }
            }

        }

        //"+modPath mods/bf2all64"
        public void LaunchGame(string path, string workingDirectory, List<string>? args = null)
        {
            try
            {
                if (args.Count < 1)
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = path,
                        WorkingDirectory = workingDirectory,
                        UseShellExecute = false
                    };
                    Process.Start(startInfo);
                }
                else
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = path,
                        WorkingDirectory = workingDirectory,
                        Arguments = string.Join(" ", args),
                        UseShellExecute = false
                    };
                    Process.Start(startInfo);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
