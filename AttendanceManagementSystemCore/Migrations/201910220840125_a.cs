namespace AttendanceManagementSystemCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttendanceTables",
                c => new
                    {
                        StudentNO = c.String(nullable: false, maxLength: 128),
                        year = c.Int(nullable: false),
                        month = c.Int(nullable: false),
                        date = c.Int(nullable: false),
                        AttendanceMark = c.Boolean(nullable: false),
                        Stugrade = c.String(),
                        StuClass = c.String(),
                    })
                .PrimaryKey(t => new { t.StudentNO, t.year, t.month, t.date });
            
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        DivisionID = c.Int(nullable: false, identity: true),
                        DivisionName = c.String(),
                        EnteredDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DivisionID);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeID = c.Int(nullable: false, identity: true),
                        GradeName = c.String(),
                        EnteredDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GradeID);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        MediumID = c.Int(nullable: false, identity: true),
                        MediumName = c.String(),
                        EnteredDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MediumID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        School = c.String(),
                        IndexNo = c.String(),
                        Gender = c.String(),
                        FName = c.String(),
                        LName = c.String(),
                        GradeID = c.Int(nullable: false),
                        DivisionID = c.Int(nullable: false),
                        Medium = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Address = c.String(),
                        Address1 = c.String(),
                        PhoneNo = c.String(),
                        Email = c.String(),
                        EnteredDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Divisions", t => t.DivisionID, cascadeDelete: true)
                .ForeignKey("dbo.Grades", t => t.GradeID, cascadeDelete: true)
                .Index(t => t.GradeID)
                .Index(t => t.DivisionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.Students", "DivisionID", "dbo.Divisions");
            DropIndex("dbo.Students", new[] { "DivisionID" });
            DropIndex("dbo.Students", new[] { "GradeID" });
            DropTable("dbo.Students");
            DropTable("dbo.Media");
            DropTable("dbo.Grades");
            DropTable("dbo.Divisions");
            DropTable("dbo.AttendanceTables");
        }
    }
}
