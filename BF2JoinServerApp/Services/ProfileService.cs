using BF2JoinServerApp.Data;
using BF2JoinServerApp.Models;
using System.Collections.Generic;

namespace BF2JoinServerApp.Services
{
    public class ProfileService
    {
        ProfileRepository _profileRepository;

        public ProfileService()
        {
            _profileRepository = new ProfileRepository();
        }

        public void CreateProfile(string profileName)
        {
            _profileRepository.CreateProfile(profileName);
        }

        public void DeleteProfile(string profileFolderName)
        {
            _profileRepository.DeleteProfile(profileFolderName);
        }

        public void RenameProfile(string profileFolderName, string newName)
        {
            _profileRepository.RenameProfile(profileFolderName, newName);
        }

        public void CopyProfile(string profileFolderName)
        {
            _profileRepository.CopyProfile(profileFolderName);
        }

        public Dictionary<string, Profile> GetProfiles()
        {
            return _profileRepository.LoadProfiles();
        }

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
