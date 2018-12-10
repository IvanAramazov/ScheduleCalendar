using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ScheduleCalendar_V2.Models
{
    public class ScheduleCalendarContext_V2 : DbContext
    {

        public ScheduleCalendarContext_V2() : base("ScheduleCalendarV2")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ScheduleCalendarContext_V2, Migrations.Configuration>());
        }

        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}