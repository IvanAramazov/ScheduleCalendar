namespace ScheduleCalendar_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocationFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shifts", "LocationId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shifts", "LocationId");
        }
    }
}
