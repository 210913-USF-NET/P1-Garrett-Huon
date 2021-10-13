using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Serilog;
using StoreBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class StoreController : Controller
    {
        private BLI _bl;

        public StoreController(BLI bl)
        {
            _bl = bl;
        }


        // GET: StoreController
        public ActionResult Index()
        {
            List<Store> allStores = _bl.GetStores();
            return View(allStores);
        }

        // GET: StoreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Store store)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.AddStore(store);
                    Log.Information($"The store {store} was created");
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Store(_bl.GetStoreById(id)));
        }

        // POST: StoreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Store store)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.Updatestore(store);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Store(_bl.GetStoreById(id)));
        }

        // POST: StoreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _bl.RemoveStore(id);
                Log.Information($"Store with ID {id} was removed");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
