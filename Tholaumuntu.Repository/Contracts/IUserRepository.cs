using System.Collections.Generic;
using Tholaumuntu.DataAcces.Domain;

namespace Tholaumuntu.Repository.Contracts
{
    public interface IUserRepository
    {
        int AddUser(User user);
        IList<User> GetAllUsers();
        User GetUserById(int id);
    }
}