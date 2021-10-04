using System;
using StoreBL;
using Models;
using System.Collections.Generic;


namespace UI
{
    public class HistoryMenu : IMenu
    {
        private BLI _bl;
        private ShoppesService _shoppeservice;

        public HistoryMenu(BLI bl, ShoppesService shoppeservice)
        {
            _bl = bl;
            _shoppeservice = shoppeservice;

        }
        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("Here is your shopping history");
                Console.WriteLine("[1] View All Customers");
                Console.WriteLine("[2] Search Customer");
                Console.WriteLine("[3] View All Orders");
                Console.WriteLine("[4] Search Order");

                Console.WriteLine("[x] Back to Main Menu");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                    ViewCustomerList(); 
                    break;

                    case "2":
                    SearchCustomer();
                    break;

                    case "3":
                    ViewOrderList();
                    break;

                    case "4":
                    SearchForOrder();
                    break;

                    case "x":
                    exit = true;
                    break;
                }
            }while (!exit);
        }

        private void ViewCustomerList()
        {
            List<Customers> allCust = _bl.GetCustomers();
            if(allCust.Count == 0)
            {
                Console.WriteLine("No Customers");
            }
            else
            {
                foreach (Customers cust in allCust)
                {
                    Console.WriteLine(cust.ToString());
                }
            }
        }

        private void SearchCustomer()
        {
            //First, I'm going to ask for user to gimme a search term to search for
            //once they select the restaurant
            //I'm going to grab the restaurant
            //and its reviews and display them to user
            Console.WriteLine("Search for Customer");
            List<Customers> searchResult = _bl.SearchACustomer(Console.ReadLine());
            if(searchResult == null || searchResult.Count == 0)
            {
                Console.WriteLine("No one like that exists in this system.");
                return;
            }
            Customers selectedCustomer = _shoppeservice.SelectACustomer("Pick Customer", searchResult);

            selectedCustomer = _bl.GetCustomerById(selectedCustomer.Id);
            Console.WriteLine(selectedCustomer);
            
            
        }

        private void SearchForOrder()
        {
            //First, I'm going to ask for user to gimme a search term to search for
            //once they select the restaurant
            //I'm going to grab the restaurant
            //and its reviews and display them to user
            Console.WriteLine("Search for Order");
            List<ShopOrder> searchResult = _bl.SearchForOrder(Console.ReadLine());
            if(searchResult == null || searchResult.Count == 0)
            {
                Console.WriteLine("No one like that exists in this system.");
                return;
            }
            ShopOrder selectedOrder = _shoppeservice.SelectOrder("Pick Customer", searchResult);

            selectedOrder = _bl.GetOrderById(selectedOrder.Id);
            Console.WriteLine(selectedOrder);
            
            
        }

        private void ViewOrderList()
        {
            List<ShopOrder> allOrders = _bl.GetAllOrders();
            if(allOrders.Count == 0)
            {
                Console.WriteLine("No Orders");
            }
            else
            {
                foreach (ShopOrder order in allOrders)
                {
                    Console.WriteLine(order.ToString());
                }
            }
        }

    }
}