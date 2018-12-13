namespace ScheduleCalendar_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shifts", "ShiftPaymentId", c => c.Int());
            AddColumn("dbo.Shifts", "BonusId", c => c.Int());

            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shifts", "BonusId");
            DropColumn("dbo.Shifts", "ShiftPaymentId");
        }
    }
}
