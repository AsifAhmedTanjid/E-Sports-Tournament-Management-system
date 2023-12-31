namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class organizationAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationName = c.String(nullable: false, maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 10),
                        Website = c.String(maxLength: 100),
                        Logo = c.String(maxLength: 100),
                        Cover = c.String(maxLength: 100),
                        Description = c.String(),
                        Owner = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizers", t => t.Owner, cascadeDelete: true)
                .Index(t => t.Owner);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organizations", "Owner", "dbo.Organizers");
            DropIndex("dbo.Organizations", new[] { "Owner" });
            DropTable("dbo.Organizations");
        }
    }
}
