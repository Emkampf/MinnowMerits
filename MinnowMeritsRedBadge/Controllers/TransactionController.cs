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
            var eventService = EventController.CreateEventService();
            ViewData["EventOptions"] = eventService.GetEvents();
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

        // GET: Transaction/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateTransactionService();
            var detail = service.GetTransactionById(id);
            var model =
                new TransactionEdit
                {
                    TransactionId = detail.TransactionId,
                    ModifiedUtc = detail.ModifiedUtc,
                    TypeTransaction = detail.TypeTransaction,
                    EventId = detail.EventId
                };

            return View(model);
        }

        // POST: Transaction/Edit/5
        [HttpPost]
        public ActionResult Edit(int transactionId, TransactionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TransactionId != transactionId)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTransactionService();

            if (service.UpdateTransaction(model))
            {
                TempData["SaveResult"] = "Your transaction was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Sorry, your transaction could not be updated.");
            return View(model);
        }

        // GET: Transaction/Delete/5
        public ActionResult Delete(int transactionId)
        {
            var svc = CreateTransactionService();
            var model = svc.GetTransactionById(transactionId);

            return View(model);
        }

        // POST: Transaction/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTransaction(int transactionId)
        {
            var service = CreateTransactionService();

            service.DeleteTransaction(transactionId);

            TempData["SaveResult"] = "Your transaction was deleted";

            return RedirectToAction("Index");
        }

        private static TransactionService CreateTransactionService()
        {
            return new TransactionService();
        }
    }
}
