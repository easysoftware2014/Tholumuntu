using System.Collections.Generic;
using System.IO;
using Tholaumuntu.DataAcces.Domain;

namespace Tholaumuntu.Services.Contracts
{
    public interface IUserService
    {
        int AddUser(User user);
        IList<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByEmailAndPassword(string email, string password);
        User GetUserByEmail(string email);
        void Update(User user);
    }
}