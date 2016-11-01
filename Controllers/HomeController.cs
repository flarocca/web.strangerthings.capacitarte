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
    }
}