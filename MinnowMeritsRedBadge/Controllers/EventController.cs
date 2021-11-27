using MMRB.Models;
using MMRB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinnowMeritsRedBadge.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            var service = new EventService();
            var model = service.GetEvents();

            return View(model);
        }


        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateEventService();
            if (service.CreateEvent(model))
            {
                TempData["SaveResult"] = "Event Created!";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Event could not be created.");
            return View(model);

        }

        // GET: Event/Details/5
        public ActionResult Details(int eventId)
        {
            var svc = CreateEventService();
            var model = svc.GetEventById(eventId);

            return View(model);
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int eventId)
        {
            var service = CreateEventService();
            var detail = service.GetEventById(eventId);
            var model =
                new EventEdit
                {
                    EventId = detail.EventId,
                    Title = detail.Title,
                    Description = detail.Description,
                    Price = detail.Price
                };

            return View(model);
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int eventId, EventEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EventId != eventId)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateEventService();

            if (service.UpdateEvent(model))
            {
                TempData["SaveResult"] = "Your event was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Sorry, your event could not be updated.");
            return View(model);
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int eventId)
        {
            var svc = CreateEventService();
            var model = svc.GetEventById(eventId);

            return View(model);
        }

        // POST: Event/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEvent(int eventId)
        {
            var service = CreateEventService();

            service.DeleteEvent(eventId);

            TempData["SaveResult"] = "Your event was deleted";

            return RedirectToAction("Index");
        }

        public static EventService CreateEventService()
        {
            return new EventService();
        }


    }
}
