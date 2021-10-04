using System;
using StoreBL;
using System.Collections.Generic;
using Model = Models;
using Entity = DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace UI
{
    public class Bags : IMenu
    {
       
        private BLI _bl;
        private ShoppesService _shoppeservice;
        public Bags(BLI bl, ShoppesService shoppesservice)
        {
            _bl = bl;
            _shoppeservice = shoppesservice;
            
            
        }
        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("Welcome to Bag'em Up");
                Console.WriteLine("[1] See Products");
                Console.WriteLine("[2] Add Item(s) to Cart");
                Console.WriteLine("[3] Edit Inventory");
                Console.WriteLine("[4] See Store History");
                Console.WriteLine("[x] Back");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                    ViewInventory();
                    break;

                    case "2":
                    ProdToCart();
                    break;

                    case "3":
                    EditInventory();
                    break;

                    case "4":
                    viewOrders();
                    break;

                    case "x":
                    exit = true;
                    break;
                }
            }while (!exit);
            

        }

        private void ViewInventory()
        {
            List<Model.Product> setInventory = _bl.ViewProducts("B");
            if(setInventory.Count == 0)
            {
                Console.WriteLine("Nothing here");
            }
            else
            {
                foreach(Models.Product product in setInventory)
                Console.WriteLine(product);
            }
            
            

        }
        private void EditInventory()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("[1] Create new Product");
                Console.WriteLine("[2] Restock a Product");
                Console.WriteLine("[3] Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                    CreateProduct();
                    break;

                    case "2":
                    break;

                    case "3":
                    exit = true;
                    break;
                }
            } while (!exit);
        }

        private void CreateProduct()
        {
            Model.Product newProd = new Model.Product();

            Console.WriteLine("Please Enter Item Name");
            newProd.ProdName = Console.ReadLine();

            Console.WriteLine("Identifying Character");
            newProd.Ch = Console.ReadLine();

            Console.WriteLine("Please Enter the Price");
            newProd.ProdPrice = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Please Enter Current Stock");
            newProd.ProdStock = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Store Number");
            newProd.StoreId = Int32.Parse(Console.ReadLine());
            Model.Product addProd = _bl.AddProduct(newProd);
            
        }
        private void ProdToCart()
        {
            
            List<Model.Product> prodToCart = _bl.ViewProducts("B");
            if (prodToCart.Count == 0)
            {
                Console.WriteLine("Nothing here");
            }
            else
            {
                foreach (Models.Product product in prodToCart)
                    Console.WriteLine($"{product.ProdName}{product.ProdPrice}{product.ProdStock}");
            }
            pickprod:
            Model.Product selectedProduct = _shoppeservice.SelectAProduct("Which Item Would You Like?", prodToCart);

            _bl.GetProdById(selectedProduct.Id);
            Console.WriteLine($"How many {selectedProduct.ProdName}(s) would you like?");
            int input = Convert.ToInt32(Console.ReadLine());
            //Model.Product newUpdate = _bl.UpdateItem(selectedProduct);
           if (selectedProduct.ProdStock == 0 || selectedProduct.ProdStock < 0 )
           {
               Console.WriteLine("Sorry! We are out of {selectedProduct}");
               goto pickprod;
           }
           else
           {
               
               Model.LineItem cartItem = new Model.LineItem();
               cartItem.Quant = input;
               cartItem.StoreId = selectedProduct.StoreId;
               cartItem.ProdId = selectedProduct.Id;
               Model.LineItem addItem = _bl.AddItemToCart(cartItem);
               Model.TempCart.Record(Convert.ToString(addItem));
               Console.WriteLine($"You added {input} \n{cartItem} to your cart");
               
           }

        }

        public void viewOrders()
        {
             List<Model.Product> allInv = _bl.GetInventory();
            List<Model.LineItem> lineInv = _bl.GetLineItem();
            List<Model.ShopOrder> orderInv = _bl.GetAllOrders();

            var TotalOrder = from c1 in allInv
                            join c2 in lineInv on c1.Id equals c2.ProdId
                            join c3 in orderInv on c2.Id equals c3.LineItemId
                select new { 
                    c2.ProdId,
                    c2.Quant,
                    c1.ProdPrice,
                    LineItemId = c2.Id,
                    c1.StoreId,
                    OrderId = c3.Id
                    
                };

              foreach(var item in TotalOrder)
              {
                 Console.WriteLine($"Store ID:{item.StoreId == 1}  Product ID:{item.ProdId}  Price:{item.ProdPrice}  Quantity: {item.Quant}  OrderId:{item.OrderId}  LineItemId:{item.LineItemId}");
              }
        }
    }

    
}