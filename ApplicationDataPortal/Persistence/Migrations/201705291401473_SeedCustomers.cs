namespace ApplicationDataPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Customers(Name) values('Tesco')");
            Sql("INSERT INTO dbo.Customers(Name) values('Sainsburys')");
            Sql("INSERT INTO dbo.Customers(Name) values('ASDA')");
        }
        
        public override void Down()
        {
        }
    }
}
