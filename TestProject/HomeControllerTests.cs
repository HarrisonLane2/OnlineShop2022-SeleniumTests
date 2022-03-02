using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineShop2022.Controllers;
using OnlineShop2022.Data;
using OnlineShop2022.Models;
using System;
using Xunit;

namespace TestProject
{
    public class HomeControllerTests
    {
        private ILogger<HomeController> _logger;
        private AppDbContext _db;

     

        private void CreateMockDB()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _db = new AppDbContext(options);    
            _db.Database.EnsureCreated();

        }

        [Fact]
        public void HomeControllerIndexNotNull()
        {
            //Arrange
            CreateMockDB();
            var controller = new HomeController(_logger, _db);   

            //Act
            var result = controller.Index();

            //Assert
            Assert.NotNull(result);
        }

    }
}
