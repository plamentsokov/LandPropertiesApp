namespace LandPropertiesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOwners : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Owners");
        }
    }
}
