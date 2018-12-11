namespace ScheduleCalendar_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpadeFK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        EmployeeDateOfHire = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        ShiftId = c.Int(nullable: false, identity: true),
                        Notes = c.String(),
                        StartShift = c.DateTime(nullable: false),
                        EndShift = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShiftId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shifts", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Shifts", new[] { "EmployeeId" });
            DropTable("dbo.Shifts");
            DropTable("dbo.Employees");
        }
    }
}
