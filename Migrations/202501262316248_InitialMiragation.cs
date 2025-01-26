namespace CourseManagmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMiragation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Code = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        Instructor = c.String(unicode: false),
                        Duration = c.String(unicode: false),
                        Syllabus = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Role = c.String(unicode: false),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Courses");
        }
    }
}
