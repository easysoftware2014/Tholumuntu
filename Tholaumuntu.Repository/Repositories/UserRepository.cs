using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
                using (_tholaUmuntuContext)
                {
                    _tholaUmuntuContext.Users.Add(user);
                    return _tholaUmuntuContext.SaveChanges();
                }
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
            return _tholaUmuntuContext.Users.SingleOrDefault(x => x.Id == id);
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

        public bool Update(User user)
        {
            try
            {
                using (_tholaUmuntuContext)
                {
                    var userToUpdate = _tholaUmuntuContext.Users.SingleOrDefault(x => x.Id == user.Id);

                    if (userToUpdate != null)
                    {
                        userToUpdate = user;
                        _tholaUmuntuContext.Users.AddOrUpdate(userToUpdate);
                        return _tholaUmuntuContext.SaveChanges() > 0;
                    }
                }
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e.EntityValidationErrors.Select(x=>x.ValidationErrors.Select(y=>y.ErrorMessage)));
                return false;
            }

            return false;
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                return _tholaUmuntuContext.Users.FirstOrDefault(x => x.Email == email);
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}