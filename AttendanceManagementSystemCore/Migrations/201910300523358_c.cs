namespace AttendanceManagementSystemCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminName = c.String(),
                        EmpNo = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        EnteredDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AdminID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
