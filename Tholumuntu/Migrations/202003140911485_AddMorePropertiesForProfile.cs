namespace Tholumuntu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMorePropertiesForProfile : DbMigration
    {
        public override void Up()
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
            CreateIndex("dbo.UserProfiles", "Address_Id");
            AddForeignKey("dbo.UserProfiles", "Address_Id", "dbo.Addresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.UserProfiles", new[] { "Address_Id" });
            DropColumn("dbo.UserProfiles", "Address_Id");
            DropTable("dbo.Addresses");
        }
    }
}
