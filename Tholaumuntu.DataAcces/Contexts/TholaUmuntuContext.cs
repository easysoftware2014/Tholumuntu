using System.Data.Entity;
using Tholaumuntu.DataAcces.Domain;

namespace Tholaumuntu.DataAcces.Contexts
{
    public class TholaUmuntuContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<PersonalQuiz> PersonalQuizzes { get; set; }
    }
}