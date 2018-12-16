namespace ScheduleCalendar_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bonus",
                c => new
                    {
                        BonusId = c.Int(nullable: false, identity: true),
                        BonusType = c.String(),
                        BonusPayment = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BonusId);
            
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
                        EmployeeId = c.Int(),
                        ShiftPaymentId = c.Int(),
                        LocationId = c.Int(),
                    })
                .PrimaryKey(t => t.ShiftId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .ForeignKey("dbo.ShiftPayments", t => t.ShiftPaymentId)
                .Index(t => t.EmployeeId)
                .Index(t => t.ShiftPaymentId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.ShiftPayments",
                c => new
                    {
                        ShiftPaymentId = c.Int(nullable: false, identity: true),
                        ShiftType = c.String(),
                        ShiftPaymentRate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ShiftPaymentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shifts", "ShiftPaymentId", "dbo.ShiftPayments");
            DropForeignKey("dbo.Shifts", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Shifts", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Shifts", new[] { "LocationId" });
            DropIndex("dbo.Shifts", new[] { "ShiftPaymentId" });
            DropIndex("dbo.Shifts", new[] { "EmployeeId" });
            DropTable("dbo.ShiftPayments");
            DropTable("dbo.Locations");
            DropTable("dbo.Shifts");
            DropTable("dbo.Employees");
            DropTable("dbo.Bonus");
        }
    }
}
