using Tholaumuntu.DataAcces.Domain;

namespace Tholumuntu.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TholaUmuntuContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TholaUmuntuContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //var user = new User
            //{
            //    ContactNumber = "",
            //    Surname = "Tester",
            //    CreatedAt = DateTime.Now,
            //    DateOfBirth = DateTime.Now,
            //    Email = "tester@gmail.com",
            //    Gender = "Male",
            //    ModifiedAt = DateTime.Now,
            //    Name = "Tester",
            //    Password = "P@ssw0rd",
            //    Salt = "HYHT*#%te",
            //    EntityStatus = EntityStatus.Active,
            //    Id = 1
            //};

            //context.Users.AddOrUpdate(user);
            //context.SaveChanges();

            //var profile = new UserProfile()
            //{
            //    CreatedAt = DateTime.Now,
            //    ModifiedAt = DateTime.Now,
            //    Horoscope = "GEMINI",
            //    LoveLanguage = LoveLanguage.PhysicalTouch,
            //    User = user,
            //    EntityStatus = EntityStatus.Active,
            //    Id = 1
            //};

            //context.UserProfiles.AddOrUpdate(profile);
            //context.SaveChanges();
        }
    }
}
