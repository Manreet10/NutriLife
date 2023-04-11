using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriInfo.Controllers;
using NutriInfo.Data;
using NutriInfo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using NuGet.ContentModel;


namespace NutriInfoTest
{
    [TestClass]
    public class FoodsControllerTest
    {
        private ApplicationDbContext _context;

        private FoodsController _controller;

        private List<Food> _foods = new List<Food>();
        private Diet _diet;


        [TestInitialize]
        public void TestInitialize()
        {
            //Mocking db
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(dbOptions);

            //mock diet data
            _diet = new Diet
            {
                DietId = 1,
                Name = "Mock Diet",
                Benefit = "Mock Benefit",
                DifficultLevel = 1,
                Foods =  new List<Food>                         // data is later used to reference for foods table mock data
                {
                     new Food { Name = "Apple", RichIn = "Fiber" },
                     new Food { Name = "Salmon", RichIn = "Omega-3" },
                     new Food { Name = "Broccoli", RichIn = "Vitamin C" }
                }
            };

            //add mock data to mock db for diet
            _context.Diets.Add(_diet);

            _context.SaveChanges();

            // retrieve the Diet object with its associated Foods using Include
            _diet = _context.Diets
                           .Include(d => d.Foods)
                           .FirstOrDefault(d => d.DietId == _diet.DietId);

            // assign the Foods to the _foods list
            _foods = _diet.Foods.ToList();    //reference to data using fk in diet table

            //foods controller is set to use mock db
            _controller = new FoodsController(_context);

            
        }

        //Test for the part that returns the view
        [TestMethod]
        public void Create_ReturnsViewResult()
        {
            // Act
            var result = _controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
            var categorySelectList = result.ViewData["DietId"] as SelectList;
            Assert.IsNotNull(categorySelectList);
        }

        //test for part where it sets data for diet id
        [TestMethod]
        public void Create_SetsViewDataDietId()
        {
            // Act
            var result = (ViewResult)_controller.Create();

            // Assert
            var viewData = result.ViewData;
            Assert.IsNotNull(viewData["DietId"]);
        }


        // checks for settings dietId to selectList
        //failing for expected value is 1 and returned is null, it is not correctly setting the selected list to the type of diet the food is for 
        [TestMethod]
        public void Create_SetsViewDataDietIdToSelectList()
        {
            // Act
            var result = (ViewResult)_controller.Create();

            // Assert
            var viewData = result.ViewData;
            var dietIdSelectList = viewData["DietId"] as SelectList;
            Assert.IsNotNull(dietIdSelectList);
            Assert.AreEqual(_diet.DietId, dietIdSelectList.SelectedValue);
        }
       
        







    }
}