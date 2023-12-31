namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tillTournamentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        GameName = c.String(nullable: false, maxLength: 50),
                        GameWebsite = c.String(maxLength: 100),
                        GameLogo = c.String(nullable: false, maxLength: 100),
                        Genre = c.String(nullable: false, maxLength: 50),
                        Platform = c.String(nullable: false, maxLength: 50),
                        GameRules = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GameId);
            
            CreateTable(
                "dbo.Organizers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Contact = c.String(nullable: false, maxLength: 11),
                        Gender = c.String(nullable: false, maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 10),
                        Status = c.String(nullable: false, maxLength: 10),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Contact = c.String(nullable: false, maxLength: 11),
                        Gender = c.String(nullable: false, maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 10),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Sponsors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Contact = c.String(nullable: false, maxLength: 11),
                        logo = c.String(maxLength: 100),
                        Website = c.String(maxLength: 100),
                        SponsershipTier = c.String(maxLength: 10),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(nullable: false, maxLength: 50),
                        Website = c.String(maxLength: 100),
                        Logo = c.String(nullable: false, maxLength: 100),
                        CaptainId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Players", t => t.CaptainId, cascadeDelete: true)
                .Index(t => t.CaptainId);
            
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TournamentTitle = c.String(nullable: false, maxLength: 100),
                        TournamentLogo = c.String(nullable: false, maxLength: 100),
                        RegistrationOpenDate = c.DateTime(nullable: false),
                        RegistrationCloseDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        OrganizedBy = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                        PrizePool = c.Int(nullable: false),
                        RegistrationFee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Organizers", t => t.OrganizedBy, cascadeDelete: true)
                .Index(t => t.OrganizedBy)
                .Index(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tournaments", "OrganizedBy", "dbo.Organizers");
            DropForeignKey("dbo.Tournaments", "GameId", "dbo.Games");
            DropForeignKey("dbo.Teams", "CaptainId", "dbo.Players");
            DropForeignKey("dbo.Sponsors", "UserId", "dbo.Users");
            DropForeignKey("dbo.Players", "UserId", "dbo.Users");
            DropForeignKey("dbo.Organizers", "UserId", "dbo.Users");
            DropIndex("dbo.Tournaments", new[] { "GameId" });
            DropIndex("dbo.Tournaments", new[] { "OrganizedBy" });
            DropIndex("dbo.Teams", new[] { "CaptainId" });
            DropIndex("dbo.Sponsors", new[] { "UserId" });
            DropIndex("dbo.Players", new[] { "UserId" });
            DropIndex("dbo.Organizers", new[] { "UserId" });
            DropTable("dbo.Tournaments");
            DropTable("dbo.Teams");
            DropTable("dbo.Sponsors");
            DropTable("dbo.Players");
            DropTable("dbo.Users");
            DropTable("dbo.Organizers");
            DropTable("dbo.Games");
        }
    }
}
