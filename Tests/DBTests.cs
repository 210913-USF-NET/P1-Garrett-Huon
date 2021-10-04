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

                    new sCustomer()
                    {
                        Id = 2,
                        Name = "Clark",
                        Email = "SPMan@dailyplanet.com"
                    }

                );

                context.SaveChanges();
            }

            
        }
    }
}
