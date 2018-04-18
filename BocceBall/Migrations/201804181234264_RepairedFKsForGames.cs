namespace BocceBall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepairedFKsForGames : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Games", "HomeTeamID");
            CreateIndex("dbo.Games", "AwayTeamID");
            AddForeignKey("dbo.Games", "AwayTeamID", "dbo.Teams", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Games", "HomeTeamID", "dbo.Teams", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "HomeTeamID", "dbo.Teams");
            DropForeignKey("dbo.Games", "AwayTeamID", "dbo.Teams");
            DropIndex("dbo.Games", new[] { "AwayTeamID" });
            DropIndex("dbo.Games", new[] { "HomeTeamID" });
        }
    }
}
