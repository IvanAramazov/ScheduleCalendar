namespace ScheduleCalendar_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shifts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Shifts", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Shifts", "ShiftPaymentId", "dbo.ShiftPayments");
            DropIndex("dbo.Shifts", new[] { "EmployeeId" });
            DropIndex("dbo.Shifts", new[] { "ShiftPaymentId" });
            DropIndex("dbo.Shifts", new[] { "LocationId" });
            AlterColumn("dbo.Shifts", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Shifts", "ShiftPaymentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Shifts", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shifts", "EmployeeId");
            CreateIndex("dbo.Shifts", "ShiftPaymentId");
            CreateIndex("dbo.Shifts", "LocationId");
            AddForeignKey("dbo.Shifts", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.Shifts", "LocationId", "dbo.Locations", "LocationId", cascadeDelete: true);
            AddForeignKey("dbo.Shifts", "ShiftPaymentId", "dbo.ShiftPayments", "ShiftPaymentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shifts", "ShiftPaymentId", "dbo.ShiftPayments");
            DropForeignKey("dbo.Shifts", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Shifts", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Shifts", new[] { "LocationId" });
            DropIndex("dbo.Shifts", new[] { "ShiftPaymentId" });
            DropIndex("dbo.Shifts", new[] { "EmployeeId" });
            AlterColumn("dbo.Shifts", "LocationId", c => c.Int());
            AlterColumn("dbo.Shifts", "ShiftPaymentId", c => c.Int());
            AlterColumn("dbo.Shifts", "EmployeeId", c => c.Int());
            CreateIndex("dbo.Shifts", "LocationId");
            CreateIndex("dbo.Shifts", "ShiftPaymentId");
            CreateIndex("dbo.Shifts", "EmployeeId");
            AddForeignKey("dbo.Shifts", "ShiftPaymentId", "dbo.ShiftPayments", "ShiftPaymentId");
            AddForeignKey("dbo.Shifts", "LocationId", "dbo.Locations", "LocationId");
            AddForeignKey("dbo.Shifts", "EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
