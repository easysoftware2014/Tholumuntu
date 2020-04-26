namespace Tholumuntu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingProfileQuizObjectToId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProfiles", "Quiz_Id", "dbo.PersonalQuizs");
            DropIndex("dbo.UserProfiles", new[] { "Quiz_Id" });
            AddColumn("dbo.UserProfiles", "QuizId", c => c.Int(nullable: false));
            DropColumn("dbo.UserProfiles", "Quiz_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "Quiz_Id", c => c.Int());
            DropColumn("dbo.UserProfiles", "QuizId");
            CreateIndex("dbo.UserProfiles", "Quiz_Id");
            AddForeignKey("dbo.UserProfiles", "Quiz_Id", "dbo.PersonalQuizs", "Id");
        }
    }
}
