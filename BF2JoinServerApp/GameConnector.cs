using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

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

        public void LaunchGame(string path, string workingDirectory)
        {

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = path,
                WorkingDirectory = workingDirectory,
                Arguments = "+modPath mods/bf2all64",
                UseShellExecute = false
            };
            
            Process.Start(startInfo);
        }
    }
}
