namespace ScheduleCalendar_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocationFK2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Shifts", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shifts", "LocationId");
            AddForeignKey("dbo.Shifts", "LocationId", "dbo.Locations", "LocationId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shifts", "LocationId", "dbo.Locations");
            DropIndex("dbo.Shifts", new[] { "LocationId" });
            AlterColumn("dbo.Shifts", "LocationId", c => c.Int());
        }
    }
}
