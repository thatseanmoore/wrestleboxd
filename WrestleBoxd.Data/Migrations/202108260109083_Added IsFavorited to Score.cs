namespace GolfTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsFavoritedtoScore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Score", "IsFavorited", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Score", "IsFavorited");
        }
    }
}
