namespace CourseManagmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Enrollment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(unicode: false),
                        Course_id_Id = c.Int(),
                        User_id_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_id_Id)
                .ForeignKey("dbo.Users", t => t.User_id_Id)
                .Index(t => t.Course_id_Id)
                .Index(t => t.User_id_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "User_id_Id", "dbo.Users");
            DropForeignKey("dbo.Enrollments", "Course_id_Id", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "User_id_Id" });
            DropIndex("dbo.Enrollments", new[] { "Course_id_Id" });
            DropTable("dbo.Enrollments");
        }
    }
}
