using MMRB.Models;
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
            var model = new WriteUpListItem[0];
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
        public ActionResult Create(TransactionCreate model)
        {
            if (ModelState.IsValid)
            {
            }
            return View(model);
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
