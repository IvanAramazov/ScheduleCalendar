namespace ScheduleCalendar_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shifts", "Location_LocationId", "dbo.Locations");
            DropIndex("dbo.Shifts", new[] { "Location_LocationId" });
            AddColumn("dbo.Shifts", "Location_LocationId1", c => c.Int());
            AlterColumn("dbo.Shifts", "Location_LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shifts", "Location_LocationId1");
            AddForeignKey("dbo.Shifts", "Location_LocationId1", "dbo.Locations", "LocationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shifts", "Location_LocationId1", "dbo.Locations");
            DropIndex("dbo.Shifts", new[] { "Location_LocationId1" });
            AlterColumn("dbo.Shifts", "Location_LocationId", c => c.Int());
            DropColumn("dbo.Shifts", "Location_LocationId1");
            CreateIndex("dbo.Shifts", "Location_LocationId");
            AddForeignKey("dbo.Shifts", "Location_LocationId", "dbo.Locations", "LocationId");
        }
    }
}
