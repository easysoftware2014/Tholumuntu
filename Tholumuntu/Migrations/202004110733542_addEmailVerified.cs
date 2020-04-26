namespace Tholumuntu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmailVerified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "EmailVerified", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "EmailVerified");
        }
    }
}
