using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreBL;
using Models;
using DL;
using Serilog;

namespace WebUI.Controllers
{
   
    public class CustomerController : Controller
    {
        private BLI _bl;

        public CustomerController(BLI bl)
        {
            _bl = bl;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            List<Customer> allCust = _bl.GetCustomers();
            return View(allCust);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    List<Customer> checkList = _bl.GetCustomers();
                    bool check = checkList.Exists(x =>x.Name == customer.Name && x.Email == customer.Email);
                    if(check == false)
                    {
                    _bl.AddCustomers(customer);
                    Log.Information("New Customer {customer} has been added.");
                    HttpContext.Response.Cookies.Append("CustUser", customer.Id.ToString());
                    HttpContext.Response.Cookies.Append("CustName", customer.Name);

                    }
                    if (check == true)
                    {
                        HttpContext.Response.Cookies.Append("CustUser", customer.Id.ToString());
                        HttpContext.Response.Cookies.Append("CustName", customer.Name);
                        return RedirectToAction("Index", "Home");
                    }
                }
                
                return View();
                
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Customer(_bl.GetCustomerById(id)));
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.UpdateCust(customer);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Edit));
            }
            catch
            {
                return RedirectToAction(nameof(Edit));
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
