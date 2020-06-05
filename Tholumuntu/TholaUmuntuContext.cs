using System.Data.Entity;
using Tholaumuntu.DataAcces.Domain;

namespace Tholumuntu
{
    public class TholaUmuntuContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<PersonalQuiz> PersonalQuizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }

    }
}