using Tholaumuntu.DataAcces.Domain;

namespace Tholaumuntu.Services.Contracts
{
    public interface IUserProfileService
    {
        int AddUserProfile(UserProfile profile);
        void UpdateUserProfile(UserProfile profile);
        void DeleteProfile(UserProfile profile);
        UserProfile GetProfile(int id);
        UserProfile GetProfileByUserId(int userId);
    }
}