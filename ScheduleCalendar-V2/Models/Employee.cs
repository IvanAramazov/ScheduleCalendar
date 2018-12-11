using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleCalendar_V2.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime EmployeeDateOfHire { get; set; }

        public ICollection<Shift> Shifts { get; set; }
    }
}