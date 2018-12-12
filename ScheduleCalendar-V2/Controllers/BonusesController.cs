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
    public class BonusesController : Controller
    {
        private ScheduleCalendarContext_V2 db = new ScheduleCalendarContext_V2();

        // GET: Bonuses
        public ActionResult Index()
        {
            return View(db.Bonuses.ToList());
        }

        // GET: Bonuses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bonus bonus = db.Bonuses.Find(id);
            if (bonus == null)
            {
                return HttpNotFound();
            }
            return View(bonus);
        }

        // GET: Bonuses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bonuses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BonusId,BonusType,BonusPayment")] Bonus bonus)
        {
            if (ModelState.IsValid)
            {
                db.Bonuses.Add(bonus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bonus);
        }

        // GET: Bonuses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bonus bonus = db.Bonuses.Find(id);
            if (bonus == null)
            {
                return HttpNotFound();
            }
            return View(bonus);
        }

        // POST: Bonuses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BonusId,BonusType,BonusPayment")] Bonus bonus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bonus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bonus);
        }

        // GET: Bonuses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bonus bonus = db.Bonuses.Find(id);
            if (bonus == null)
            {
                return HttpNotFound();
            }
            return View(bonus);
        }

        // POST: Bonuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bonus bonus = db.Bonuses.Find(id);
            db.Bonuses.Remove(bonus);
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
