using Models;
using System.Collections.Generic;

namespace DL
{
    public interface IRep
    {
        //Customer Methods//
        Customer AddCustomers(Customer cust);
        List<Customer> GetCustomers();
        
        List<Customer> SearchACustomer(string queryStr);
        Customer GetCustomerById(int id);
        Customer UpdateCust(Customer custToUpdate);
        void RemoveCustomer(int id);

         Product AddProduct(Product prod);

        //Product Methods//
        Store AddStore(Store store);
        List<Store> GetStores();
        Store GetStoreById(int id);
        Store Updatestore(Store storeUpdate);
        void RemoveStore(int id);
        List<Product> ViewProducts(string queryStr);

         Product GetProdById(int id);
         Product UpdateItem(Product itemToUpdate);

         List<Product> GetInventory();
        void RemoveItem(int id);

        //OrderMethods//
        ShopOrder AddOrder(ShopOrder order);

         List<ShopOrder> SearchForOrder(string queryStr);

         ShopOrder GetOrderById(int id);
         List<ShopOrder> GetAllOrders();
        LineItem AddLineItem(LineItem lineItem);
        List<LineItem> GetLineItems();
    }
}