using System;
using StoreBL;
using System.Collections.Generic;
using Model = Models;
using Entity = DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace UI
{
    public class Plastic : IMenu
    {
        private BLI _bl;
        private ShoppesService _shoppeservice;
        public Plastic(BLI bl, ShoppesService shoppesservice)
        {
            _bl = bl;
            _shoppeservice = shoppesservice;
            
        }
        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("Welcome to Plasticly See Through");
                Console.WriteLine("[1] See Products");
                Console.WriteLine("[2] Add Item(s) to Cart");
                Console.WriteLine("[3] Edit Inventory");
                Console.WriteLine("[x] Back");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                    ViewInventory();
                    break;

                    case "2":
                    break;

                    case "3":
                    EditInventory();
                    break;

                    case "x":
                    exit = true;
                    break;
                }
            }while (!exit);
            

        }


        private void ViewInventory()
        {
            List<Model.Product> setInventory = _bl.ViewProducts("P");
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


    }
}