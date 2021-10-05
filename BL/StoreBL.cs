using System.Collections.Generic;
using Models;
using DL;
using System;

namespace StoreBL
{
    public class BL : BLI
    {

        private IRep _repo;

        public BL(IRep repo)
        {
            _repo = repo;
        }

        //User/Customer function
        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();
        }

        public Customer AddCustomers(Customer cust)
        {
            return _repo.AddCustomers(cust);
        }
        public List<Customer> SearchACustomer(string queryStr)
        {
            return _repo.SearchACustomer(queryStr);
        }

        public Customer GetCustomerById(int id)
        {
            return _repo.GetCustomerById(id);

        }

        public Customer UpdateCust(Customer custToUpdate)
        {
            return _repo.UpdateCust(custToUpdate);
        }

        //Products and Items

        public Store AddStore(Store store)
        {
            return _repo.AddStore(store);
        }
        public List<Store> GetStores()
        {
            return _repo.GetStores();
        }

        public Store GetStoreById(int id)
        {
            return _repo.GetStoreById(id);
        }

        public Product AddProduct(Product prod)
        {
            return _repo.AddProduct(prod);
        }

        public List<Product> ViewProducts(string queryStr)
        {
            return _repo.ViewProducts(queryStr);
        }

        public Product GetProdById(int id)
        {
            return _repo.GetProdById(id);

        }

        public Product UpdateItem(Product itemToUpdate)
        {
            return _repo.UpdateItem(itemToUpdate);
        }

        

        public List<Product> GetInventory()
        {
            return _repo.GetInventory();
        }

        public ShopOrder AddOrder(ShopOrder order)
        {
            return _repo.AddOrder(order);
        }

        public LineItem AddLineItem(LineItem lineItem)
        {
            return _repo.AddLineItem(lineItem);
        }

        public List<ShopOrder> SearchForOrder(string queryStr)
        {
            return _repo.SearchForOrder(queryStr);
        }

        public ShopOrder GetOrderById(int id)
        {
            return _repo.GetOrderById(id);
        }

        public List<ShopOrder> GetAllOrders()
        {
            return _repo.GetAllOrders();
        }
      
    }
}
