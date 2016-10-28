using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capacitarte.DataAccess;
using Capacitarte.Models;

namespace Capacitarte.Controllers
{
    public class SedesController : Controller
    {
        private CapacitarteContext db = new CapacitarteContext();

        // GET: Sedes
        public ActionResult Index()
        {
            if(db.Sedes != null)
                return View(db.Sedes.ToList());

            return View(new List<Sede>());
        }

        // GET: Sedes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sede sede = db.Sedes.Find(id);
            if (sede == null)
            {
                return HttpNotFound();
            }
            return View(sede);
        }

        // GET: Sedes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sedes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Descripcion")] Sede sede)
        {
            if (ModelState.IsValid)
            {
                var sedeId = (db.Sedes == null || db.Sedes.Count() == 0 ? 0 : db.Sedes.Max(a => a.Id)) + 1;
                sede.Id = sedeId;
                db.Sedes.Add(sede);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sede);
        }

        // GET: Sedes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sede sede = db.Sedes.Find(id);
            if (sede == null)
            {
                return HttpNotFound();
            }
            return View(sede);
        }

        // POST: Sedes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion")] Sede sede)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sede).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sede);
        }

        // GET: Sedes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sede sede = db.Sedes.Find(id);
            if (sede == null)
            {
                return HttpNotFound();
            }
            return View(sede);
        }

        // POST: Sedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sede sede = db.Sedes.Find(id);
            db.Sedes.Remove(sede);
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
