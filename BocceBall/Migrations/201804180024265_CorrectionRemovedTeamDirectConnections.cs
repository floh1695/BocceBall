namespace BocceBall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectionRemovedTeamDirectConnections : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HomeTeamID = c.Int(nullable: false),
                        AwayTeamID = c.Int(nullable: false),
                        HomeScore = c.Int(nullable: false),
                        AwayScore = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TeamID = c.Int(nullable: false),
                        FullName = c.String(),
                        Nickname = c.String(),
                        Number = c.Int(nullable: false),
                        ThrowingArm = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teams", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.TeamID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Mascot = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "TeamID", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "TeamID" });
            DropTable("dbo.Teams");
            DropTable("dbo.Players");
            DropTable("dbo.Games");
        }
    }
}
