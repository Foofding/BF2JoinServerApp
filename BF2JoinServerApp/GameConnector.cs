using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BF2JoinServerApp
{
    class GameConnector
    {
        public void HostGame()
        {
            int port = 12345;
            TcpListener server = new TcpListener(IPAddress.Any, port);
            server.Start();            
        }

        public void LaunchGame(string path)
        {
            try
            {
                Process.Start(path, "+modPath mods/bf2all64");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
