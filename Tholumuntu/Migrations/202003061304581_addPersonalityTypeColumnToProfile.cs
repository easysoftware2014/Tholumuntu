namespace Tholumuntu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPersonalityTypeColumnToProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "PersonalityType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "PersonalityType");
        }
    }
}
