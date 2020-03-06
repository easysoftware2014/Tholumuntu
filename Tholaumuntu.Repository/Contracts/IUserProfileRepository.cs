using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using Tholaumuntu.DataAcces.Domain;

namespace Tholaumuntu.Repository.Contracts
{
    public interface IUserProfileRepository
    {
        int AddUserProfile(UserProfile profile);
        void UpdateUserProfile(UserProfile profile);
        void DeleteProfile(UserProfile profile);
        UserProfile GetProfile(int id);

    }
}