using System.Collections.Generic;
using Tholaumuntu.DataAcces.Domain;

namespace Tholaumuntu.Services.Contracts
{
    public interface IUserService
    {
        int AddUser(User user);
        IList<User> GetAllUsers();
        User GetUserById(int id);
    }
}