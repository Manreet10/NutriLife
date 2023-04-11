using Microsoft.AspNetCore.Mvc;
using NutriInfo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriInfoTest
{
    [TestClass]
    public class  HomeControllerTest
    {
        private HomeController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange - setting up the data for the test
            controller = new HomeController();
        }

        [TestMethod]
        public void IndexIsNotNull()
        {
            // Act - actually doing the action that we're testing
            var result = controller.Index();

            // Assert - checking if the result is what we expect
            Assert.IsNotNull(result);
        }
    }
}
