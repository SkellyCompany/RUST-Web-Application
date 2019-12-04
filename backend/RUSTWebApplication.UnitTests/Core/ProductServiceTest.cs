using System;
using Moq;
using RUSTWebApplication.Core.ApplicationService;
using RUSTWebApplication.Core.ApplicationService.Services;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;
using Xunit;

namespace RUSTWebApplication.UnitTests.Core
{
    public class ProductServiceTest
    {
        [Fact]
        public void Create_ProductValid_ReturnsCreatedProductWithId()
        {
            //Arrange
            Product validProduct = new Product
            {
                ProductModel = new ProductModel { Id = 2},
                Color = "Black"
            };
            Product expected = new Product
            {
                Id = 1,
                ProductModel = new ProductModel { Id = 2 },
                Color = "Black"
            };

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Create(validProduct)).
                Returns(expected);
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            productModelRepository.Setup(repo => repo.Read(2)).
                Returns(validProduct.ProductModel);

            IProductService productStockService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Product actual = productStockService.Create(validProduct);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
