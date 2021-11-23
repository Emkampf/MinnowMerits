﻿using Microsoft.AspNet.Identity;
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
        public ActionResult Edit(int id, WalletEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.WalletId != id)
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

        private WalletService CreateWalletService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WalletService(userId);
            return service;
        }


        // GET: Wallet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Wallet/Delete/5
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
