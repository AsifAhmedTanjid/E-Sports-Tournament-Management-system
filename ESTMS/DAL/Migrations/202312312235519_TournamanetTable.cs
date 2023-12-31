namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TournamanetTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TournamentTeamDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TournamentId = c.Int(),
                        TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .ForeignKey("dbo.Tournaments", t => t.TournamentId)
                .Index(t => t.TournamentId)
                .Index(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TournamentTeamDetails", "TournamentId", "dbo.Tournaments");
            DropForeignKey("dbo.TournamentTeamDetails", "TeamId", "dbo.Teams");
            DropIndex("dbo.TournamentTeamDetails", new[] { "TeamId" });
            DropIndex("dbo.TournamentTeamDetails", new[] { "TournamentId" });
            DropTable("dbo.TournamentTeamDetails");
        }
    }
}
