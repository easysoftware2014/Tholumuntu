using System.Collections.Generic;
using Tholaumuntu.DataAcces.Domain;
using Tholaumuntu.Repository.Repositories;
using Tholaumuntu.Services.Contracts;

namespace Tholaumuntu.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository(); 
        }
        public int AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public IList<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }
    }
}