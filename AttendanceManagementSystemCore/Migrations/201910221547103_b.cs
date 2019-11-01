namespace AttendanceManagementSystemCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AttendanceTables", "Grade", c => c.String());
            AddColumn("dbo.AttendanceTables", "Division", c => c.String());
            DropColumn("dbo.AttendanceTables", "Stugrade");
            DropColumn("dbo.AttendanceTables", "StuClass");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AttendanceTables", "StuClass", c => c.String());
            AddColumn("dbo.AttendanceTables", "Stugrade", c => c.String());
            DropColumn("dbo.AttendanceTables", "Division");
            DropColumn("dbo.AttendanceTables", "Grade");
        }
    }
}
