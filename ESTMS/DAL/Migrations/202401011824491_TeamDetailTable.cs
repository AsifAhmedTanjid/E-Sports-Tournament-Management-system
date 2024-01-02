namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeamDetailTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeamDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamId = c.Int(),
                        PlayerId = c.Int(),
                        Status = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerId)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .Index(t => t.TeamId)
                .Index(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamDetails", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.TeamDetails", "PlayerId", "dbo.Players");
            DropIndex("dbo.TeamDetails", new[] { "PlayerId" });
            DropIndex("dbo.TeamDetails", new[] { "TeamId" });
            DropTable("dbo.TeamDetails");
        }
    }
}
