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
    public class ModelTests
    {
        [Fact]
        public void CustomersShouldCreateCustomer()
        {
       
        Customers test = new Customers();
        
        Assert.NotNull(test);
        
        }

        [Fact]
        public void ProductsShouldMakeProduct()
        {
            Product test = new Product();
            Assert.NotNull(test);
        }

        [Theory]
        [InlineData (-1)]
        public void ProductStockShouldNotBeInvalidNumber(int input)
        {
            Product test = new Product();
            Assert.Throws<InputInvalidException>(() => test.ProdStock = input);
        }
        
    }

    

}