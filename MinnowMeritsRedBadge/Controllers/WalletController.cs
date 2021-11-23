using Microsoft.AspNet.Identity;
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
    public class WalletController : Controller
    {
        // GET: Wallet
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WalletService(userId);
            var model = service.GetWallets();

            return View(model);
        }

        // GET: Wallet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wallet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WalletCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateWalletService();
            if (service.CreateWallet(model))
            {
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Wallet could not be created.");
                return View(model);

        }
        public ActionResult Details(int id)
        {
            var svc = CreateWalletService();
            var model = svc.GetWalletById(id);

            return View(model);
        }
        // GET: Wallet/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateWalletService();
            var detail = service.GetWalletById(id);
            var model =
                new WalletEdit
                {
                    WalletId = detail.WalletId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    BirthDay = detail.BirthDay
                };

            return View(model);
        }

        // POST: Wallet/Edit/5
        [HttpPost]
        public ActionResult Edit(int walletId, WalletEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.WalletId != walletId)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateWalletService();

            if (service.UpdateWallet(model))
            {
                TempData["SaveResult"] = "Your wallet was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Sorry, your wallet could not be updated.");
            return View(model);
        }



        // GET: Wallet/Delete/5
        public ActionResult Delete(int walletId)
        {
            var svc = CreateWalletService();
            var model = svc.GetWalletById(walletId);

            return View(model);
        }

        // POST: Wallet/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWallet(int walletId)
        {
            var service = CreateWalletService();

            service.DeleteWallet(walletId);

            TempData["SaveResult"] = "Your wallet was deleted";

            return RedirectToAction("Index");
        }

        private WalletService CreateWalletService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WalletService(userId);
            return service;
        }
    }
}
