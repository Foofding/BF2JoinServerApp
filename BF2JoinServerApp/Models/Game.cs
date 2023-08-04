using BF2JoinServerApp.Models;
using BF2JoinServerApp.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace BF2JoinServerApp
{
    public class Game
    {
        public bool Exists { get; set; } = false;
        public string DirectoryPath { get; set; } = "C:\\Program Files (x86)\\EA Games\\Battlefield 2";
        public string ExecutablePath { get; set; } = "C:\\Program Files (x86)\\EA Games\\Battlefield 2\\BF2.exe";

        private ProfileService _profileService;

        public Game()
        {
            CheckInstallation();
        }

        private bool CheckInstallation()
        {
            if (Directory.Exists(DirectoryPath))
            {
                if (File.Exists(ExecutablePath))
                {
                    Exists = true;
                }
                else
                {
                    throw new Exception("BF2.exe not found!");
                }
            }
            else
            {
                throw new Exception("Game directory not found!");
            }

            return Exists;
        }

        public List<Profile> GetTestProfiles()
        {
            return new List<Profile>
            {
                new Profile("JoeBiden", 120),
                new Profile("BiggoNiggo", 120),
                new Profile("WonkasFirstChoice", 120),
                new Profile("ButtholeSurfer", 120),
                new Profile("Shed5", 120),
                new Profile("Shed6", 120),
                new Profile("Shed7", 120),
                new Profile("Shed8", 120),
                new Profile("Shed9", 120),
                new Profile("Shed9", 120),
                new Profile("Shed9", 120),
            };
        }
    }
}
