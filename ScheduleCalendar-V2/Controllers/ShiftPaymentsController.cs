using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScheduleCalendar_V2.Models;

namespace ScheduleCalendar_V2.Controllers
{
    public class ShiftPaymentsController : Controller
    {
        private ScheduleCalendarContext_V2 db = new ScheduleCalendarContext_V2();

        // GET: ShiftPayments
        public ActionResult Index()
        {
            return View(db.ShiftPayments.ToList());
        }

        public JsonResult GetShiftPayment()
        {
            using (ScheduleCalendarContext_V2 cntx = new ScheduleCalendarContext_V2())
            {
                //var events = cntx.Shifts.ToList();

                var events = cntx.ShiftPayments.Select(x => new {
                    paymentId = x.ShiftPaymentId,
                    payment = x.ShiftType
                }).ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        // GET: ShiftPayments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftPayment shiftPayment = db.ShiftPayments.Find(id);
            if (shiftPayment == null)
            {
                return HttpNotFound();
            }
            return View(shiftPayment);
        }

        // GET: ShiftPayments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShiftPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShiftPaymentId,ShiftType,ShiftPaymentRate")] ShiftPayment shiftPayment)
        {
            if (ModelState.IsValid)
            {
                db.ShiftPayments.Add(shiftPayment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shiftPayment);
        }

        // GET: ShiftPayments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftPayment shiftPayment = db.ShiftPayments.Find(id);
            if (shiftPayment == null)
            {
                return HttpNotFound();
            }
            return View(shiftPayment);
        }

        // POST: ShiftPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShiftPaymentId,ShiftType,ShiftPaymentRate")] ShiftPayment shiftPayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shiftPayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shiftPayment);
        }

        // GET: ShiftPayments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftPayment shiftPayment = db.ShiftPayments.Find(id);
            if (shiftPayment == null)
            {
                return HttpNotFound();
            }
            return View(shiftPayment);
        }

        // POST: ShiftPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShiftPayment shiftPayment = db.ShiftPayments.Find(id);
            db.ShiftPayments.Remove(shiftPayment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
