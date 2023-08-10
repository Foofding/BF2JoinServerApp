using BF2JoinServerApp.Models;
using BF2JoinServerApp.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Diagnostics;

namespace BF2JoinServerApp.Data
{
    public class ProfileRepository
    {
        private ProfileFileFactory _profileFileFactory;
        private Dictionary<string, Profile> _foldersAndProfiles;
        private string _profilesDirectoryPath;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProfileRepository(ProfileFileFactory profileFileFactory)
        {
            _profileFileFactory = profileFileFactory;
            _foldersAndProfiles = new Dictionary<string, Profile>();
            GetProfilesDirectory();
            LoadProfiles();
        }

        /// <summary>
        /// Gets and returns _profilesFiles dict 
        /// </summary>
        /// <returns>Dictionary of profiles</returns>
        public Dictionary<string, Profile> GetFoldersAndProfiles()
        {
            return _foldersAndProfiles;
        }

        /// <summary>
        /// Takes in targetProfileFolder and renames it too 0001 and sets the original 0001
        /// to targetProfileFolder's original folder name
        /// </summary>
        /// <param name="targetProfileFolder"></param>
        public void SelectProfile(string targetProfileFolder)
        {
            // Get the path of the current "0001" profile
            string defaultProfilePath = Path.Combine(_profilesDirectoryPath, "0001");

            // Get the path of the target profile
            string targetProfilePath = Path.Combine(_profilesDirectoryPath, targetProfileFolder);

            // Get the Windows temporary folder path
            string tempFolderPath = Path.GetTempPath();

            // Create a temporary path for the target profile
            string tempTargetProfilePath = Path.Combine(tempFolderPath, "BF2ProfileTargetTemp");

            // Rename the target profile to the temporary target path
            Directory.Move(targetProfilePath, tempTargetProfilePath);

            // Rename "0001" to the target profile's folder name
            Directory.Move(defaultProfilePath, targetProfilePath);

            // Rename the temporary target path to "0001"
            Directory.Move(tempTargetProfilePath, defaultProfilePath);

            // Update the profile in the profiles list and dictionary
            LoadProfiles();
        }



        /// <summary>
        /// Creates new Profile with defaulted .con files
        /// </summary>
        /// <param name="profileName"></param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public void CreateProfile(string profileName)
        {
            if (!Directory.Exists(_profilesDirectoryPath))
            {
                throw new DirectoryNotFoundException("Profiles directory does not exist.");
            }

            // Find the highest profile number from existing profiles
            int highestProfileNumber = 0;
            foreach (string folderName in _foldersAndProfiles.Keys)
            {
                if (int.TryParse(folderName, out int profileNumber))
                {
                    highestProfileNumber = Math.Max(highestProfileNumber, profileNumber);
                }
            }

            // Create the new profile number
            int newProfileNumber = highestProfileNumber + 1;

            // Create the new profile folder and copy its contents
            string newProfileFolderName = newProfileNumber.ToString("D4"); // Formats to 4 digits with leading zeros
            string newProfileFolderPath = Path.Combine(_profilesDirectoryPath, newProfileFolderName);
            Directory.CreateDirectory(newProfileFolderPath);

            // Creating default .con files
            _profileFileFactory.CreateDefaultProfileFiles(newProfileFolderPath, profileName);

            // Update the profile in the profiles list and dict
            LoadProfiles();
        }


        /// <summary>
        /// Deletes a specified Profile using its folder name, like 0001.
        /// </summary>
        /// <param name="profileFolderName"></param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public void DeleteProfile(string profileFolderName)
        {
            if (!Directory.Exists(_profilesDirectoryPath))
            {
                throw new DirectoryNotFoundException("Profiles directory does not exist.");
            }
            else if (!Directory.Exists(_profilesDirectoryPath + "\\" + profileFolderName))
            {
                throw new DirectoryNotFoundException($"Profile {profileFolderName} does not exist.");
            }
            else
            {
                Directory.Delete(_profilesDirectoryPath + "\\" + profileFolderName, true);
            }

            // Update the profile in the profiles list and dict
            LoadProfiles();
        }

        /// <summary>
        /// Renames a targeted Profile with it's folder name, like 0001, and takes in a new name to change in profile.con
        /// </summary>
        /// <param name="profileFolderName"></param>
        /// <param name="newName"></param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public void RenameProfile(string profileFolderName, string newName)
        {
            // Combining to acquire full path
            string profileFolderPath = Path.Combine(_profilesDirectoryPath, profileFolderName);

            if (!Directory.Exists(profileFolderPath))
            {
                throw new DirectoryNotFoundException($"Profile folder '{profileFolderName}' not found.");
            }

            string profileConFile = Path.Combine(profileFolderPath, "Profile.con");
            if (File.Exists(profileConFile))
            {
                UpdateProfileNameInConFile(profileConFile, newName);
            }

            // Update the profile in the profiles list and dict
            LoadProfiles();
        }

