using MMRB.Models;
using MMRB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinnowMeritsRedBadge.Controllers
{
    public class WriteUpController : Controller
    {
        // GET: WriteUp
        public ActionResult Index()
        {
            var service = new WriteUpService();
            var model = service.GetWriteUp();

            return View(model);
        }
        /*
                // GET: WriteUp/Details/5
                public ActionResult Details(int id)
                {
                    return View();
                }*/

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
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var service = new WriteUpService();

            service.CreateWriteUp(model);

            return RedirectToAction("Index");
        }

        // GET: WriteUp/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WriteUp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
