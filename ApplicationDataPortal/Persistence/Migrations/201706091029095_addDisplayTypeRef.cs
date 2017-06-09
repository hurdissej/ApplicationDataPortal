namespace ApplicationDataPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDisplayTypeRef : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DisplayTypes", "GlobalDisplayTypeRef", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DisplayTypes", "GlobalDisplayTypeRef");
        }
    }
}
