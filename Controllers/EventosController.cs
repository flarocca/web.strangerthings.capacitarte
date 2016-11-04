using Capacitarte.DataAccess;
using Capacitarte.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System;
using System.Net;

namespace Capacitarte.Controllers
{
    public class EventosController : Controller
    {
        private CapacitarteContext db = new CapacitarteContext();

        // GET: Eventos
        public ActionResult Index()
        {
            var model = db.Eventos.ToList();
            return View(model);
        }

        // GET: Aulas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var evento = db.Eventos.Include(i => i.Instructor).Include(i => i.Instructor.Empleado).Include(e => e.Aula).Include(e => e.Aula.Sede).SingleOrDefault(x => x.Id == id);
            if (evento == null)
                return HttpNotFound();

            return View(evento);
        }

        public ActionResult Create()
        {
            var model = new EventoViewModel()
            {
                AulaList = GetAulas(),
                InstructorList = GetInstructores(),
                FechaInicio = DateTime.Now,
                FechaFin = DateTime.Now.AddDays(1)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Descripcion,FechaInicio,FechaFin,Hora,Costo,Presupuesto,Estado,SelectedAulaId,SelectedInstructorId")] EventoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var aula = db.Aulas.First(s => s.Id == model.SelectedAulaId);
                var instructor = db.Usuarios.First(s => s.Id == model.SelectedInstructorId);
                var evento = new Evento()
                {
                    Descripcion = model.Descripcion,
                    FechaInicio = model.FechaInicio,
                    FechaFin = model.FechaFin,
                    Hora = model.Hora,
                    Costo = model.Costo,
                    Aula = aula,
                    Estado = model.Estado,
                    Presupuesto = model.Presupuesto,
                    Instructor = instructor
                };
                db.Eventos.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Aulas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var evento = db.Eventos.Include(e => e.Aula.Sede).Include(e => e.Instructor.Empleado).ToList().Find(e => e.Id == id);
            if (evento == null)
                return HttpNotFound();

            var model = GetEventoVewModel(evento);

            return View(model);
        }

        // POST: Aulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var evento = db.Eventos.Find(id);
            db.Eventos.Remove(evento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Aulas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var evento = db.Eventos.Include(i => i.Instructor).Include(i => i.Instructor.Empleado).Include(e => e.Aula).Include(e => e.Aula.Sede).SingleOrDefault(x => x.Id == id);
            if (evento == null)
                return HttpNotFound();

            var model = GetEventoVewModel(evento, GetAulas(), GetInstructores());

            return View(model);
        }

        // POST: Aulas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,FechaInicio,FechaFin,Hora,Costo,Presupuesto,Estado,SelectedAulaId,SelectedInstructorId")] EventoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var evento = db.Eventos.Include(i => i.Instructor).Include(i => i.Instructor.Empleado).Include(e => e.Aula).Include(e => e.Aula.Sede).SingleOrDefault(x => x.Id == model.Id);
                if (evento.Aula.Id != model.SelectedAulaId)
                    evento.Aula = db.Aulas.First(a => a.Id == model.SelectedAulaId);

                if (evento.Instructor.Id != model.SelectedInstructorId)
                    evento.Instructor = db.Usuarios.First(i => i.Id == model.SelectedInstructorId);

                evento.Descripcion = model.Descripcion;
                evento.FechaInicio = model.FechaInicio;
                evento.FechaFin = model.FechaFin;
                evento.Hora = model.Hora;
                evento.Costo = model.Costo;
                evento.Estado = model.Estado;
                evento.Presupuesto = model.Presupuesto;
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Eventos
        public ActionResult MyEventsAsUser()
        {
            return View();
        }

        // GET: Eventos
        public ActionResult MyEventsAsInstructor()
        {
            return View();
        }

        // GET: Eventos
        public ActionResult Suscribe()
        {
            return View();
        }

        private IEnumerable<SelectListItem> GetAulas()
        {
            var aulas = db.Aulas.ToList()
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.Id.ToString(),
                                    Text = x.Descripcion
                                });

            return new SelectList(aulas, "Value", "Text");
        }

        private IEnumerable<SelectListItem> GetInstructores()
        {
            var aulas = db.Usuarios.Include(u => u.Empleado).Include(r => r.Roles.Select(x => x.Rol)).ToList()
                .Where(u => u.Roles.Exists(x => x.Rol.Descripcion == "Instructor"))
                .Select(x =>
                    new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Empleado.ToString()
                    });

            return new SelectList(aulas, "Value", "Text");
        }

        private EventoViewModel GetEventoVewModel(Evento evento, IEnumerable<SelectListItem> aulas = null, IEnumerable<SelectListItem> instructores = null)
        {
            return new EventoViewModel()
            {
                AulaList = aulas,
                SelectedAulaId = evento.Aula.Id,
                SelectedAulaText = evento.Aula.ToString(),
                InstructorList = instructores,
                SelectedInstructorId = evento.Instructor.Id,
                SelectedInstructorText = evento.Instructor.ToString(),
                FechaInicio = evento.FechaInicio,
                FechaFin = evento.FechaFin,
                Descripcion = evento.Descripcion,
                Hora = evento.Hora,
                Costo = evento.Costo,
                Presupuesto = evento.Presupuesto,
                Estado = evento.Estado
            };
        }
    }
}