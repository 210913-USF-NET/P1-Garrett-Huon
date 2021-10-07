using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class ShopOrderController : Controller
    {
        // GET: ShopOrderController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShopOrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShopOrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopOrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopOrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShopOrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopOrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShopOrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
