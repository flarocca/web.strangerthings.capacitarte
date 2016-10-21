using Capacitarte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Capacitarte.Controllers
{
    public class InstructorController : Controller
    {
        private List<Instructor> _instructors;

        // GET: Instructor
        public ActionResult Index()
        {
            ViewBag.Instructors = GetInstructors();

            return View();
        }

        // GET: Instructor
        public ActionResult ModifyInstructor(int idInstructor)
        {
            ViewBag.Instructor = GetInstructors().Find((instructor) => instructor.Id == idInstructor);
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Modify(ModifyInstructorViewModel model, string returnUrl)
        {
            return View();
        }

        private List<Instructor> GetInstructors()
        {
            if (_instructors == null)
            {
                _instructors = new List<Instructor>();
                _instructors.Add(new Instructor() { Id = 1, Name = "Facundo La Rocca" });
                _instructors.Add(new Instructor() { Id = 2, Name = "Ezequiel Fridman" });
                _instructors.Add(new Instructor() { Id = 3, Name = "Eduardo Pereyra" });
                _instructors.Add(new Instructor() { Id = 4, Name = "Christian Pereyra" });
                _instructors.Add(new Instructor() { Id = 5, Name = "Leonardo Esteves" });
                _instructors.Add(new Instructor() { Id = 6, Name = "Tomas Lopetegui" });
            }

            return _instructors;
        }
    }
}