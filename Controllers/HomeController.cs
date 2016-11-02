using Capacitarte.DataAccess;
using Capacitarte.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capacitarte.Controllers
{
    public class HomeController : Controller
    {
        private CapacitarteContext db = new CapacitarteContext();

        public ActionResult Index()
        {
            if(TempData["Rol"] != null)
                ViewBag.Rol = TempData["Rol"].ToString();

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
    }
}