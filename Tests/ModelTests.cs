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
    public class ModelTests
    {
        [Fact]
        public void CustomersShouldCreateCustomer()
        {
       
        Customer test = new Customer();
        
        Assert.NotNull(test);
        
        }

        [Theory]
        [InlineData("jerry123.com")]
        [InlineData("jerry23@gmail")]
        public void CustomerEmailShouldBeValid(string input)
        {
            Customer test = new Customer();
            Assert.Throws<InputInvalidException>(() => test.Email = input);
        }

        [Fact]
        public void ProductsShouldMakeProduct()
        {
            Product test = new Product();
            Assert.NotNull(test);
        }

        [Theory]
        [InlineData (-1)]
        [InlineData(1.5)]
        public void ProductStockShouldNotBeInvalidNumber(int input)
        {
            Product test = new Product();
            Assert.Throws<InputInvalidException>(() => test.ProdStock = input);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void ProductPriceShouldNotBeInvalidNumber(int input)
        {
            Product test = new Product();
            Assert.Throws<InputInvalidException>(() => test.ProdPrice = input);
        }

    }

    

}