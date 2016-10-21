using Capacitarte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capacitarte.Controllers
{
    public class InstructorController : Controller
    {
        // GET: Instructor
        public ActionResult Index()
        {
            var instructors = new List<Instructor>();
            instructors.Add(new Instructor() { Id = 1, Name = "Facundo La Rocca" });
            instructors.Add(new Instructor() { Id = 2, Name = "Ezequiel Fridman" });
            instructors.Add(new Instructor() { Id = 3, Name = "Eduardo Pereyra" });
            instructors.Add(new Instructor() { Id = 4, Name = "Christian Pereyra" });
            instructors.Add(new Instructor() { Id = 5, Name = "Leonardo Esteves" });
            instructors.Add(new Instructor() { Id = 6, Name = "Tomas Lopetegui" });

            ViewBag.Instructors = instructors;

            return View();
        }
    }
}