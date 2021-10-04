using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entity = DL.Entities;
using Xunit;
using DL;
using Models;


namespace Tests
{
    public class DBTests
    {
        private readonly DbContextOptions<Entity.ProjZeroONeContext> options; //DbContextOptions<Entity.Customer> options;
        public DBTests()
        {
            options = new DbContextOptionsBuilder<Entity.ProjZeroONeContext>()
                    .UseSqlite("Filename=Test.db").Options;
            Seed();
        }


        [Fact]

        public void GetCustomersShouldGetCustomers()
        {
            using (var context = new Entity.ProjZeroONeContext(options))
            {
                IRep repo = new DBRep(context);

                var customers = repo.GetCustomers();

                Assert.Equal(2, customers.Count);

            }
        }

        [Fact]

        public void AddCustomerShouldAddCustomer()
        {
            using (var context = new Entity.ProjZeroONeContext(options))
            {
                IRep repo = new DBRep(context);
                Models.Customers addCust = new Models.Customers()
                {
                    Id = 3,
                    Name = "George",
                    Email = "Orwell1984@gmail.com"
                };
                repo.AddCustomers(addCust);
            }
            using (var context = new Entity.ProjZeroONeContext(options))
            {
                Entity.Customer cust = context.Customers.FirstOrDefault(r => r.Id == 3);
                Assert.NotNull(cust);
                Assert.Equal(cust.Name, "George");
                Assert.Equal(cust.Email, "Orwell1984@gmail.com");
                

            }
        }



        private void Seed()
        {
            using (var context = new Entity.ProjZeroONeContext(options))
            {
                //check db clean state
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.AddRange(
                    new Entity.Customer()
                    {
                        Id = 1,
                        Name = "Mary",
                        Email = "Mary.Lamb@gmail.com"
                    },

                    new Entity.Customer()
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
