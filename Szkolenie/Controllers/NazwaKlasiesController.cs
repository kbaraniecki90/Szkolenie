using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Szkolenie.Models;

namespace Szkolenie.Controllers
{
    public class NazwaKlasiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public JsonResult nazwaKlasies()
        {
            var nazwaKlasies = db.NazwaKlasies.ToList().Select(a => new
            {
                Imie = a.Imie,
                Nazwisko = a.Nazwisko,
                Address = a.NazwaKlasy
            });

            return Json(new { data = nazwaKlasies }, JsonRequestBehavior.AllowGet);
        }

        // GET: NazwaKlasies
        public ActionResult Index()
        {
            return View(db.NazwaKlasies.ToList());
        }

        // GET: NazwaKlasies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NazwaKlasy nazwaKlasy = db.NazwaKlasies.Find(id);
            if (nazwaKlasy == null)
            {
                return HttpNotFound();
            }
            return View(nazwaKlasy);
        }

        // GET: NazwaKlasies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NazwaKlasies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Imie,Nazwisko")] NazwaKlasy nazwaKlasy)
        {
            if (ModelState.IsValid)
            {
                db.NazwaKlasies.Add(nazwaKlasy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nazwaKlasy);
        }

        // GET: NazwaKlasies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NazwaKlasy nazwaKlasy = db.NazwaKlasies.Find(id);
            if (nazwaKlasy == null)
            {
                return HttpNotFound();
            }
            return View(nazwaKlasy);
        }

        // POST: NazwaKlasies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Imie,Nazwisko")] NazwaKlasy nazwaKlasy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nazwaKlasy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nazwaKlasy);
        }

        // GET: NazwaKlasies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NazwaKlasy nazwaKlasy = db.NazwaKlasies.Find(id);
            if (nazwaKlasy == null)
            {
                return HttpNotFound();
            }
            return View(nazwaKlasy);
        }

        // POST: NazwaKlasies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NazwaKlasy nazwaKlasy = db.NazwaKlasies.Find(id);
            db.NazwaKlasies.Remove(nazwaKlasy);
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
