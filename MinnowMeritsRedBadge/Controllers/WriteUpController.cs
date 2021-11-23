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
    public class WriteUpController : Controller
    {
        // GET: WriteUp
        public ActionResult Index()
        {
            var service = new WriteUpService();
            var model = service.GetWriteUp();

            return View(model);
        }

        // GET: WriteUp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WriteUp/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WriteUpCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateWriteUpService();
            if (service.CreateWriteUp(model))
            {
                TempData["SaveResult"] = "Write-Up Created!";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Write-Up could not be created.");
            return View(model);

        }
        
        public ActionResult Details(int id)
        {
            var svc = CreateWriteUpService();
            var model = svc.GetWriteUpById(id);

            return View(model);
        }

        // GET: WriteUp/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateWriteUpService();
            var detail = service.GetWriteUpById(id);
            var model =
                new WriteUpEdit
                {
                    WriteUpId = detail.WriteUpId,
                    WriteUps = detail.WriteUps
                };
            return View(model);
        }

        // POST: WriteUp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, WriteUpEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.WriteUpId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateWriteUpService();

            if (service.UpdateWriteUp(model))
            {
                TempData["SaveResult"] = "Your write-up was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Sorry, your write-up could not be updated.");
            return View(model);
        }

        private static WriteUpService CreateWriteUpService()
        {
            return new WriteUpService();
        }



        // GET: WriteUp/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WriteUp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
