using System;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Transactions;

namespace BF2JoinServerApp
{
    class GameConnectorService
    {
        private int _port = 12345;
        public string HostIP { get; set; }
        public void HostGame()        {
            
            TcpListener server = new TcpListener(IPAddress.Any, _port);
            server.Start();
        }

        public string JoinGame()
        {
            // Get the host name of the local machine


            string hostName = Dns.GetHostName();
            Console.WriteLine(hostName);

            // Get the IP from GetHostByName method of dns class.
            string ipAddress = Dns.GetHostEntry(hostName).ToString();
            string subnet = ipAddress.Substring(0, ipAddress.LastIndexOf('.')+ 1);
            Console.WriteLine(subnet);

            for (int i = 2; i <= 255; i++) // Scanning IPs from 192.168.0.1 to 192.168.0.255
            {
                
               
                try
                {
                    TcpClient client = new TcpClient();
                    client.Connect(ipAddress, _port);
                    if (client.Connected)
                    {
                        return ipAddress;
                    }                    
                }
                catch (SocketException)
                {
                    // The port is not open on this host
                }
            }
            return null;

        }

        //"+modPath mods/bf2all64"
        public void LaunchGame(string path, string workingDirectory, string? args = null)
        {
            try
            {
                if (String.IsNullOrEmpty(args))
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
                        Arguments = args,
                        UseShellExecute = false
                    };
                    Process.Start(startInfo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
