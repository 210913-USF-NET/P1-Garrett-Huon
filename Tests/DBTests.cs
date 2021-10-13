using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using Entity = DL.Entities;
using Xunit;
using DL;
using Models;


namespace Tests
{
    public class DBTests
    {
        private readonly DbContextOptions<BoxDBContext> options; //DbContextOptions<Entity.Customer> options;
        public DBTests()
        {
            options = new DbContextOptionsBuilder<BoxDBContext>()
                    .UseSqlite("Filename=Test.db").Options;
            Seed();
        }


        [Fact]

        public void GetCustomersShouldGetCustomers()
        {
            using (var context = new BoxDBContext(options))
            {
                IRep repo = new DBRep(context);

                var customers = repo.GetCustomers();

                Assert.Equal(2, customers.Count);

            }
        }

        [Fact]

        public void AddCustomerShouldAddCustomer()
        {
            using (var context = new BoxDBContext(options))
            {
                IRep repo = new DBRep(context);
                Customer addCust = new Customer()
                {
                    Id = 3,
                    Name = "George",
                    Email = "Orwell1984@gmail.com"
                };
                repo.AddCustomers(addCust);
            }
            using (var context = new BoxDBContext(options))
            {
                Customer cust = context.Customers.FirstOrDefault(r => r.Id == 3);
                Assert.NotNull(cust);
                Assert.Equal("George",cust.Name );
                Assert.Equal("Orwell1984@gmail.com", cust.Email);
                

            }
        }

        [Fact]

        public void AddProductShouldAddProduct()
        {
            using (var context = new BoxDBContext(options))
            {
                IRep repo = new DBRep(context);
                Product addProd = new Product()
                {
                    Id = 3,
                    ProdName = "Dora Mini Suitcase",
                    ProdPrice = (decimal)35.99,
                    ProdStock = 32,
                    StoreId = 3,
                };
                repo.AddProduct(addProd);
            }
            using (var context = new BoxDBContext(options))
            {
                Product prod = context.Products.FirstOrDefault(r => r.Id == 3);
                Assert.NotNull(prod);
                Assert.Equal("Dora Mini Suitcase", prod.ProdName);
                Assert.Equal((decimal)35.99, prod.ProdPrice);
                Assert.Equal(32, prod.ProdStock);
                Assert.Equal(3, prod.StoreId);

            }
        }

        private void Seed()
        {
            using (var context = new BoxDBContext(options))
            {
                //check db clean state
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.AddRange(
                    new Customer()
                    {
                        Id = 1,
                        Name = "Mary",
                        Email = "Mary.Lamb@gmail.com"
                    },

                    new Customer()
                    {
                        Id = 2,
                        Name = "Clark",
                        Email = "SPMan@dailyplanet.com"
                    }

                );

                context.Stores.AddRange(
                    new Store()
                    {
                        Id = 2,
                        Name = "Faker2",
                        Email = "fake@gfake.com",
                        Address = "123 fake st",
                        City = "faketropolix",
                        State = "Montana"
                    },

                     new Store()
                     {
                         Id = 4,
                         Name = "Faker4",
                         Email = "fake4@gfake.com",
                         Address = "1234 fake st",
                         City = "faketropolix",
                         State = "Montana"
                     },

                     new Store()
                     {
                         Id = 3,
                         Name = "Faker3",
                         Email = "fake4@gfake.com",
                         Address = "12343 fake st",
                         City = "faketropolix",
                         State = "Montana"
                     }

                    );

                context.Products.AddRange(
                    new Product()
                    {
                        Id = 1,
                        ProdName = "Legit 6x4x8",
                        ProdPrice = (decimal)7.69,
                        ProdStock = 65,
                        StoreId = 2,
                    },

                    new Product()
                    {
                        Id = 2,
                        ProdName = "24gal Clear Storage Bin",
                        ProdPrice = (decimal)11.79,
                        ProdStock = 23,
                        StoreId = 4,
                    }
                );
                context.SaveChanges();
            }

            
        }
        


    }
}
