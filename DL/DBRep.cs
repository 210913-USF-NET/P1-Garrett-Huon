using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Models;
//using Entity = DL.Entities;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class DBRep : IRep
    {
        private BoxDBContext _context;
        public DBRep(BoxDBContext context)
        {
            _context = context;
        }



        //Customer Services///
        
        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="cust"></param>
        /// <returns>Model.Customers</returns>
        public Customer AddCustomers(Customer cust)
        {
            Customer custAdd = new Customer()
            {
                Name = cust.Name,
                Email = cust.Email ?? ""
            };
            custAdd = _context.Add(custAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Customer()
            {
                Id = custAdd.Id,
                Name = custAdd.Name,
                Email = custAdd.Email
            };
        }
        /// <summary>
        /// Get List of Customers
        /// </summary>
        /// <returns>All Customers</returns>
        public List<Customer> GetCustomers()
        {
            return _context.Customers.Select(
                customer => new Customer()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email


                }
            ).ToList();

        }
        public List<Customer> SearchACustomer(string queryStr)
        {
            return _context.Customers.Where(
                cust => cust.Name.Contains(queryStr) || cust.Email.Contains(queryStr)
            ).Select(
                r => new Customer()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Email = r.Email

                }
            ).ToList();
        }

        public Customer GetCustomerById(int id)
        {
            Customer custById =
                _context.Customers
                .FirstOrDefault(r => r.Id == id);

            return new Customer()
            {
                Id = custById.Id,
                Name = custById.Name,
                Email = custById.Email

            };
        }


        //Product and Store Stuff
        /// <summary>
        /// Create New Product
        /// </summary>
        /// <param name="prod"></param>
        /// <returns>Model.Product</returns>
        public Product AddProduct(Product prod)
        {
            Product prodAdd = new Product()
            {
                Ch = prod.Ch,
                ProdName = prod.ProdName,
                ProdPrice = prod.ProdPrice,
                ProdStock = prod.ProdStock,
                StoreId = prod.StoreId
            };
            prodAdd = _context.Add(prodAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Product()
            {
                Id = prodAdd.Id,
                Ch = prodAdd.Ch,
                ProdName = prodAdd.ProdName,
                ProdPrice = prodAdd.ProdPrice,
                ProdStock = prodAdd.ProdStock,
                StoreId = prodAdd.StoreId
            };
        }

        /// <summary>
        /// Used to get inventory of specific store
        /// </summary>
        /// <param name="queryStr"></param>
        /// <returns>Model.Product specified with Ch value</returns>
        public List<Model.Product> ViewProducts(string queryStr)
        {
            return _context.Products.Where(
                prod => prod.Ch.Contains(queryStr)
            ).Select(
                r => new Model.Product()
                {
                    Id = r.Id,
                    Ch = r.Ch,
                    ProdName = r.ProdName,
                    ProdPrice = r.ProdPrice,
                    ProdStock = r.ProdStock,
                    StoreId = r.StoreId
                }
            ).ToList();
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>All Model.Product</returns>
        public List<Product> GetInventory()
        {
            return _context.Products.Select(
                prod => new Model.Product()
                {
                    Id = prod.Id,
                    Ch = prod.Ch,
                    ProdName = prod.ProdName,
                    ProdPrice = prod.ProdPrice,
                    ProdStock = prod.ProdStock,
                    StoreId = prod.StoreId


                }
            ).ToList();

        }

        public Product GetProdById(int id)
        {
            Product prodById =
                _context.Products
                .FirstOrDefault(r => r.Id == id);

            return new Product()
            {
                Id = prodById.Id,
                Ch = prodById.Ch,
                ProdName = prodById.ProdName,
                ProdPrice = prodById.ProdPrice,
                ProdStock = prodById.ProdStock,
                StoreId = prodById.StoreId

            };
        }

        public Product UpdateItem(Product itemToUpdate)
        {
            Product itemUpdate = new Product()
            {
                Id = itemToUpdate.Id,
                Ch = itemToUpdate.Ch,
                ProdName = itemToUpdate.ProdName,
                ProdPrice = itemToUpdate.ProdPrice,
                ProdStock = itemToUpdate.ProdStock,
                StoreId = itemToUpdate.StoreId
            };

            itemUpdate = _context.Products.Update(itemUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Product()
            {
                Id = itemUpdate.Id,
                Ch = itemUpdate.Ch,
                ProdName = itemUpdate.ProdName,
                ProdPrice = itemUpdate.ProdPrice,
                ProdStock = itemUpdate.ProdStock,
                StoreId = itemUpdate.StoreId
            };
        }
       
    
        /// <summary>
        /// Creates new order
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Model.ShopOrder</returns>

        public ShopOrder AddOrder(ShopOrder order)
        {
            ShopOrder orderAdd = new ShopOrder()
            {
                Address = order.Address,
                City = order.City,
                State = order.State,
                Payment = order.Payment,
                CustomerId = order.CustomerId,
                LineItemId = order.LineItemId,
                Cost = order.Cost
            };
            orderAdd = _context.Add(orderAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.ShopOrder()
            {
                Id = order.Id,
                Address = order.Address,
                City = order.City,
                State = order.State,
                Payment = order.Payment,
                CustomerId = order.CustomerId,
                LineItemId = order.LineItemId,
                Cost = order.Cost
            };
        }



        public List<Model.ShopOrder> SearchForOrder(string queryStr)
        {
            return _context.ShopOrders.Where(
                order =>order.Address.Contains(queryStr)|| order.Payment.Contains(queryStr)|| order.City.Contains(queryStr)|| order.State.Contains(queryStr)
            ).Select(
                r => new Model.ShopOrder()
                {
                    Id = r.Id,
                    Address = r.Address,
                    City = r.City,
                    State = r.State,
                    Payment = r.Payment,
                    CustomerId = Convert.ToInt32(r.CustomerId),
                    LineItemId = Convert.ToInt32(r.LineItemId),
                    Cost = r.Cost

                }
            ).ToList();
        }

        public ShopOrder GetOrderById(int id)
        {
            ShopOrder orderById =
                _context.ShopOrders
                .FirstOrDefault(r => r.Id == id);

            return new ShopOrder()
            {
                    Id = orderById.Id,
                    Address = orderById.Address,
                    City = orderById.City,
                    State = orderById.State,
                    Payment = orderById.Payment,
                    CustomerId = Convert.ToInt32(orderById.CustomerId),
                    LineItemId = Convert.ToInt32(orderById.LineItemId),
                    Cost = orderById.Cost

            };
        }


         public List<ShopOrder> GetAllOrders()
        {
            return _context.ShopOrders.Select(
                ord => new ShopOrder()
                {
                    Id = ord.Id,
                    
                    Address = ord.Address,
                    City = ord.City,
                    State = ord.State,
                    Payment = ord.Payment,
                    CustomerId = Convert.ToInt32(ord.CustomerId),
                    LineItemId = Convert.ToInt32(ord.LineItemId),
                    Cost = ord.Cost


                }
            ).ToList();

        }

        

        //List<Customer> IRep.GetCustomers()
        //{
        //    throw new NotImplementedException();
        //}

        List<Customer> IRep.SearchACustomer(string queryStr)
        {
            throw new NotImplementedException();
        }

        Customer IRep.GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }
    }
}