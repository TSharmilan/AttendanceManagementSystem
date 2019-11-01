namespace AttendanceManagementSystemCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                        EmpNo = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        EnteredDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
        }
    }
}
