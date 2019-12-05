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
            productRepository.Setup(repo => repo.Read(validProductStock.Product.Id)).
                Returns(validProductStock.Product);
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(validProductStock.ProductSize.Id)).
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
                Product = null,
                ProductSize = new ProductSize { Id = 3 },
                Quantity = 120
            };

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(invalidProductStock.ProductSize.Id)).
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
        public void Create_ProductNonExisting_ThrowsArgumentException()
        {
            //Arrange
            ProductStock invalidProductStock = new ProductStock
            {
                Product = new Product { Id = 5 },
                ProductSize = new ProductSize { Id = 3 },
                Quantity = 120
            };

            Product nullProduct = null;

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Read(invalidProductStock.Product.Id)).
                Returns(nullProduct);
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(invalidProductStock.ProductSize.Id)).
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
        public void Create_ProductSizeNull_ThrowsArgumentException()
        {
            //Arrange
            ProductStock invalidProductStock = new ProductStock
            {
                Product = new Product { Id = 5 },
                ProductSize = null,
                Quantity = 120
            };

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Read(invalidProductStock.Product.Id)).
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
        public void Create_ProductSizeNonExisting_ThrowsArgumentException()
        {
            //Arrange
            ProductStock invalidProductStock = new ProductStock
            {
                Product = new Product { Id = 5 },
                ProductSize = new ProductSize { Id = 3 },
                Quantity = 120
            };

            ProductSize nullProductSize = null;

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Read(invalidProductStock.Product.Id)).
                Returns(invalidProductStock.Product);
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(invalidProductStock.ProductSize.Id)).
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
        public void Create_QuantityNegative_ThrowsArgumentException()
        {
            //Arrange
            ProductStock invalidProductStock = new ProductStock
            {
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
        public void Read_IdExisting_ReturnsProductSizeWithSpecifiedId()
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
        public void Read_IdNonExisting_ReturnsNull()
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
                Product = null,
                ProductSize = null,
                Quantity = 120
            };
            ProductStock expected = validProductStock;

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.Read(validProductStock.Id)).
                Returns(validProductStock);
            productStockRepository.Setup(repo => repo.Update(validProductStock)).
                Returns(expected);
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Read(validProductStock.Product.Id)).
                Returns(validProductStock.Product);
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(validProductStock.ProductSize.Id)).
                Returns(validProductStock.ProductSize);

            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            ProductStock actual = productStockService.Update(validProductStock);

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
            Action actual = () => productStockService.Update(invalidProductStock);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Update_IdNonExisting_ThrowsArgumentException()
        {
            //Arrange
            ProductStock nonExistingProductStock = new ProductStock
            {
                Id = 10,
                Product = null,
                ProductSize = null,
                Quantity = 120
            };

            ProductStock nullProductStock = null;

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.Read(nonExistingProductStock.Id)).
                Returns(nullProductStock);
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            Action actual = () => productStockService.Update(nonExistingProductStock);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_ProductSpecified_ThrowsArgumentException()
        {
            //Arrange
            ProductStock invalidProductStock = new ProductStock
            {
                Id = 5,
                Product = new Product { Id = 3 },
                ProductSize = null,
                Quantity = 120
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
        public void Update_ProductSizeSpecified_ThrowsArgumentException()
        {
            //Arrange
            ProductStock invalidProductStock = new ProductStock
            {
                Id = 5,
                Product = null,
                ProductSize = new ProductSize { Id = 5 },
                Quantity = 120
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
        public void Delete_IdExisting_ReturnsDeletedProductStockWithSpecifiedId()
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
            productStockRepository.Setup(repo => repo.Delete(existingId)).
                Returns(expected);
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();

            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            ProductStock actual = productStockService.Delete(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_IdNonExisting_ReturnsNull()
        {
            //Arrange
            int nonExistingId = 12;
            ProductStock expected = null;

            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.Delete(nonExistingId)).
                Returns(expected);
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();

            IProductStockService productStockService = new ProductStockService(productStockRepository.Object,
                productRepository.Object,
                productSizeRepository.Object);

            //Act
            ProductStock actual = productStockService.Delete(nonExistingId);

            //Assert
            Assert.Equal(expected, actual);
        }

    }
}