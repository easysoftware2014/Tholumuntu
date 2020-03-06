using System.Data.Entity;
using Tholaumuntu.DataAcces.Domain;

namespace Tholumuntu
{
    public class TholaUmuntuContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}