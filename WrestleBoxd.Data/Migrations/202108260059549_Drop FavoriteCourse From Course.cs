namespace GolfTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropFavoriteCourseFromCourse : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Course", "FavoriteCourse");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Course", "FavoriteCourse", c => c.Boolean(nullable: false));
        }
    }
}
