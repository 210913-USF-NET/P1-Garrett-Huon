using System;
using StoreBL;
using System.Collections.Generic;
using Model = Models;
using Entity = DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UI
{
    public class CheckoutMenu : IMenu
    {
        private static int Add(int x, int y) { return x + y; }
        private BLI _bl;
        public CheckoutMenu(BLI bl)
        {
            _bl = bl;
        }

        public void Start()
        {
            bool exit = false;
            do
            {
            Console.WriteLine("[1] Proceed to Payment");
            Console.WriteLine("[x] Back");
            
            
            string input = Console.ReadLine();
            switch(input)
            {
            case "1":
            Model.ShopOrder newOrder = new Model.ShopOrder();
            Console.WriteLine("Enter Your Name");
            newOrder.CName = Console.ReadLine();
            Console.WriteLine("Please Enter your Address");
            newOrder.Address = Console.ReadLine();
            Console.WriteLine("City");
            newOrder.City = Console.ReadLine();
            Console.WriteLine("State");
            newOrder.State = Console.ReadLine();
            Console.WriteLine("How Would You Like to Pay?");
            newOrder.Payment = Console.ReadLine();


           List<Model.Product> allInv = _bl.GetInventory();
            List<Model.LineItem> lineInv = _bl.GetLineItem();
            List<string> cart = Model.TempCart.Tcart();

            var TotalOrder = from c1 in allInv
                            join c2 in lineInv on c1.Id equals c2.ProdId
                select new { 
                    c2.ProdId,
                    c2.Quant,
                    c1.ProdPrice,
                    c2.Id
                };


              foreach(var item in TotalOrder)
              {
                  decimal totalPrice = item.ProdPrice*item.Quant;
                  Console.WriteLine(totalPrice);
                  newOrder.LineItemId = item.Id;
              }

            
            Console.WriteLine("Please Enter Amount Owed");
            newOrder.Cost = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Thank You for Shopping");
            Model.ShopOrder nOrder = _bl.AddOrder(newOrder);
            break;
            case "x":
            exit = true;
            break;
            }
            }while(!exit);
        }
               

        
    }
}