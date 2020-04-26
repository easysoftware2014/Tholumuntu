namespace Tholumuntu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactoringUserAndUserProfileDomain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonalQuizs", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserProfiles", "User_Id", "dbo.Users");
            DropIndex("dbo.PersonalQuizs", new[] { "User_Id" });
            DropIndex("dbo.UserProfiles", new[] { "User_Id" });
            AddColumn("dbo.PersonalQuizs", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.UserProfiles", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.PersonalQuizs", "User_Id");
            DropColumn("dbo.UserProfiles", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "User_Id", c => c.Int());
            AddColumn("dbo.PersonalQuizs", "User_Id", c => c.Int());
            DropColumn("dbo.UserProfiles", "UserId");
            DropColumn("dbo.PersonalQuizs", "UserId");
            CreateIndex("dbo.UserProfiles", "User_Id");
            CreateIndex("dbo.PersonalQuizs", "User_Id");
            AddForeignKey("dbo.UserProfiles", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.PersonalQuizs", "User_Id", "dbo.Users", "Id");
        }
    }
}
