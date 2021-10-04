using System.Collections.Generic;
using Models;
using DL;

namespace StoreBL
{
    public interface BLI
    {
        Customer AddCustomers(Customer cust);
        List<Customer> GetCustomers();
        List<Customer> SearchACustomer(string queryStr);
        Customer GetCustomerById(int id);
        Customer UpdateCust(Customer custToUpdate);
        Product AddProduct(Product prod);
        List<Product> ViewProducts(string queryStr);
        Product GetProdById(int id);
        Product UpdateItem(Product itemToUpdate);
        List<Product> GetInventory();
        ShopOrder AddOrder(ShopOrder order);
        List<ShopOrder> SearchForOrder(string queryStr);
        ShopOrder GetOrderById(int id);
        List<ShopOrder> GetAllOrders();
        LineItem AddLineItem(LineItem lineItem);
    }
        
}