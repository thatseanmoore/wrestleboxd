namespace GolfTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFKforCourseandScore : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Rating", "CourseId");
            CreateIndex("dbo.Score", "CourseId");
            AddForeignKey("dbo.Rating", "CourseId", "dbo.Course", "CourseId", cascadeDelete: true);
            AddForeignKey("dbo.Score", "CourseId", "dbo.Course", "CourseId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Score", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Rating", "CourseId", "dbo.Course");
            DropIndex("dbo.Score", new[] { "CourseId" });
            DropIndex("dbo.Rating", new[] { "CourseId" });
        }
    }
}
