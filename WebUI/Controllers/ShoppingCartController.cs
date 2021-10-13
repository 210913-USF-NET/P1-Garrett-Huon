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
    public class ShoppingCartController : Controller
    {
        private BLI _bl;
        public ShoppingCartController(BLI bl)
        {
            _bl = bl;
        }
        // GET: ShoppingCartController
        public ActionResult Index(int id)
        {
            List<Cart> newCart = _bl.GetCart();
            return View(newCart);
        }

        // GET: ShoppingCartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShoppingCartController/Create
        public ActionResult Create(string prodId)
        {
            int cartProd = int.Parse(prodId);
            ViewBag.Product = _bl.GetProdById(cartProd);
            HttpContext.Response.Cookies.Append("prodId", cartProd.ToString());
            return View(new Cart(cartProd));
        }

        // POST: ShoppingCartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cart cart)
        {
            var prodId = HttpContext.Request.Cookies["prodId"];
            Product newProd = _bl.GetProdById(int.Parse(prodId));
            decimal price = newProd.ProdPrice;
            cart.UnitPrice = price;
            string name = newProd.ProdName;
            cart.Name = name;
            cart.ProdId = int.Parse(prodId);
            cart.UnitTotal = price * cart.Quant;

            try
            {
                if (ModelState.IsValid)
                {
                    _bl.AddtoCart(cart);
                    return RedirectToAction("Index", "Product", new { id = newProd.StoreId });
                }
                
                return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: ShoppingCartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShoppingCartController/Edit/5
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

        // GET: ShoppingCartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Cart(_bl.GetCartItemById(id)));
        }

        // POST: ShoppingCartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Cart cart)
        {
            try
            {
                _bl.RemoveCartItem(id);
                return RedirectToAction("Index", "ShoppingCart");
            }
            catch
            {
                return View();
            }
        }
    }
}
