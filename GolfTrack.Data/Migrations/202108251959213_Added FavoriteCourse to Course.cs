namespace GolfTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFavoriteCoursetoCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "FavoriteCourse", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course", "FavoriteCourse");
        }
    }
}
