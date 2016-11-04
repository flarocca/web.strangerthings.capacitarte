using Capacitarte.DataAccess;
using Capacitarte.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Capacitarte.Controllers
{
    public class HomeController : Controller
    {
        private CapacitarteContext db = new CapacitarteContext();

        public ActionResult Index()
        {
            if (db.Usuarios.ToList().Count() == 0)
                InsertData();

            if (HttpContext.Application["rol"] != null)
                ViewBag.Rol = HttpContext.Application["rol"].ToString();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult InfoForTesting()
        {
            var model = new InfoForTestingViewModel();
            model.Usuarios = db.Usuarios.Include(u => u.Empleado).Include(r => r.Roles).ToList();
            model.Roles = db.Roles.ToList();
            model.Empleados = db.Empleados.ToList();

            return View(model);
        }

        private void InsertData()
        {
            var emp1 = new Empleado()
            {
                Nombre = "Bruce",
                Apellido = "Wayne",
                Direccion = "Sarasa 123, CABA",
                Gerencia = "Seguridad",
                Jefatura = "Seguridad",
                Convenio = "Fuera de C0nvenio"
            };
            var emp2 = new Empleado()
            {
                Nombre = "Homero",
                Apellido = "Simpson",
                Direccion = "Sarasa 123, CABA",
                Gerencia = "Seguridad",
                Jefatura = "Seguridad",
                Convenio = "Fuera de C0nvenio"
            };
            var emp3 = new Empleado()
            {
                Nombre = "Lisa",
                Apellido = "Simpson",
                Direccion = "Sarasa 123, CABA",
                Gerencia = "Seguridad",
                Jefatura = "Seguridad",
                Convenio = "Fuera de C0nvenio"
            };
            var emp4 = new Empleado()
            {
                Nombre = "Clark",
                Apellido = "Kent",
                Direccion = "Sarasa 123, CABA",
                Gerencia = "Seguridad",
                Jefatura = "Seguridad",
                Convenio = "Fuera de C0nvenio"
            };
            var emp5 = new Empleado()
            {
                Nombre = "Peter",
                Apellido = "Parker",
                Direccion = "Sarasa 123, CABA",
                Gerencia = "Seguridad",
                Jefatura = "Seguridad",
                Convenio = "Fuera de C0nvenio"
            };
            var emp6 = new Empleado()
            {
                Nombre = "Frodo",
                Apellido = "Bolson",
                Direccion = "Sarasa 123, CABA",
                Gerencia = "Seguridad",
                Jefatura = "Seguridad",
                Convenio = "Fuera de C0nvenio"
            };
            db.Empleados.Add(emp1);
            db.Empleados.Add(emp2);
            db.Empleados.Add(emp3);
            db.Empleados.Add(emp4);
            db.Empleados.Add(emp5);
            db.Empleados.Add(emp6);
            db.SaveChanges();

            if (db.Roles.Count() >= 0)
                DeleteRoles();

            var rolAlumno = new Rol() { Descripcion = "Alumno" };
            var rolInstructor = new Rol() { Descripcion = "Instructor" };
            var rolGestor = new Rol() { Descripcion = "Gestor" };
            var rolMandoMedio = new Rol() { Descripcion = "MandoMedio" };
            db.Roles.Add(rolAlumno);
            db.Roles.Add(rolInstructor);
            db.Roles.Add(rolGestor);
            db.Roles.Add(rolMandoMedio);
            db.SaveChanges();

            var usr1 = new Usuario()
            {
                Empleado = emp1,
                Username = "usuario1",
                Password = "1234"
            };
            usr1.Roles.Add(new RolPorUsuario() { Rol = rolAlumno, Usuario = usr1 });
            usr1.Roles.Add(new RolPorUsuario() { Rol = rolGestor, Usuario = usr1 });
            usr1.Roles.Add(new RolPorUsuario() { Rol = rolInstructor, Usuario = usr1 });
            usr1.Roles.Add(new RolPorUsuario() { Rol = rolMandoMedio, Usuario = usr1 });
            db.Usuarios.Add(usr1);

            var usr2 = new Usuario()
            {
                Empleado = emp2,
                Username = "usuario2",
                Password = "1234"
            };
            usr2.Roles.Add(new RolPorUsuario() { Rol = rolAlumno, Usuario = usr2 });
            db.Usuarios.Add(usr2);

            var usr3 = new Usuario()
            {
                Empleado = emp3,
                Username = "usuario3",
                Password = "1234"
            };
            usr3.Roles.Add(new RolPorUsuario() { Rol = rolGestor, Usuario = usr3 });
            db.Usuarios.Add(usr3);

            var usr4 = new Usuario()
            {
                Empleado = emp4,
                Username = "usuario4",
                Password = "1234"
            };
            usr4.Roles.Add(new RolPorUsuario() { Rol = rolInstructor, Usuario = usr4 });
            db.Usuarios.Add(usr4);

            var usr5 = new Usuario()
            {
                Empleado = emp5,
                Username = "usuario5",
                Password = "1234"
            };
            usr5.Roles.Add(new RolPorUsuario() { Rol = rolMandoMedio, Usuario = usr5 });
            db.Usuarios.Add(usr5);

            var usr6 = new Usuario()
            {
                Empleado = emp6,
                Username = "usuario6",
                Password = "1234"
            };
            usr6.Roles.Add(new RolPorUsuario() { Rol = rolGestor, Usuario = usr6 });
            usr6.Roles.Add(new RolPorUsuario() { Rol = rolInstructor, Usuario = usr6 });
            db.Usuarios.Add(usr6);
            db.SaveChanges();

            if (db.Sedes.Count() >= 0)
                DeleteSedes();

            var sede1 = new Sede() { Descripcion = "Sede 1" };
            var sede2 = new Sede() { Descripcion = "Sede 2" };
            db.Sedes.Add(sede1);
            db.Sedes.Add(sede2);
            db.SaveChanges();

            if (db.Aulas.Count() >= 0)
                DeleteAulas();

            var aula1 = new Aula() { Sede = sede1, Descripcion = "Aula 1", Cupo = 20, Estado = 1 };
            var aula2 = new Aula() { Sede = sede1, Descripcion = "Aula 2", Cupo = 20, Estado = 1 };
            var aula3 = new Aula() { Sede = sede1, Descripcion = "Aula 3", Cupo = 20, Estado = 1 };
            db.Aulas.Add(aula1);
            db.Aulas.Add(aula2);
            db.Aulas.Add(aula3);
            db.SaveChanges();
        }

        private void DeleteRoles()
        {
            foreach (var item in db.Roles)
                db.Roles.Remove(item);
        }

        private void DeleteSedes()
        {
            foreach (var item in db.Sedes)
                db.Sedes.Remove(item);
        }

        private void DeleteAulas()
        {
            foreach (var item in db.Aulas)
                db.Aulas.Remove(item);
        }
    }
}