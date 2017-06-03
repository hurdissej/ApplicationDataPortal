namespace ApplicationDataPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCustomersAndDisplayTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DisplayTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CustomerId = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DisplayTypes", "CustomerId", "dbo.Customers");
            DropIndex("dbo.DisplayTypes", new[] { "CustomerId" });
            DropTable("dbo.DisplayTypes");
            DropTable("dbo.Customers");
        }
    }
}
