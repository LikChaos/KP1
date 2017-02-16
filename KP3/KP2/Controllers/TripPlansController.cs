using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KP2.Models;

namespace KP2.Controllers
{
    public class TripPlansController : Controller
    {
        private TripDBEntities1 db = new TripDBEntities1();

        // GET: TripPlans
        public ActionResult Index()
        {
            var tripPlan = db.TripPlan.Include(t => t.Buss).Include(t => t.Trip).Include(t => t.Users).Include(t => t.Users1);
            return View(tripPlan.ToList());
        }

        // GET: TripPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripPlan tripPlan = db.TripPlan.Find(id);
            if (tripPlan == null)
            {
                return HttpNotFound();
            }
            return View(tripPlan);
        }

        // GET: TripPlans/Create
        public ActionResult Create()
        {
            ViewBag.Id_buss = new SelectList(db.Buss, "Id", "name");
            ViewBag.Id_trip = new SelectList(db.Trip, "Id", "name");
            ViewBag.Id_driver = new SelectList(db.Users, "Id", "login");
            ViewBag.Id_worker = new SelectList(db.Users, "Id", "login");
            return View();
        }

        // POST: TripPlans/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Day,Id_trip,Id_driver,Id_worker,Id_buss")] TripPlan tripPlan)
        {
            if (ModelState.IsValid)
            {
                db.TripPlan.Add(tripPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_buss = new SelectList(db.Buss, "Id", "name", tripPlan.Id_buss);
            ViewBag.Id_trip = new SelectList(db.Trip, "Id", "name", tripPlan.Id_trip);
            ViewBag.Id_driver = new SelectList(db.Users, "Id", "login", tripPlan.Id_driver);
            ViewBag.Id_worker = new SelectList(db.Users, "Id", "login", tripPlan.Id_worker);
            return View(tripPlan);
        }

        // GET: TripPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripPlan tripPlan = db.TripPlan.Find(id);
            if (tripPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_buss = new SelectList(db.Buss, "Id", "name", tripPlan.Id_buss);
            ViewBag.Id_trip = new SelectList(db.Trip, "Id", "name", tripPlan.Id_trip);
            ViewBag.Id_driver = new SelectList(db.Users, "Id", "login", tripPlan.Id_driver);
            ViewBag.Id_worker = new SelectList(db.Users, "Id", "login", tripPlan.Id_worker);
            return View(tripPlan);
        }

        // POST: TripPlans/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Day,Id_trip,Id_driver,Id_worker,Id_buss")] TripPlan tripPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tripPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_buss = new SelectList(db.Buss, "Id", "name", tripPlan.Id_buss);
            ViewBag.Id_trip = new SelectList(db.Trip, "Id", "name", tripPlan.Id_trip);
            ViewBag.Id_driver = new SelectList(db.Users, "Id", "login", tripPlan.Id_driver);
            ViewBag.Id_worker = new SelectList(db.Users, "Id", "login", tripPlan.Id_worker);
            return View(tripPlan);
        }

        // GET: TripPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripPlan tripPlan = db.TripPlan.Find(id);
            if (tripPlan == null)
            {
                return HttpNotFound();
            }
            return View(tripPlan);
        }

        // POST: TripPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TripPlan tripPlan = db.TripPlan.Find(id);
            db.TripPlan.Remove(tripPlan);
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
