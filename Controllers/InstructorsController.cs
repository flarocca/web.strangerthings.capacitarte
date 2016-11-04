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
using System.Data.Entity.Validation;

namespace Capacitarte.Controllers
{
    public class InstructorsController : Controller
    {
        private CapacitarteContext db = new CapacitarteContext();

        // GET: Instructors
        public ActionResult Index()
        {
            var instructores = db.Usuarios.Include(u => u.Empleado).Where(u => u.Roles.Where(r => r.Rol.Descripcion == "Instructor").Count() > 0).ToList();
            return View(instructores);
        }

        // GET: Instructors/Create
        public ActionResult SelectInstructors()
        {
            var instructores = db.Usuarios.Include(u => u.Empleado)
                          .Where(u => u.Roles.Where(r => r.Rol.Descripcion == "Instructor").Count() > 0).ToList()
                          .Select(u => new InstructorSelectedViewModel() { Descripcion = u.Empleado.ToString(), Selected = true, Usuario_ID = u.Id }).ToList();

            var noInstructores = db.Usuarios.Include(u => u.Empleado)
                          .Where(u => u.Roles.Where(r => r.Rol.Descripcion == "Instructor").Count() == 0).ToList()
                          .Select(u => new InstructorSelectedViewModel() { Descripcion = u.Empleado.ToString(), Selected = false, Usuario_ID = u.Id }).ToList();

            var model = new List<InstructorSelectedViewModel>();
            model.AddRange(instructores);
            model.AddRange(noInstructores);
            model.OrderBy(i => i.Descripcion);

            return View(model);
        }

        // POST: Instructors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectInstructors(int[] selectedUsers)
        {
            var usuarios = db.Usuarios.Include(u => u.Empleado).Include(u => u.Roles).Include(u => u.Roles.Select(r => r.Rol)).ToList();
            foreach (var usuario in usuarios)
            {
                if (ExistIn(usuario.Id, selectedUsers))
                {
                    if (usuario.Roles.Where(u => u.Rol.Descripcion == "Instructor").Count() == 0)
                    {
                        usuario.Roles.Add(new RolPorUsuario() { Usuario = usuario, Rol = GetRolInstructor() });
                        db.Entry(usuario).State = EntityState.Modified;
                    }
                }
                else
                {
                    if (usuario.Roles.Where(u => u.Rol.Descripcion == "Instructor").Count() > 0)
                    {
                        var rol = usuario.Roles.Find(r => r.Rol.Descripcion == "Instructor");
                        usuario.Roles.Remove(rol);
                        db.Entry(usuario).State = EntityState.Modified;
                    }
                }
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private Rol GetRolInstructor()
        {
            Rol rol = null;

            foreach (var item in db.Roles.ToList())
            {
                if (item.Descripcion == "Instructor")
                    rol = item;
            }

            return rol;
        }

        private bool ExistIn(int id, int[] ids)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i] == id)
                    return true;
            }
            return false;
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
