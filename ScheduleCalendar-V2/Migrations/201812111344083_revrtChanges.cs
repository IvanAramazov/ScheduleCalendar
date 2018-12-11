namespace ScheduleCalendar_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revrtChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shifts", "Location_LocationId1", "dbo.Locations");
            DropIndex("dbo.Shifts", new[] { "Location_LocationId1" });
            DropColumn("dbo.Shifts", "Location_LocationId1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shifts", "Location_LocationId1", c => c.Int());
            AddColumn("dbo.Shifts", "Location_LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shifts", "Location_LocationId1");
            AddForeignKey("dbo.Shifts", "Location_LocationId1", "dbo.Locations", "LocationId");
        }
    }
}
