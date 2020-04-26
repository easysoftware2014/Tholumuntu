using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Migrations;
using System.Linq;
using Tholaumuntu.DataAcces.Contexts;
using Tholaumuntu.DataAcces.Domain;
using Tholaumuntu.Repository.Contracts;

namespace Tholaumuntu.Repository.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly TholaUmuntuContext _tholaUmuntuContext;

        public UserProfileRepository()
        {
            _tholaUmuntuContext = new TholaUmuntuContext();
        }

        public int AddUserProfile(UserProfile profile)
        {
            
            try
            {
                _tholaUmuntuContext.UserProfiles.Add(profile);
                return _tholaUmuntuContext.SaveChanges();
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
           
        }

        public void UpdateUserProfile(UserProfile profile)
        {
            try
            {
                _tholaUmuntuContext.UserProfiles.AddOrUpdate(profile);
                _tholaUmuntuContext.SaveChanges();
            }
            catch (DbException e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        public void DeleteProfile(UserProfile profile)
        {
            try
            {
                _tholaUmuntuContext.UserProfiles.Remove(profile);
                _tholaUmuntuContext.SaveChanges();
            }
            catch (DbException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public UserProfile GetProfile(int id)
        {
            try
            {
                return _tholaUmuntuContext.UserProfiles.SingleOrDefault(x => x.Id == id);
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public UserProfile GetProfileByUserId(int userId)
        {
            try
            {
                return _tholaUmuntuContext.UserProfiles.SingleOrDefault(x => x.UserId == userId);
            }
            catch (DbException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}