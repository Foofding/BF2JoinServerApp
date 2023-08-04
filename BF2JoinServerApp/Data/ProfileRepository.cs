using BF2JoinServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF2JoinServerApp.Data
{
    public class ProfileRepository
    {
        private List<Profile> _profiles;

        public ProfileRepository()
        {
            _profiles = GetAllProfiles();
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

        private List<Profile>? GetAllProfiles()
        {
            throw new NotImplementedException();
        }
    }
}
