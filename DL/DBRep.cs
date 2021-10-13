using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Models;
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
             .FirstOrDefault(r => r.Id == id)
             ;

            return new Customer()
            {
                Id = custById.Id,
                Name = custById.Name,
                Email = custById.Email

            };
        }

        public Customer UpdateCust(Customer custToUpdate)
        {
            Customer custUpdate = new Customer()
            {
                Id = custToUpdate.Id,
                Name = custToUpdate.Name,
                Email = custToUpdate.Email
            };

            custUpdate = _context.Customers.Update(custUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Customer()
            {
                Id = custUpdate.Id,
                Name = custUpdate.Name,
                Email = custUpdate.Email
            };
        }

        public void RemoveCustomer(int id)
        {
            Customer c = _context.Customers.FirstOrDefault(x =>x.Id == id);
            _context.Customers.Remove(c);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }


        //Product and Store Stuff

        public Store AddStore(Store store)
        {
            Store storeAdd = new Store()
            {
                Name = store.Name,
                Email = store.Email,
                Address = store.Address,
                City = store.City,
                State = store.State

            };
            storeAdd = _context.Add(storeAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Store()
            {
                Id = storeAdd.Id,
                Name = storeAdd.Name,
                Email = storeAdd.Email,
                Address = storeAdd.Address,
                City = storeAdd.City,
                State = storeAdd.State

            };
        }

        public List<Store> GetStores()
        {
            return _context.Stores
                .Include("Products")
                .Select(
                store => new Store()
                {
                    Id = store.Id,
                    Name = store.Name,
                    Email = store.Email,
                    Address = store.Address,
                    City = store.City,
                    State = store.State
                }
            ).ToList();

        }

        public Store Updatestore(Store storeUpdate)
        {
            Store storetoUpdate = new Store()
            {
                Id = storeUpdate.Id,
                Name = storeUpdate.Name,
                Email = storeUpdate.Email,
                Address = storeUpdate.Address,
                City = storeUpdate.City,
                State = storeUpdate.State
            };

            storetoUpdate = _context.Stores.Update(storetoUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Store()
            {
                Id = storetoUpdate.Id,
                Name = storetoUpdate.Name,
                Email = storetoUpdate.Email,
                Address = storetoUpdate.Address,
                City = storetoUpdate.City,
                State = storetoUpdate.State
            };
        }


        public Store GetStoreById(int id)
        {
               return _context.Stores
                .AsNoTracking()
                .Include(r => r.Products)
                .FirstOrDefault(r => r.Id == id);
        }


        public void RemoveStore(int id)
        {
            _context.Stores.Remove(GetStoreById(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }



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

            return new Product()
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
        public List<Product> ViewProducts(string queryStr)
        {
            return _context.Products.Where(
                prod => prod.Ch.Contains(queryStr)
            ).Select(
                r => new Product()
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
            return _context.Products
                .AsNoTracking()
                .FirstOrDefault(r => r.Id == id);
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

        public void RemoveItem(int id)
        {
            Product c = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Products.Remove(c);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
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
                CustomerEmail = order.CustomerEmail,
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
                CustomerEmail = order.CustomerEmail,
                Cost = order.Cost
            };
        }



        public List<Model.ShopOrder> SearchForOrder(string queryStr)
        {
            return _context.ShopOrders.Where(
                order => order.Address.Contains(queryStr) || order.Payment.Contains(queryStr) || order.City.Contains(queryStr) || order.State.Contains(queryStr)
            ).Select(
                r => new Model.ShopOrder()
                {
                    Id = r.Id,
                    Address = r.Address,
                    City = r.City,
                    State = r.State,
                    Payment = r.Payment,
                    CustomerEmail = r.CustomerEmail,
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
                    CustomerEmail = orderById.CustomerEmail,
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
                    CustomerEmail = ord.CustomerEmail,
                    Cost = ord.Cost


                }
            ).ToList();

        }

        public void RemoveOrder(int id)
        {
            _context.ShopOrders.Remove(GetOrderById(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        /// <summary>
        /// Was used as temp Cart but now adds to Line Item Table
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns>Model.LineItem</returns>
        public LineItem AddLineItem(LineItem lineItem)
        {
            LineItem itemInCart = new LineItem()
            {
                Id = lineItem.Id,
                Quant = lineItem.Quant,
                StoreId = lineItem.StoreId,
                ProdId = lineItem.ProdId
            };
            itemInCart = _context.Add(itemInCart).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new LineItem()
            {
                Id = itemInCart.Id,
                Quant = itemInCart.Quant,
                StoreId = itemInCart.StoreId,
                ProdId = Convert.ToInt32(itemInCart.ProdId)
            };
        }

        public List<LineItem> GetLineItems()
        {
            return _context.LineItems.Select(
                line => new LineItem()
                {
                    Id = line.Id,
                    Quant = line.Quant,
                    StoreId = line.StoreId,
                    ProdId = line.ProdId

                }
            ).ToList();

        }

        public LineItem GetLineById(int id)
        {
            LineItem LineById =
                _context.LineItems
                .FirstOrDefault(r => r.Id == id);

            return new LineItem()
            {
                Id = LineById.Id,
                Quant = LineById.Quant,
                StoreId = LineById.StoreId,
                ProdId = LineById.ProdId

            };
        }

        public List<LineItem> GetLineByOrderId(int id)
        {
            return _context.LineItems.Where(l => l.OrderId == id).Select(i => new LineItem()).ToList();
        }


        public void RemoveLineItem(int id)
        {
            _context.LineItems.Remove(GetLineById(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        public List<Cart> GetCart()
        {
            return _context.Carts.Select(
                cart => new Cart()
                {
                    Id = cart.Id,
                    Name = cart.Name,
                    Quant = cart.Quant,
                    UnitPrice = cart.UnitPrice,
                    UnitTotal = cart.UnitTotal,
                    ProdId = cart.ProdId
                    

                }
            ).ToList();

        }

        public Cart AddtoCart(Cart cart)
        {
            Cart itemInCart = new Cart()
            {
                Id = cart.Id,
                Name = cart.Name,
                Quant = cart.Quant,
                UnitPrice = cart.UnitPrice,
                UnitTotal = cart.UnitTotal,
                ProdId = cart.ProdId
                
            };

            itemInCart = _context.Add(itemInCart).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Cart()
            {
                Id = itemInCart.Id,
                Name = itemInCart.Name,
                Quant = itemInCart.Quant,
                UnitPrice = itemInCart.UnitPrice,
                UnitTotal = itemInCart.UnitTotal,
                ProdId = itemInCart.ProdId
                
            };
        }

        public Cart GetCartItemById(int id)
        {
            Cart cart =
                _context.Carts
                .FirstOrDefault(r => r.Id == id);

            return new Cart()
            {
                Id = cart.Id,
                Name = cart.Name,
                Quant = cart.Quant,
                UnitPrice = cart.UnitPrice,
                UnitTotal = cart.UnitTotal,
                ProdId = cart.ProdId
                

            };
        }

        public void RemoveCartItem(int id)
        {
            Cart c = _context.Carts.FirstOrDefault(x => x.Id == id);
            _context.Carts.Remove(c);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        



    }
}