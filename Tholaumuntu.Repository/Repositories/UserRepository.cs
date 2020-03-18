using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using Tholaumuntu.DataAcces.Contexts;
using Tholaumuntu.DataAcces.Domain;
using Tholaumuntu.Repository.Contracts;

namespace Tholaumuntu.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TholaUmuntuContext _tholaUmuntuContext;

        public UserRepository()
        {
            _tholaUmuntuContext = new TholaUmuntuContext();
        }
        public int AddUser(User user)
        {
            try
            {
                _tholaUmuntuContext.Users.Add(user);
                return _tholaUmuntuContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
        }

        public IList<User> GetAllUsers()
        {
            try
            {
                return _tholaUmuntuContext.Users.ToList();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public User GetUserById(int id)
        {
            return _tholaUmuntuContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            try
            {
                return _tholaUmuntuContext.Users.First(x => x.Email == email && x.Password == password);
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}