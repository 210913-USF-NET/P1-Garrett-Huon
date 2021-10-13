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
    public class ShopOrderController : Controller
    {
        private BLI _bl;
        public ShopOrderController(BLI bl)
        {
            _bl = bl;
        }
            // GET: ShopOrderController
            public ActionResult Index()
        {
            List<ShopOrder> orders = _bl.GetAllOrders();
            return View(orders);
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
        public ActionResult Create(ShopOrder shopOrder)
        {
            try
            { 
                var userId = HttpContext.Request.Cookies["CustUser"];
                shopOrder.CustomerEmail = userId;
                var cost = HttpContext.Request.Cookies["Cost"];
                shopOrder.Cost = Convert.ToDecimal(cost);
                shopOrder = _bl.AddOrder(shopOrder);


                List<Product> updateProd = _bl.GetInventory();
                List<Cart> currentCart = _bl.GetCart();
                foreach (var item in currentCart)
                {
                    LineItem newitem = new LineItem();
                    Product prod = _bl.GetProdById(item.ProdId);
                    newitem.ProdId = prod.Id;
                    newitem.StoreId = prod.StoreId;
                    newitem.Quant = item.Quant;
                    newitem.OrderId = shopOrder.Id;
                    _bl.AddLineItem(newitem);

                    foreach(var thing in updateProd)
                    {
                        if(item.ProdId == thing.Id)
                        {
                            thing.ProdStock -= item.Quant;
                        }
                        _bl.UpdateItem(thing);
                    }

                }
                foreach (var trash in currentCart)
                {
                    _bl.RemoveCartItem(trash.Id);
                }
                
               shopOrder.LineList = _bl.GetLineByOrderId((int)shopOrder.Id);

                
               return RedirectToAction("Index", "Store");
                
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
