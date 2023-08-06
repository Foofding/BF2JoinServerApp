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
        /// Gets and returns _profiles list
        /// </summary>
        /// <returns>Dictionary of profiles</returns>
        public List<Profile> GetProfiles()
        {
            return _profileRepository.GetProfiles();
        }

        /// <summary>
        /// Gets and returns _profileFiles dict
        /// </summary>
        /// <returns>Dictionary of profiles</returns>
        public Dictionary<string, Profile> GetProfileFiles()
        {
            return _profileRepository.GetProfileFiles();
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

        /// <summary>
        /// Method to get a list of test profiles (for testing purposes)
        /// </summary>
        /// <returns>A list of test Profile objects</returns>
        public List<Profile> GetTestProfiles()
        {
            return new List<Profile>
            {
                new Profile("Shed1", "Shed1", 120, 69),
                new Profile("Shed2", "Shed2", 120, 420),
                new Profile("Shed3", "Shed3", 120, 1),
                new Profile("Shed4", "Shed4", 120, 100),
                new Profile("Shed5", "Shed5", 120, 1000),
                new Profile("Shed6", "Shed6", 120, 1337),
                new Profile("Shed7", "Shed7", 120, 0),
                new Profile("Shed8", "Shed8", 120, 64),
                new Profile("Shed9", "Shed9", 120, 128)
            };
        }
    }
}
