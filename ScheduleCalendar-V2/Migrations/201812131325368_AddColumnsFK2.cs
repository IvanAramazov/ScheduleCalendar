namespace ScheduleCalendar_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsFK2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Shifts", "ShiftPaymentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Shifts", "BonusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shifts", "ShiftPaymentId");
            CreateIndex("dbo.Shifts", "BonusId");
            AddForeignKey("dbo.Shifts", "BonusId", "dbo.Bonus", "BonusId", cascadeDelete: true);
            AddForeignKey("dbo.Shifts", "ShiftPaymentId", "dbo.ShiftPayments", "ShiftPaymentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shifts", "ShiftPaymentId", "dbo.ShiftPayments");
            DropForeignKey("dbo.Shifts", "BonusId", "dbo.Bonus");
            DropIndex("dbo.Shifts", new[] { "BonusId" });
            DropIndex("dbo.Shifts", new[] { "ShiftPaymentId" });
            AlterColumn("dbo.Shifts", "BonusId", c => c.Int());
            AlterColumn("dbo.Shifts", "ShiftPaymentId", c => c.Int());
        }
    }
}
