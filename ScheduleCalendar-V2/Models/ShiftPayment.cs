using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleCalendar_V2.Models
{
    public class ShiftPayment
    {
        public int ShiftPaymentId { get; set; }
        public string ShiftType { get; set; }
        public double ShiftPaymentRate { get; set; }
        public List<Shift> Shifts { get; set; }

    }
}