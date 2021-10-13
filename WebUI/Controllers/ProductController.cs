using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StoreBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DL;
using Microsoft.AspNetCore.Routing;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {

        private BLI _bl;

        public ProductController(BLI bl)
        {
            _bl = bl;
        }

        // GET: ProductController
        public ActionResult Index(int id)
        {
            Store newStore = new Store(_bl.GetStoreById(id));
            HttpContext.Response.Cookies.Append("getId", id.ToString());
            return View(newStore);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create(string storeId)
        {
            int shopId = int.Parse(storeId);
            ViewBag.Store = _bl.GetStoreById(shopId);
            return View(new Product(shopId));
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.AddProduct(product);
                    return RedirectToAction(nameof(Index), new {id = product.StoreId });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {

            return View(new Product(_bl.GetProdById(id)));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var tempId = HttpContext.Request.Cookies["getId"];
                    product.StoreId = Convert.ToInt32(tempId);
                    _bl.UpdateItem(product);
                    return RedirectToAction(nameof(Index), new { id = product.StoreId });
                }
                return RedirectToAction(nameof(Edit));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Product(_bl.GetProdById(id)));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                _bl.RemoveItem(id);
                return RedirectToAction(nameof(Index), new { id = product.StoreId });
            }
            catch
            {
                return View();
            }
        }
    }
}
