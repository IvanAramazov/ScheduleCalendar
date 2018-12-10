﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleCalendar_V2.Models
{
    public class Shift
    {
        public int ShiftId { get; set; }
        public string Employee { get; set; }
        public string Notes { get; set; }
        public DateTime StartShift { get; set; }
        public DateTime EndShift { get; set; }
    }
}