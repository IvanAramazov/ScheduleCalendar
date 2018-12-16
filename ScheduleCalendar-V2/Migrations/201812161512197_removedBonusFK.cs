namespace ScheduleCalendar_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedBonusFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shifts", "BonusId", "dbo.Bonus");
            DropIndex("dbo.Shifts", new[] { "BonusId" });
            DropColumn("dbo.Shifts", "BonusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shifts", "BonusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shifts", "BonusId");
            AddForeignKey("dbo.Shifts", "BonusId", "dbo.Bonus", "BonusId", cascadeDelete: true);
        }
    }
}
