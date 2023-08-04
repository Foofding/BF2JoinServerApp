﻿using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace BF2JoinServerApp
{
    class GameConnectorService
    {
        public void HostGame()
        {
            int port = 12345;
            TcpListener server = new TcpListener(IPAddress.Any, port);
            server.Start();
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