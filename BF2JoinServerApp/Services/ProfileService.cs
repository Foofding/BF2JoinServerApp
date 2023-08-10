using BF2JoinServerApp.Data;
using BF2JoinServerApp.Models;
using System.Collections.Generic;

namespace BF2JoinServerApp.Services
{
    /// <summary>
    /// Service class to manage profiles
    /// </summary>
    public class ProfileService
    {
        // Instance of the ProfileRepository for data access
        private ProfileRepository _profileRepository;

        /// <summary>
        /// Constructor to initialize the ProfileService
        /// </summary>
        public ProfileService()
        {
            // Create a new instance of ProfileRepository
            _profileRepository = new ProfileRepository(new ProfileFileFactory());
        }


        /// <summary>
        /// Takes in targetProfileFolder and renames it too 0001 and sets the original 0001
        /// to targetProfileFolder's original folder name
        /// </summary>
        /// <param name="targetProfileFolder"></param>
        public void SelectProfile(string targetProfileFolder)
        {
            _profileRepository.SelectProfile(targetProfileFolder);
        }

        /// <summary>
        /// Gets and returns profiles list from _profileFiles
        /// </summary>
        /// <returns>Dictionary of profiles</returns>
        public List<Profile> GetProfiles()
        {
            List<Profile> profiles = new List<Profile>(_profileRepository.GetFoldersAndProfiles().Values);
            return profiles;
        }

        /// <summary>
        /// Gets and returns _profileFiles dict
        /// </summary>
        /// <returns>Dictionary of profiles</returns>
        public Dictionary<string, Profile> GetFoldersAndProfiles()
        {
            return _profileRepository.GetFoldersAndProfiles();
        }

        /// <summary>
        /// Method to create a new profile
        /// </summary>
        /// <param name="profileName">The name of the new profile</param>
        public void CreateProfile(string profileName)
        {
            _profileRepository.CreateProfile(profileName);
        }

        /// <summary>
        /// Method to delete an existing profile
        /// </summary>
        /// <param name="profileFolderName">The folder name of the profile to delete</param>
        public void DeleteProfile(string profileFolderName)
        {
            _profileRepository.DeleteProfile(profileFolderName);
        }

        /// <summary>
        /// Method to rename an existing profile
        /// </summary>
        /// <param name="profileFolderName">The current folder name of the profile</param>
        /// <param name="newName">The new name to assign to the profile</param>
        public void RenameProfile(string profileFolderName, string newName)
        {
            _profileRepository.RenameProfile(profileFolderName, newName);
        }

        /// <summary>
        /// Method to copy an existing profile
        /// </summary>
        /// <param name="profileFolderName">The folder name of the profile to copy</param>
        public void CopyProfile(string profileFolderName)
        {
            _profileRepository.CopyProfile(profileFolderName);
        }
    }
}
