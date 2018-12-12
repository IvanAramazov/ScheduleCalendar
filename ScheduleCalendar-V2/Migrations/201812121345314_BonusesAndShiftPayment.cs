namespace ScheduleCalendar_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BonusesAndShiftPayment : DbMigration
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
            DropTable("dbo.ShiftPayments");
            DropTable("dbo.Bonus");
        }
    }
}
