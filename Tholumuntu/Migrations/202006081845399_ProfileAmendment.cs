namespace Tholumuntu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileAmendment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "PersonalInterest", c => c.String());
            AddColumn("dbo.UserProfiles", "DescribeYourself", c => c.String());
            AddColumn("dbo.UserProfiles", "FriendsDescribeYou", c => c.String());
            AddColumn("dbo.UserProfiles", "FavoriteQuote", c => c.String());
            AddColumn("dbo.Users", "Age", c => c.String());
            AlterColumn("dbo.UserAnswers", "Answer", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAnswers", "Answer", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Age");
            DropColumn("dbo.UserProfiles", "FavoriteQuote");
            DropColumn("dbo.UserProfiles", "FriendsDescribeYou");
            DropColumn("dbo.UserProfiles", "DescribeYourself");
            DropColumn("dbo.UserProfiles", "PersonalInterest");
        }
    }
}
