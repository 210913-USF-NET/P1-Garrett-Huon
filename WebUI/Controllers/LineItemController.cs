using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StoreBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class LineItemController : Controller
    {
        // GET: LineItemController
        private BLI _bl;
        public LineItemController(BLI bl)
        {
            _bl = bl;
        }
        public ActionResult Index(int id)
        {
            Product newLine = new Product(_bl.GetProdById(id));
            HttpContext.Response.Cookies.Append("prodId", id.ToString());
            return View(newLine);
        }

        // GET: LineItemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LineItemController/Create
        public ActionResult Create(string prodId)
        {
            int prId = int.Parse(prodId);
            ViewBag.Product = _bl.GetProdById(prId);
            return View(new LineItem(prId));
        }

        // POST: LineItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LineItem lineItem)
        {
            var storeId = HttpContext.Request.Cookies["getId"];
            int sId = int.Parse(storeId);
            lineItem.StoreId = sId;
            try
            {

                if (ModelState.IsValid)
                {
                    _bl.AddLineItem(lineItem);
                    return RedirectToAction("Index", "Product", new { id = lineItem.StoreId });
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: LineItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LineItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LineItem lineItem)
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

        // GET: LineItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new LineItem(_bl.GetLineById(id)));
        }

        // POST: LineItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LineItem lineItem)
        {
            try
            {
                _bl.RemoveLineItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
