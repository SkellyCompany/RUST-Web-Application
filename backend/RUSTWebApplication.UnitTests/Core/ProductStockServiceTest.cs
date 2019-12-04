using System;
using Moq;
using RUSTWebApplication.Core.ApplicationService;
using RUSTWebApplication.Core.ApplicationService.Services;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;
using Xunit;

namespace RUSTWebApplication.UnitTests.Core
{
    public class ProductStockServiceTest
    {
        [Fact]
        public void Create_ProductStockValid_ReturnsCreatedProductStockWithId()
        {
            //Arrange
            ProductStock validProductStock = new ProductStock
            {
                Product = new Product { Id = 5 },
                ProductSize = new ProductSize { Id = 3},
                Quantity = 120
            };
            ProductStock expected = new ProductStock
            {
                Id = 1,
                Product = new Product { Id = 5 },
                ProductSize = new ProductSize { Id = 3 },
                Quantity = 120
            };

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.Create(validProductStock)).
                Returns(expected);
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Read(5)).
                Returns(validProductStock.Product);
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(3)).
                Returns(validProductStock.ProductSize);

            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            ProductStock actual = productStockService.Create(validProductStock);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Create_ProductStockNull_ThrowsArgumentNullException()
        {
            //Arrange
            ProductStock invalidProductStock = null;

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            Action actual = () => productStockService.Create(invalidProductStock);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Create_IdSpecified_ThrowsArgumentException()
        {
            //Arrange
            ProductStock invalidProductStock = new ProductStock
            {
                Id = 5,
                Product = new Product { Id = 5 },
                ProductSize = new ProductSize { Id = 3 },
                Quantity = 120
            };

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            Action actual = () => productStockService.Create(invalidProductStock);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_ProductNull_ThrowsArgumentException()
        {
            //Arrange
            ProductStock invalidProductStock = new ProductStock
            {
                Id = 5,
                Product = null,
                ProductSize = new ProductSize { Id = 3 },
                Quantity = 120
            };

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(3)).
                Returns(invalidProductStock.ProductSize);
            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            Action actual = () => productStockService.Create(invalidProductStock);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_NonExistingProduct_ThrowsArgumentException()
        {
            //Arrange
            ProductStock invalidProductStock = new ProductStock
            {
                Id = 5,
                Product = new Product { Id = 5 },
                ProductSize = new ProductSize { Id = 3 },
                Quantity = 120
            };

            Product nullProduct = null;

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Read(5)).
                Returns(nullProduct);
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(3)).
                Returns(invalidProductStock.ProductSize);
            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            Action actual = () => productStockService.Create(invalidProductStock);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_QuantityNegative_ThrowsArgumentException()
        {
            //Arrange
            ProductStock invalidProductStock = new ProductStock
            {
                Id = 5,
                Product = new Product { Id = 5 },
                ProductSize = new ProductSize { Id = 3 },
                Quantity = -50
            };


            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            Action actual = () => productStockService.Create(invalidProductStock);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_ProductSizeNull_ThrowsArgumentException()
        {
            //Arrange
            ProductStock invalidProductStock = new ProductStock
            {
                Id = 5,
                Product = new Product { Id = 5 },
                ProductSize = null,
                Quantity = 120
            };

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Read(5)).
                Returns(invalidProductStock.Product);
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            Action actual = () => productStockService.Create(invalidProductStock);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_NonExistingProductSize_ThrowsArgumentException()
        {
            //Arrange
            ProductStock invalidProductStock = new ProductStock
            {
                Id = 5,
                Product = new Product { Id = 5 },
                ProductSize = new ProductSize { Id = 3 },
                Quantity = 120
            };

            ProductSize nullProductSize = null;

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Read(5)).
                Returns(invalidProductStock.Product);
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(3)).
                Returns(nullProductSize);
            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            Action actual = () => productStockService.Create(invalidProductStock);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Read_ExistingId_ReturnsCountryWithSpecifiedId()
        {
            //Arrange
            int existingId = 12;
            ProductStock expected = new ProductStock
            {
                Id = existingId,
                Product = new Product { Id = 5 },
                ProductSize = new ProductSize { Id = 3 },
                Quantity = 94
            };

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.Read(existingId)).
                Returns(expected);
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();

            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            ProductStock actual = productStockService.Read(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Read_NonExistingId_ReturnsNull()
        {
            //Arrange
            int nonExistingId = 12;
            ProductStock expected = null;

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.Read(nonExistingId)).
                Returns(expected);
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();

            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            ProductStock actual = productStockService.Read(nonExistingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_ProductStockValid_ReturnsUpdatedProductStock()
        {
            //Arrange
            ProductStock validProductStock = new ProductStock
            {
                Id = 10,
                Product = new Product { Id = 5 },
                ProductSize = new ProductSize { Id = 3 },
                Quantity = 120
            };
            ProductStock expected = validProductStock;

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.Read(10)).
                Returns(validProductStock);
            productStockRepository.Setup(repo => repo.Update(validProductStock)).
                Returns(expected);
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Read(5)).
                Returns(validProductStock.Product);
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(3)).
                Returns(validProductStock.ProductSize);

            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            ProductStock actual = productStockService.Create(validProductStock);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_ProductStockNull_ThrowsArgumentNullException()
        {
            //Arrange
            ProductStock invalidProductStock = null;

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            Action actual = () => productStockService.Create(invalidProductStock);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Update_NonExistingId_ThrowsArgumentException()
        {
            //Arrange
            ProductStock nonExistingProductStock = new ProductStock
            {
                Id = 10,
                Product = new Product { Id = 5 },
                ProductSize = new ProductSize { Id = 3 },
                Quantity = 120
            };

            ProductStock expected = null;

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.Read(nonExistingProductStock.Id)).
                Returns(expected);
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Read(5)).
                Returns(nonExistingProductStock.Product);
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(3)).
                Returns(nonExistingProductStock.ProductSize);
            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            Action actual = () => productStockService.Update(nonExistingProductStock);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_ProductNull_ThrowsArgumentException()
        {
            //Arrange
            ProductStock invalidProductStock = new ProductStock
            {
                Id = 5,
                Product = null,
                ProductSize = new ProductSize { Id = 3 },
                Quantity = 120
            };

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.Read(invalidProductStock.Id)).
                Returns(invalidProductStock);
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(3)).
                Returns(invalidProductStock.ProductSize);
            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            Action actual = () => productStockService.Update(invalidProductStock);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_NonExistingProduct_ThrowsArgumentException()
        {
            //Arrange
            ProductStock invalidProductStock = new ProductStock
            {
                Id = 5,
                Product = new Product { Id = 5 },
                ProductSize = new ProductSize { Id = 3 },
                Quantity = 120
            };

            Product nullProduct = null;

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.Read(invalidProductStock.Id)).
                Returns(invalidProductStock);
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Read(5)).
                Returns(nullProduct);
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(3)).
                Returns(invalidProductStock.ProductSize);
            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            Action actual = () => productStockService.Update(invalidProductStock);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_QuantityNegative_ThrowsArgumentException()
        {
            //Arrange
            ProductStock invalidProductStock = new ProductStock
            {
                Id = 5,
                Product = new Product { Id = 5 },
                ProductSize = new ProductSize { Id = 3 },
                Quantity = -50
            };


            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            Action actual = () => productStockService.Update(invalidProductStock);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_ProductSizeNull_ThrowsArgumentException()
        {
            //Arrange
            ProductStock invalidProductStock = new ProductStock
            {
                Id = 5,
                Product = new Product { Id = 5 },
                ProductSize = null,
                Quantity = 120
            };

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.Read(invalidProductStock.Id)).
                Returns(invalidProductStock);
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Read(5)).
                Returns(invalidProductStock.Product);
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            Action actual = () => productStockService.Update(invalidProductStock);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }


        [Fact]
        public void Update_NonExistingProductSize_ThrowsArgumentException()
        {
            //Arrange
            ProductStock invalidProductStock = new ProductStock
            {
                Id = 5,
                Product = new Product { Id = 5 },
                ProductSize = new ProductSize { Id = 3 },
                Quantity = 120
            };

            ProductSize nullProductSize = null;

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.Read(invalidProductStock.Id)).
                Returns(invalidProductStock);
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Read(5)).
                Returns(invalidProductStock.Product);
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(3)).
                Returns(nullProductSize);
            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            Action actual = () => productStockService.Update(invalidProductStock);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

    }
}