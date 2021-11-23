using MMRB.Models;
using MMRB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinnowMeritsRedBadge.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            var service = new TransactionService();
            var model = service.GetTransactions();

            return View(model);
        }


        // GET: Transaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateTransactionService();
            if (service.CreateTransaction(model))
            {
                TempData["SaveResult"] = "Transaction Created!";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Transaction could not be created.");
            return View(model);

        }
        // GET: Transaction/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateTransactionService();
            var model = svc.GetTransactionById(id);

            return View(model);
        }

        private static TransactionService CreateTransactionService()
        {
            return new TransactionService();
        }


        // GET: Transaction/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transaction/Edit/5
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

        // GET: Transaction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transaction/Delete/5
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
