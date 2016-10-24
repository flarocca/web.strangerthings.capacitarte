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
    public class EventController : Controller
    {
        private static List<EventViewModel> _events;

        // GET: Event
        public ActionResult Index()
        {
            return View(GetEvents());
        }

        // GET: Event
        public ActionResult Create()
        {
            return View();
        }

        // GET: Event
        public ActionResult Edit(int? idEvent)
        {
            if (idEvent == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var evento = GetEvents().Find((eve) => eve.Id == idEvent);
            if (evento == null)
                return HttpNotFound();

            return View(evento);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEdit(EventViewModel model, string returnUrl)
        {
            var evento = GetEvents().Find((eve) => eve.Id == model.Id);
            GetEvents().Remove(evento);
            GetEvents().Add(model);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCreate(EventViewModel model, string returnUrl)
        {
            GetEvents().Add(model);

            return RedirectToAction("Index");
        }

        private List<EventViewModel> GetEvents()
        {
            if (_events == null)
            {
                _events = new List<EventViewModel>();
                _events.Add(new EventViewModel() { Id = 1, Description = "Evento 1", StartDate = new DateTime(2016, 10, 1), EndDate = new DateTime(2017, 10, 1) });
                _events.Add(new EventViewModel() { Id = 2, Description = "Evento 2", StartDate = new DateTime(2016, 11, 1), EndDate = new DateTime(2017, 11, 1) });
                _events.Add(new EventViewModel() { Id = 3, Description = "Evento 3", StartDate = new DateTime(2016, 12, 1), EndDate = new DateTime(2017, 12, 1) });
                _events.Add(new EventViewModel() { Id = 4, Description = "Evento 4", StartDate = new DateTime(2017, 1, 1), EndDate = new DateTime(2018, 1, 1) });
                _events.Add(new EventViewModel() { Id = 5, Description = "Evento 5", StartDate = new DateTime(2017, 2, 1), EndDate = new DateTime(2018, 2, 1) });
                _events.Add(new EventViewModel() { Id = 6, Description = "Evento 6", StartDate = new DateTime(2017, 3, 1), EndDate = new DateTime(2018, 3, 1) });
            }

            return _events;
        }
    }
}