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
    public class AulasController : Controller
    {
        private CapacitarteContext db = new CapacitarteContext();

        // GET: Aulas
        public ActionResult Index()
        {
            return View(db.Aulas.ToList());
        }

        // GET: Aulas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aula aula = db.Aulas.Include(i => i.Sede).SingleOrDefault(x => x.Id == id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View(aula);
        }

        // GET: Aulas/Create
        public ActionResult Create()
        {
            var model = new AulaViewModel()
            {
                SedeList = GetSedes()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Cupo,Estado,SelectedSedeId")] AulaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var aulaId = (db.Aulas == null || db.Aulas.Count() == 0 ? 0 : db.Aulas.Max(a => a.Id)) + 1;
                var sede = db.Sedes.First(s => s.Id == model.SelectedSedeId);
                var aula = model.GetNewAula(aulaId, sede);
                db.Aulas.Add(aula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Aulas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aula = db.Aulas.Include(i => i.Sede).SingleOrDefault(x => x.Id == id);
            var model = new AulaViewModel()
            {
                Id = aula.Id,
                Descripcion = aula.Descripcion,
                Cupo = aula.Cupo,
                Estado = aula.Estado,
                SelectedSedeId = aula.Sede.Id,
                SedeList = GetSedes()
            };
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Aulas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Cupo,Estado,SelectedSedeId")] AulaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var aula = db.Aulas.Include(i => i.Sede).SingleOrDefault(x => x.Id == model.Id);
                if (aula.Sede.Id != model.SelectedSedeId)
                {
                    var sede = db.Sedes.First(s => s.Id == model.SelectedSedeId);
                    aula.Sede = sede;
                }
                aula.Descripcion = model.Descripcion;
                aula.Cupo = model.Cupo;
                aula.Estado = model.Estado;
                db.Entry(aula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Aulas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aula aula = db.Aulas.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View(aula);
        }

        // POST: Aulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aula aula = db.Aulas.Find(id);
            db.Aulas.Remove(aula);
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

        private IEnumerable<SelectListItem> GetSedes()
        {
            var sedes = db.Sedes.ToList()
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.Id.ToString(),
                                    Text = x.Descripcion
                                });

            return new SelectList(sedes, "Value", "Text");
        }
    }
}
