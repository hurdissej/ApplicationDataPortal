namespace ApplicationDataPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMockPromotionObject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        DisplayTypesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DisplayTypes", t => t.DisplayTypesId, cascadeDelete: true)
                .Index(t => t.DisplayTypesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Promotions", "DisplayTypesId", "dbo.DisplayTypes");
            DropIndex("dbo.Promotions", new[] { "DisplayTypesId" });
            DropTable("dbo.Promotions");
        }
    }
}
