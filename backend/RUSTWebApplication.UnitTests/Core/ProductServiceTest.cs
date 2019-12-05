using System;
using System.Collections.Generic;
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
                ProductStocks = null,
                Color = "Black"
            };
            Product expected = new Product
            {
                Id = 1,
                ProductModel = new ProductModel { Id = 2 },
                ProductStocks = null,
                Color = "Black"
            };

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Create(validProduct)).
                Returns(expected);
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            productModelRepository.Setup(repo => repo.Read(validProduct.ProductModel.Id)).
                Returns(validProduct.ProductModel);

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Product actual = productService.Create(validProduct);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Create_ProductNull_ThrowsArgumentNullException()
        {
            //Arrange
            Product invalidProduct= null;

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Action actual = () => productService.Create(invalidProduct);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Create_IdSpecified_ThrowsArgumentException()
        {
            //Arrange
            Product invalidProduct = new Product
            {
                Id = 5,
                ProductModel = new ProductModel { Id = 2 },
                ProductStocks = null,
                Color = "Black"
            };

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Action actual = () => productService.Create(invalidProduct);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_ColorNull_ThrowsArgumentException()
        {
            //Arrange
            Product invalidProduct = new Product
            {
                ProductModel = new ProductModel { Id = 2 },
                ProductStocks = null,
                Color = null
            };

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Action actual = () => productService.Create(invalidProduct);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_ColorEmpty_ThrowsArgumentException()
        {
            //Arrange
            Product invalidProduct = new Product
            {
                ProductModel = new ProductModel { Id = 2 },
                ProductStocks = null,
                Color = ""
            };

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Action actual = () => productService.Create(invalidProduct);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_ProductModelNull_ThrowsArgumentException()
        {
            //Arrange
            Product invalidProduct = new Product
            {
                ProductModel = null,
                ProductStocks = null,
                Color = "Black"
            };

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Action actual = () => productService.Create(invalidProduct);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_ProductModelNonExisting_ThrowsArgumentException()
        {
            //Arrange
            Product invalidProduct = new Product
            {
                ProductModel = new ProductModel { Id = 2 },
                ProductStocks = null,
                Color = "Black"
            };

            ProductModel nullProductModel = null;

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            productModelRepository.Setup(repo => repo.Read(invalidProduct.ProductModel.Id)).
                Returns(nullProductModel);

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Action actual = () => productService.Create(invalidProduct);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_ProductStocksSpecified_ThrowsArgumentException()
        {
            //Arrange
            Product invalidProduct = new Product
            {
                ProductModel = new ProductModel { Id = 2 },
                Color = "Yellow",
                ProductStocks = new List<ProductStock>
                {
                    new ProductStock { Id = 1}
                }
            };

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Action actual = () => productService.Create(invalidProduct);

            //Assert
            Assert.Throws<ArgumentException>(actual);

        }

        [Fact]
        public void Read_IdExisting_ReturnsProductWithSpecifiedId()
        {
            //Arrange
            int existingId = 12;
            Product expected = new Product
            {
                Id = existingId,
                ProductModel = new ProductModel { Id = 2 },
                ProductStocks = null,
                Color = "Yellow"
            };

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Read(existingId)).
                Returns(expected);
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Product actual = productService.Read(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Read_IdNonExisting_ReturnsNull()
        {
            //Arrange
            int existingId = 12;
            Product expected = null;

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Read(existingId)).
                Returns(expected);
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Product actual = productService.Read(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_ProductValid_ReturnsUpdatedProduct()
        {
            //Arrange
            Product validProduct = new Product
            {
                Id = 9,
                ProductModel = null,
                ProductStocks = null,
                Color = "Black"
            };
            Product expected = validProduct;

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Read(validProduct.Id)).
                Returns(validProduct);
            productRepository.Setup(repo => repo.Update(validProduct)).
                Returns(validProduct);
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            productModelRepository.Setup(repo => repo.Read(validProduct.ProductModel.Id)).
                Returns(validProduct.ProductModel);

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Product actual = productService.Update(validProduct);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_ProductNull_ThrowsArgumentException()
        {
            //Arrange
            Product invalidProduct = null;

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Action actual = () => productService.Update(invalidProduct);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Update_IdNonExisting_ThrowsArgumentException()
        {
            //Arrange
            Product nonExistingProduct = new Product
            {
                Id = 9,
                ProductModel = null,
                ProductStocks = null,
                Color = "Black"
            };

            Product nullProduct = null;

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Read(nonExistingProduct.Id)).
                Returns(nullProduct);
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Action actual = () => productService.Update(nonExistingProduct);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Update_ColorNull_ThrowsArgumentException()
        {
            //Arrange
            Product invalidProduct = new Product
            {
                Id = 10,
                ProductModel = null,
                ProductStocks = null,
                Color = null
            };

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Action actual = () => productService.Update(invalidProduct);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_ColorEmpty_ThrowsArgumentException()
        {
            //Arrange
            Product invalidProduct = new Product
            {
                Id = 10,
                ProductModel = null,
                ProductStocks = null,
                Color = ""
            };

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Action actual = () => productService.Update(invalidProduct);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_ProductModelSpecified_ThrowsArgumentException()
        {
            //Arrange
            Product invalidProduct = new Product
            {
                Id = 9,
                ProductModel = new ProductModel { Id = 1},
                ProductStocks = null,
                Color = "Black"
            };

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Action actual = () => productService.Update(invalidProduct);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Update_ProductStocksSpecified_ThrowsArgumentException()
        {
            //Arrange
            Product invalidProduct = new Product
            {
                Id = 9,
                ProductModel = null,
                ProductStocks = new List<ProductStock>
                {
                    new ProductStock { Id = 1}
                },
                Color = "Black"
            };

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Action actual = () => productService.Update(invalidProduct);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Delete_IdExisting_ReturnsDeletedProductWithSpecifiedId()
        {
            //Arrange
            int existingId = 12;
            Product expected = new Product
            {
                Id = existingId,
                ProductModel = new ProductModel { Id = 2 },
                ProductStocks = null,
                Color = "Yellow"
            };

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Delete(existingId)).
                Returns(expected);
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Product actual = productService.Delete(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_IdNonExisting_ReturnsNull()
        {
            //Arrange
            int existingId = 12;
            Product expected = null;

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Delete(existingId)).
                Returns(expected);
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();

            IProductService productService = new ProductService(productRepository.Object,
                productModelRepository.Object);

            //Act
            Product actual = productService.Delete(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
