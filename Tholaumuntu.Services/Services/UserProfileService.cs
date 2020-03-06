using System.Collections.Generic;
using Tholaumuntu.DataAcces.Domain;
using Tholaumuntu.Repository.Contracts;
using Tholaumuntu.Repository.Repositories;
using Tholaumuntu.Services.Contracts;

namespace Tholaumuntu.Services.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly UserProfileRepository _profileRepository;

        public UserProfileService()
        {
            _profileRepository = new UserProfileRepository();
        }

        public int AddUserProfile(UserProfile profile)
        {
            return _profileRepository.AddUserProfile(profile);
        }

        public void UpdateUserProfile(UserProfile profile)
        {
            _profileRepository.UpdateUserProfile(profile);
        }

        public void DeleteProfile(UserProfile profile)
        {
            _profileRepository.DeleteProfile(profile);
        }

        public UserProfile GetProfile(int id)
        {
            return _profileRepository.GetProfile(id);
        }
    }
}