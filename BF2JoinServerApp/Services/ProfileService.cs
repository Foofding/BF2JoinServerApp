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
                new Profile("JoeBiden", "JoeBiden", 120, 0),
                new Profile("BiggoNiggo", "JoeBiden", 120, 0),
                new Profile("WonkasFirstChoice", "JoeBiden", 120, 0),
                new Profile("ButtholeSurfer", "JoeBiden", 120, 0),
                new Profile("Shed5", "JoeBiden", 120, 0),
                new Profile("Shed6", "JoeBiden", 120, 0),
                new Profile("Shed7", "JoeBiden", 120, 0),
                new Profile("Shed8", "JoeBiden", 120, 0),
            };
        }
    }
}
