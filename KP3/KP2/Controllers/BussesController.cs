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
    public class BussesController : Controller
    {
        private TripDBEntities1 db = new TripDBEntities1();

        // GET: Busses
        public ActionResult Index()
        {
            return View(db.Buss.ToList());
        }

        // GET: Busses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buss buss = db.Buss.Find(id);
            if (buss == null)
            {
                return HttpNotFound();
            }
            return View(buss);
        }

        // GET: Busses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Busses/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,State")] Buss buss)
        {
            if (ModelState.IsValid)
            {
                db.Buss.Add(buss);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buss);
        }

        // GET: Busses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buss buss = db.Buss.Find(id);
            if (buss == null)
            {
                return HttpNotFound();
            }
            return View(buss);
        }

        // POST: Busses/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,State")] Buss buss)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buss).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buss);
        }

        // GET: Busses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buss buss = db.Buss.Find(id);
            if (buss == null)
            {
                return HttpNotFound();
            }
            return View(buss);
        }

        // POST: Busses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Buss buss = db.Buss.Find(id);
            db.Buss.Remove(buss);
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
