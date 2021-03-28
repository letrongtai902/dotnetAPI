namespace DotnetAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    FullName = c.String(maxLength: 50),
                    Email = c.String(maxLength: 30),
                    PhoneNumber = c.String(maxLength: 15),
                })
                .PrimaryKey(t => t.ID);

        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
