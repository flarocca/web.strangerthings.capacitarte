using Capacitarte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Capacitarte.Controllers
{
    public class InstructorController : Controller
    {
        private static List<ModifyInstructorViewModel> _instructors;

        // GET: Instructor
        public ActionResult Index()
        {
            ViewBag.Instructors = GetInstructors();

            return View();
        }

        // GET: Instructor
        public ActionResult ModifyInstructor(int? idInstructor)
        {
            if (idInstructor == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var instructor = GetInstructors().Find((instruc) => instruc.Id == idInstructor);
            if (instructor == null)
                return HttpNotFound();

            ViewBag.Instructor = instructor;
            return View(instructor);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Modify(ModifyInstructorViewModel model, string returnUrl)
        {
            var instructor = GetInstructors().Find((instruc) => instruc.Id == model.Id);
            GetInstructors().Remove(instructor);
            GetInstructors().Add(model);

            return RedirectToAction("Index");
        }

        private List<ModifyInstructorViewModel> GetInstructors()
        {
            if (_instructors == null)
            {
                _instructors = new List<ModifyInstructorViewModel>();
                _instructors.Add(new ModifyInstructorViewModel() { Id = 1, Name = "Facundo La Rocca" });
                _instructors.Add(new ModifyInstructorViewModel() { Id = 2, Name = "Ezequiel Fridman" });
                _instructors.Add(new ModifyInstructorViewModel() { Id = 3, Name = "Eduardo Pereyra" });
                _instructors.Add(new ModifyInstructorViewModel() { Id = 4, Name = "Christian Pereyra" });
                _instructors.Add(new ModifyInstructorViewModel() { Id = 5, Name = "Leonardo Esteves" });
                _instructors.Add(new ModifyInstructorViewModel() { Id = 6, Name = "Tomas Lopetegui" });
            }

            return _instructors;
        }
    }
}