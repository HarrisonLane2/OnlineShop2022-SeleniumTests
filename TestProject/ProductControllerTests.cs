using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineShop2022.Areas.Admin;
using OnlineShop2022.Controllers;
using OnlineShop2022.Data;
using OnlineShop2022.Helpers;
using OnlineShop2022.Models;
using System;
using Xunit;

namespace TestProject
{
    public class ProductControllerTests
    {
        private ILogger<HomeController> _logger;
        private AppDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;
        private Images _images;



        private void CreateMockDB()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _db = new AppDbContext(options);
            _db.Database.EnsureCreated();

        }

        [Fact]
        private async void ProductUpdateProductIdNotEqual()
        {
            //Arrange

            CreateMockDB();
            _images = new Images(_webHostEnvironment);

            ProductController controller = new ProductController(_db, _webHostEnvironment, _images);

            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Product = new ProductModel();
            productViewModel.Product.Description = "Test Product";
            productViewModel.Product.Id = 2;

            //Act

            var result = await controller.Update(2, productViewModel) as NotFoundResult;

            //Assert

            Assert.NotNull(result);
            Assert.Equal("404", result.StatusCode.ToString());


        }

        [Fact]
        private async void ProductUpdateIfNullReturnNotFound()
        {
            //Arrange

            CreateMockDB();
            _images = new Images(_webHostEnvironment);

            ProductController controller = new ProductController(_db, _webHostEnvironment, _images);

            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Product = new ProductModel();
            productViewModel.Product.Description = "Test Product";
            productViewModel.Product.Id = 2;

            //Act

            var result = await controller.Update(null) as NotFoundResult;

            //Assert

            Assert.NotNull(result);
            Assert.Equal("404", result.StatusCode.ToString());
        }


    }
    
}
