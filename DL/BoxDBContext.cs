using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace DL
{
    public class BoxDBContext : DbContext
    {
        public BoxDBContext() : base() { }
        public BoxDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ShopOrder> ShopOrders { get; set; }
        public  DbSet<Product> Products { get; set; }
        public  DbSet<LineItem> LineItems { get; set; }


    }
}
