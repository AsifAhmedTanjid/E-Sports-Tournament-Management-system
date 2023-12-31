namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MatchTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TournamentId = c.Int(nullable: false),
                        MatchDate = c.DateTime(nullable: false),
                        Team1Id = c.Int(),
                        Team2Id = c.Int(),
                        WinnerTeamId = c.Int(),
                        Score = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team1Id)
                .ForeignKey("dbo.Teams", t => t.Team2Id)
                .ForeignKey("dbo.Tournaments", t => t.TournamentId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.WinnerTeamId)
                .Index(t => t.TournamentId)
                .Index(t => t.Team1Id)
                .Index(t => t.Team2Id)
                .Index(t => t.WinnerTeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "WinnerTeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "TournamentId", "dbo.Tournaments");
            DropForeignKey("dbo.Matches", "Team2Id", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Team1Id", "dbo.Teams");
            DropIndex("dbo.Matches", new[] { "WinnerTeamId" });
            DropIndex("dbo.Matches", new[] { "Team2Id" });
            DropIndex("dbo.Matches", new[] { "Team1Id" });
            DropIndex("dbo.Matches", new[] { "TournamentId" });
            DropTable("dbo.Matches");
        }
    }
}
