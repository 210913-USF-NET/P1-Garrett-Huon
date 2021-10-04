using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DL;
using Models;
using Microsoft.EntityFrameworkCore;
using WebUI.Controllers;
using Moq;
using StoreBL;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class ControllerTests
    {
        [Fact]
        public void CustomerIndexShouldReturnList()
        {
            var mockBL = new Mock<BLI>();
            mockBL.Setup(x => x.GetCustomers()).Returns(
                new List<Customer>()
                {
                    new Customer()
                    {
                        Id = 1,
                        Name = "Gretchen",
                        Email = "poptartsRfetch@gmail.com"
                    },

                    new Customer()
                    {
                        Id = 2,
                        Name = "Eliza Thornberry",
                        Email = "justwildin98@gmail.com"
                    }

                }

            );
            var controller = new CustomerController(mockBL.Object);
            var result = controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Customer>>(viewResult.Model);
            Assert.Equal(2, model.Count());
        }
    }
}
