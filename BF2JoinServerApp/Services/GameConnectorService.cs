using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;


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
            for (int i = 1; i <= 255; i++) // Scanning IPs from 192.168.1.1 to 192.168.1.255
            {
                string ipAddress = $"192.168.1.{i}";

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
