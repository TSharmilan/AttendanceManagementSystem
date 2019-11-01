namespace AttendanceManagementSystemCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AttendanceTables", "Grade", c => c.Int(nullable: false));
            AlterColumn("dbo.AttendanceTables", "Division", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AttendanceTables", "Division", c => c.String());
            AlterColumn("dbo.AttendanceTables", "Grade", c => c.String());
        }
    }
}
