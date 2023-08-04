using BF2JoinServerApp.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace BF2JoinServerApp.Data
{
    public class ProfileRepository
    {
        private Dictionary<string, Profile> _profileFiles; // Declare the dictionary variable
        private List<Profile> _profiles;
        private string _profilesDirectory;

        public ProfileRepository()
        {
            _profileFiles = new Dictionary<string, Profile>();
            _profiles = new List<Profile>();
            GetProfilesDirectory();
            LoadProfiles();
        }

        public void CreateProfile(Profile profile)
        {
        }

        public void DeleteProfile(Profile profile)
        {
        }

        public void RenameProfile(Profile profile)
        {
        }

        public void ChangeProfile(string profileName)
        {
        }

        public List<Profile>? LoadProfiles()
        {
            if (!Directory.Exists(_profilesDirectory))
            {
                throw new DirectoryNotFoundException("Profiles directory does not exist.");
            }

            string[] profileFolders = Directory.GetDirectories(_profilesDirectory);

            foreach (string profileFolder in profileFolders)
            {
                string folderName = new DirectoryInfo(profileFolder).Name;
                string profileConFile = Path.Combine(profileFolder, "Profile.con");
                if (File.Exists(profileConFile))
                {
                    Profile profile = ReadProfileFromConFile(profileConFile);
                    _profiles.Add(profile);
                    _profileFiles.Add(folderName, profile); // Add to the dictionary using the folder name as the key.
                }
            }

            return _profiles;
        }

        private Profile ReadProfileFromConFile(string conFilePath)
        {
            string[] conFileLines = File.ReadAllLines(conFilePath);

            string name = null;
            string nick = null;
            int totalPlayedTime = 0;
            int numTimesLoggedIn = 0;

            foreach (string line in conFileLines)
            {
                if (line.StartsWith("LocalProfile.setName"))
                {
                    name = line.Split('"')[1];
                }
                else if (line.StartsWith("LocalProfile.setNick"))
                {
                    nick = line.Split('"')[1];
                }
                else if (line.StartsWith("LocalProfile.setTotalPlayedTime"))
                {
                    int.TryParse(line.Split(' ')[1], out totalPlayedTime);
                }
                else if (line.StartsWith("LocalProfile.setNumTimesLoggedIn"))
                {
                    int.TryParse(line.Split(' ')[1], out numTimesLoggedIn);
                }
            }

            return new Profile(name, nick, totalPlayedTime, numTimesLoggedIn);
        }

        private void GetProfilesDirectory()
        {
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string remainingPath = "Battlefield 2\\Profiles";
            _profilesDirectory = Path.Combine(documentsFolder, remainingPath);
        }
    }
}