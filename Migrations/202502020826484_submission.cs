namespace CourseManagmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class submission : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubmissionDate = c.DateTime(nullable: false, precision: 0),
                        FilePath = c.String(unicode: false),
                        Comments = c.String(unicode: false),
                        Grade = c.Decimal(precision: 18, scale: 2),
                        Assessment_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assessments", t => t.Assessment_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Assessment_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submissions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Submissions", "Assessment_Id", "dbo.Assessments");
            DropIndex("dbo.Submissions", new[] { "User_Id" });
            DropIndex("dbo.Submissions", new[] { "Assessment_Id" });
            DropTable("dbo.Submissions");
        }
    }
}
