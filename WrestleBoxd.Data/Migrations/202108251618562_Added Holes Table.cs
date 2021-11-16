namespace GolfTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHolesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hole",
                c => new
                    {
                        HoleId = c.Int(nullable: false, identity: true),
                        HoleNumber = c.Int(nullable: false),
                        Par = c.Int(nullable: false),
                        Yards = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HoleId)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hole", "CourseId", "dbo.Course");
            DropIndex("dbo.Hole", new[] { "CourseId" });
            DropTable("dbo.Hole");
        }
    }
}
