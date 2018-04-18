namespace BocceBall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepairedFKsForGames : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Players", "TeamID", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "TeamID" });
            AlterColumn("dbo.Games", "HomeTeamID", c => c.Int());
            AlterColumn("dbo.Games", "AwayTeamID", c => c.Int());
            AlterColumn("dbo.Players", "TeamID", c => c.Int());
            CreateIndex("dbo.Games", "HomeTeamID");
            CreateIndex("dbo.Games", "AwayTeamID");
            CreateIndex("dbo.Players", "TeamID");
            AddForeignKey("dbo.Games", "AwayTeamID", "dbo.Teams", "ID");
            AddForeignKey("dbo.Games", "HomeTeamID", "dbo.Teams", "ID");
            AddForeignKey("dbo.Players", "TeamID", "dbo.Teams", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "TeamID", "dbo.Teams");
            DropForeignKey("dbo.Games", "HomeTeamID", "dbo.Teams");
            DropForeignKey("dbo.Games", "AwayTeamID", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "TeamID" });
            DropIndex("dbo.Games", new[] { "AwayTeamID" });
            DropIndex("dbo.Games", new[] { "HomeTeamID" });
            AlterColumn("dbo.Players", "TeamID", c => c.Int(nullable: false));
            AlterColumn("dbo.Games", "AwayTeamID", c => c.Int(nullable: false));
            AlterColumn("dbo.Games", "HomeTeamID", c => c.Int(nullable: false));
            CreateIndex("dbo.Players", "TeamID");
            AddForeignKey("dbo.Players", "TeamID", "dbo.Teams", "ID", cascadeDelete: true);
        }
    }
}
