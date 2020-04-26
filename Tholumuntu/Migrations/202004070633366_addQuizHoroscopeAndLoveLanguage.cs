namespace Tholumuntu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addQuizHoroscopeAndLoveLanguage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProfiles", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.UserProfiles", new[] { "Address_Id" });
            CreateTable(
                "dbo.PersonalQuizs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WordsThatDescribesMe = c.String(),
                        ChoiceBetweenMoneyLoveHappiness = c.Int(nullable: false),
                        AttractiveInPartner = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.UserProfiles", "Quiz_Id", c => c.Int());
            AddColumn("dbo.Users", "Street", c => c.String());
            AddColumn("dbo.Users", "State", c => c.String());
            CreateIndex("dbo.UserProfiles", "Quiz_Id");
            AddForeignKey("dbo.UserProfiles", "Quiz_Id", "dbo.PersonalQuizs", "Id");
            DropColumn("dbo.UserProfiles", "Address_Id");
            DropTable("dbo.Addresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        PostalCode = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserProfiles", "Address_Id", c => c.Int());
            DropForeignKey("dbo.UserProfiles", "Quiz_Id", "dbo.PersonalQuizs");
            DropForeignKey("dbo.PersonalQuizs", "User_Id", "dbo.Users");
            DropIndex("dbo.UserProfiles", new[] { "Quiz_Id" });
            DropIndex("dbo.PersonalQuizs", new[] { "User_Id" });
            DropColumn("dbo.Users", "State");
            DropColumn("dbo.Users", "Street");
            DropColumn("dbo.UserProfiles", "Quiz_Id");
            DropTable("dbo.PersonalQuizs");
            CreateIndex("dbo.UserProfiles", "Address_Id");
            AddForeignKey("dbo.UserProfiles", "Address_Id", "dbo.Addresses", "Id");
        }
    }
}
