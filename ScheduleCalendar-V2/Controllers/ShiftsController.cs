using ScheduleCalendar_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScheduleCalendar_V2.Controllers
{
    public class ShiftsController : Controller
    {
        // GET: Shifts
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            using (ScheduleCalendarContext_V2 cntx = new ScheduleCalendarContext_V2())
            {
                //var events = cntx.Shifts.ToList();

                var events = cntx.Shifts.Select(x => new {
                    id = x.ShiftId,
                    title = x.Employee.EmployeeName,
                    description = x.Notes,
                    start = x.StartShift,
                    end = x.EndShift,
                    shiftType = x.ShiftPayment.ShiftType,
                    location = x.Location.LocationName
                }).ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public JsonResult GetEventsByLocationId(int id)
        {
            using (ScheduleCalendarContext_V2 cntx = new ScheduleCalendarContext_V2())
            {
                var events = cntx.Shifts.Where(l => l.LocationId == id).Select(x => new {
                    id = x.ShiftId,
                    title = x.Employee.EmployeeName,
                    description = x.Notes,
                    start = x.StartShift,
                    end = x.EndShift,
                    shiftType = x.ShiftPayment.ShiftType,
                    location = x.Location.LocationName
                }).ToList();

                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(Shift s)
        {
            var status = false;
            using (ScheduleCalendarContext_V2 cntx = new ScheduleCalendarContext_V2())
            {
                if(s.ShiftId > 0)
                {
                    //update
                    var v = cntx.Shifts.Where(a => a.ShiftId == s.ShiftId).FirstOrDefault();
                    if (v != null)
                    {
                        v.EmployeeId = s.EmployeeId;
                        v.Notes = s.Notes;
                        v.StartShift = s.StartShift;
                        v.EndShift = s.EndShift;
                        v.ShiftPaymentId = s.ShiftPaymentId;
                        v.LocationId = s.LocationId;
                    }
                }
                else
                {
                    //add
                    cntx.Shifts.Add(s);
                }

                cntx.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int ShiftId)
        {
            var status = false;

            using (ScheduleCalendarContext_V2 cntx = new ScheduleCalendarContext_V2())
            {
                var v = cntx.Shifts.Where(a => a.ShiftId == ShiftId).FirstOrDefault();
                if (v != null)
                {
                    cntx.Shifts.Remove(v);
                    cntx.SaveChanges();
                    status = true;
                }

            }
            return new JsonResult { Data = new { status } };
        }
    }
}