        /// <summary>
        /// Creates a copy of a specified profile and adds Copy to the name profile's name
        /// </summary>
        /// <param name="sourceProfileNumber"></param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void CopyProfile(string sourceProfileNumber)
        {
            string sourceProfileDirectoryPath = Path.Combine(_profilesDirectoryPath, sourceProfileNumber);

            if (!Directory.Exists(_profilesDirectoryPath))
            {
                throw new DirectoryNotFoundException("Profiles directory does not exist.");
            }

            if (!_foldersAndProfiles.TryGetValue(sourceProfileNumber, out Profile sourceProfile))
            {
                throw new ArgumentException($"Profile folder '{sourceProfileNumber}' not found.", nameof(sourceProfileNumber));
            }

            // Find the highest profile number from existing profiles
            int highestProfileNumber = 0;
            foreach (string folderName in _foldersAndProfiles.Keys)
            {
                if (int.TryParse(folderName, out int profileNumber))
                {
                    highestProfileNumber = Math.Max(highestProfileNumber, profileNumber);
                }
            }

            // Create the new profile number
            int newProfileNumber = highestProfileNumber + 1;

            string newProfileFolderName = newProfileNumber.ToString("D4"); // Formats to 4 digits with leading zeros
            // Create the new profile folder in Windows temp directory
            string tempProfileFolderPath = Path.Combine(Path.GetTempPath(), newProfileFolderName);

            Directory.CreateDirectory(tempProfileFolderPath);

            try
            {
                string[] files = Directory.GetFiles(sourceProfileDirectoryPath, "*.con");
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string destinationFilePath = Path.Combine(tempProfileFolderPath, fileName);
                    File.Copy(file, destinationFilePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while copying profile files: " + ex.Message);
                return;
            }

            // Move the new profile folder to the Profiles directory
            string finalProfileFolderPath = Path.Combine(_profilesDirectoryPath, newProfileFolderName);
            Directory.Move(tempProfileFolderPath, finalProfileFolderPath);

            // Update the LocalProfile.setName in Profile.con
            RenameProfile(finalProfileFolderPath, sourceProfile.Name + " Copy");

            // Update the profile in the profiles list and dict
            LoadProfiles();
        }

        /// <summary>
        /// Acquires all profiles found in Documents/Battlefield 2/Profiles
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DirectoryNotFoundException"></exception>

        public Dictionary<string, Profile>? LoadProfiles()
        {
            if (!Directory.Exists(_profilesDirectoryPath))
            {
                throw new DirectoryNotFoundException("Profiles directory does not exist.");
            }

            string[] profileFolders = Directory.GetDirectories(_profilesDirectoryPath);

            _foldersAndProfiles.Clear();

            foreach (string profileFolder in profileFolders)
            {
                string folderName = new DirectoryInfo(profileFolder).Name;
                string profileConFile = Path.Combine(profileFolder, "Profile.con");
                if (File.Exists(profileConFile))
                {
                    Profile profile = ReadProfileFromConFile(profileConFile);
                    profile.FolderName = folderName;
                    _foldersAndProfiles.Add(folderName, profile); // Add to the dictionary using the folder name as the key.
                }
            }

            return _foldersAndProfiles;
        }

        /// <summary>
        /// Reads Profile.con and creates profile object
        /// </summary>
        /// <param name="conFilePath"></param>
        /// <returns>New profile object</returns>
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

            return new Profile(name, nick, totalPlayedTime, numTimesLoggedIn, null);
        }

        /// <summary>
        /// Finds Profiles directory in Documents/Battlefield 2
        /// </summary>
        private void GetProfilesDirectory()
        {
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string remainingPath = "Battlefield 2\\Profiles";
            _profilesDirectoryPath = Path.Combine(documentsFolder, remainingPath);
        }

        /// <summary>
        /// Changes LocalProfile.setName in Profile.con
        /// </summary>
        /// <param name="conFilePath"></param>
        /// <param name="newName"></param>
        private void UpdateProfileNameInConFile(string conFilePath, string newName)
        {
            string[] conFileLines = File.ReadAllLines(conFilePath);

            for (int i = 0; i < conFileLines.Length; i++)
            {
                if (conFileLines[i].StartsWith("LocalProfile.setName"))
                {
                    conFileLines[i] = $"LocalProfile.setName \"{newName}\"";
                }
                if (conFileLines[i].StartsWith("LocalProfile.setNick"))
                {
                    conFileLines[i] = $"LocalProfile.setNick \"{newName}\"";
                    break; // We found the last line, so no need to continue searching
                }
            }

            File.WriteAllLines(conFilePath, conFileLines);
        }
    }
}