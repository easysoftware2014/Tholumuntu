namespace Tholumuntu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProfileEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "ChoiceBetweenMoneyLoveHappiness", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "ChoiceBetweenMoneyLoveHappiness");
        }
    }
}
