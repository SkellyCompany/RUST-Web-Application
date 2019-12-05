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
    public class ProductModelServiceTest
    {
        [Fact]
        public void Create_ProductModelValid_ReturnsCreatedProductModelWithId()
        {
            //Arrange
            ProductModel validProductModel = new ProductModel
            {
                Name = "Rust In Peace Hoodie",
                ProductCategory = new ProductCategory { Id = 2},
                Price = 130,
                Products = null
            };
            ProductModel expected = new ProductModel
            {
                Id = 1,
                Name = "Rust In Peace Hoodie",
                ProductCategory = new ProductCategory { Id = 2 },
                Price = 130,
                Products = null
            };

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            productModelRepository.Setup(repo => repo.Create(validProductModel)).
                Returns(expected);
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
            productCategoryRepository.Setup(repo => repo.Read(validProductModel.ProductCategory.Id)).
                Returns(validProductModel.ProductCategory);

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            ProductModel actual = productModelService.Create(validProductModel);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Create_ProductModelNull_ThrowsArgumentNullException()
        {
            //Arrange
            ProductModel invalidProductModel = null;

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            Action actual = () => productModelService.Create(invalidProductModel);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Create_IdSpecified_ThrowsArgumentException()
        {
            //Arrange
            ProductModel invalidProductModel = new ProductModel
            {
                Id = 1,
                Name = "Rust In Peace Hoodie",
                ProductCategory = new ProductCategory { Id = 2 },
                Price = 130,
                Products = null
            };

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            Action actual = () => productModelService.Create(invalidProductModel);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_NameNull_ThrowsArgumentException()
        {
            //Arrange
            ProductModel invalidProductModel = new ProductModel
            {
                Name = null,
                ProductCategory = new ProductCategory { Id = 2 },
                Price = 130,
                Products = null
            };

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            Action actual = () => productModelService.Create(invalidProductModel);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_NameEmpty_ThrowsArgumentException()
        {
            //Arrange
            ProductModel invalidProductModel = new ProductModel
            {
                Name = "",
                ProductCategory = new ProductCategory { Id = 2 },
                Price = 130,
                Products = null
            };

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            Action actual = () => productModelService.Create(invalidProductModel);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_ProductCategoryNull_ThrowsArgumentException()
        {
            //Arrange
            ProductModel invalidProductModel = new ProductModel
            {
                Name = "Rust In Peace Hoodie",
                ProductCategory = null,
                Price = 120,
                Products = null
            };

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            Action actual = () => productModelService.Create(invalidProductModel);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_ProductCategoryNonExisting_ThrowsArgumentException()
        {
            //Arrange
            ProductModel invalidProductModel = new ProductModel
            {
                Name = "Rust In Peace Hoodie",
                ProductCategory = new ProductCategory { Id = 2 },
                Price = 120,
                Products = null
            };

            ProductCategory nullProductCategory = null;

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
            productCategoryRepository.Setup(repo => repo.Read(invalidProductModel.ProductCategory.Id)).
                Returns(nullProductCategory);

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            Action actual = () => productModelService.Create(invalidProductModel);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_PriceNegative_ThrowsArgumentException()
        {
            //Arrange
            ProductModel invalidProductModel = new ProductModel
            {
                Name = "Rust In Peace Hoodie",
                ProductCategory = new ProductCategory { Id = 2 },
                Price = -5,
                Products = null
            };

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            Action actual = () => productModelService.Create(invalidProductModel);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_ProductsSpecified_ThrowsArgumentException()
        {
            //Arrange
            ProductModel invalidProductModel = new ProductModel
            {
                Name = "Rust In Peace Hoodie",
                ProductCategory = new ProductCategory { Id = 2 },
                Price = 120,
                Products = new List<Product>
                {
                    new Product {Id = 1}
                }
            };

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            Action actual = () => productModelService.Create(invalidProductModel);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Read_IdExisting_ReturnsProductModelWithSpecifiedId()
        {
            //Arrange
            int existingId = 12;
            ProductModel expected = new ProductModel
            {
                Id = existingId,
                Name = "Rust In Peace Hoodie",
                ProductCategory = new ProductCategory { Id = 2 },
                Price = 120,
                Products = null
            };

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            productModelRepository.Setup(repo => repo.Read(existingId)).
                Returns(expected);
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            ProductModel actual = productModelService.Read(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Read_IdNonExisting_ReturnsNull()
        {
            //Arrange
            int existingId = 12;
            ProductModel expected = null;

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            productModelRepository.Setup(repo => repo.Read(existingId)).
                Returns(expected);
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            ProductModel actual = productModelService.Read(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_ProductModelValid_ReturnsUpdatedProductModel()
        {
            //Arrange
            ProductModel validProductModel = new ProductModel
            {
                Id = 3,
                Name = "Rust In Peace Hoodie",
                ProductCategory = new ProductCategory { Id = 2 },
                Price = 130,
                Products = null
            };
            ProductModel expected = validProductModel;

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            productModelRepository.Setup(repo => repo.Read(validProductModel.Id)).
                Returns(validProductModel);
            productModelRepository.Setup(repo => repo.Create(validProductModel)).
                Returns(validProductModel);
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
            productCategoryRepository.Setup(repo => repo.Read(validProductModel.ProductCategory.Id)).
                Returns(validProductModel.ProductCategory);

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            ProductModel actual = productModelService.Update(validProductModel);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_ProductModelNull_ThrowsArgumentNullException()
        {
            //Arrange
            ProductModel invalidProductModel = null;

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            Action actual = () => productModelService.Update(invalidProductModel);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Update_IdNotExisting_ThrowsArgumentException()
        {
            //Arrange
            ProductModel nonExistingProductModel = new ProductModel
            {
                Id = 1,
                Name = "Rust In Peace Hoodie",
                ProductCategory = new ProductCategory { Id = 2 },
                Price = 130,
                Products = null
            };

            ProductModel nullProductModel = null;

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            productModelRepository.Setup(repo => repo.Read(nonExistingProductModel.Id)).
                Returns(nullProductModel);
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
            productCategoryRepository.Setup(repo => repo.Read(nonExistingProductModel.ProductCategory.Id)).
                Returns(nonExistingProductModel.ProductCategory);

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            Action actual = () => productModelService.Update(nonExistingProductModel);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_ProductCategoryNull_ThrowsArgumentException()
        {
            //Arrange
            ProductModel invalidProductModel = new ProductModel
            {
                Id = 1,
                Name = "Rust In Peace Hoodie",
                ProductCategory = null,
                Price = 120,
                Products = null
            };

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            productModelRepository.Setup(repo => repo.Read(invalidProductModel.Id)).
                Returns(invalidProductModel);
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            Action actual = () => productModelService.Update(invalidProductModel);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_ProductCategoryNonExisting_ThrowsArgumentException()
        {
            //Arrange
            ProductModel invalidProductModel = new ProductModel
            {
                Id = 1,
                Name = "Rust In Peace Hoodie",
                ProductCategory = new ProductCategory { Id = 2 },
                Price = 120,
                Products = null
            };

            ProductCategory nullProductCategory = null;

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            productModelRepository.Setup(repo => repo.Read(invalidProductModel.Id)).
                Returns(invalidProductModel);
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
            productCategoryRepository.Setup(repo => repo.Read(invalidProductModel.ProductCategory.Id)).
                Returns(nullProductCategory);

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            Action actual = () => productModelService.Update(invalidProductModel);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_NameNull_ThrowsArgumentException()
        {
            //Arrange
            ProductModel invalidProductModel = new ProductModel
            {
                Id = 1,
                Name = null,
                ProductCategory = new ProductCategory { Id = 2 },
                Price = 130,
                Products = null
            };

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            Action actual = () => productModelService.Update(invalidProductModel);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_NameEmpty_ThrowsArgumentException()
        {
            //Arrange
            ProductModel invalidProductModel = new ProductModel
            {
                Id = 1,
                Name = "",
                ProductCategory = new ProductCategory { Id = 2 },
                Price = 130,
                Products = null
            };

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            Action actual = () => productModelService.Update(invalidProductModel);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_PriceNegative_ThrowsArgumentException()
        {
            //Arrange
            ProductModel invalidProductModel = new ProductModel
            {
                Id = 1,
                Name = "Rust In Peace Hoodie",
                ProductCategory = new ProductCategory { Id = 2 },
                Price = -5,
                Products = null
            };

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            Action actual = () => productModelService.Update(invalidProductModel);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_ProductsSpecified_ThrowsArgumentException()
        {
            //Arrange
            ProductModel invalidProductModel = new ProductModel
            {
                Id = 1,
                Name = "Rust In Peace Hoodie",
                ProductCategory = new ProductCategory { Id = 2 },
                Price = 120,
                Products = new List<Product>
                {
                    new Product {Id = 1}
                }
            };

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            Action actual = () => productModelService.Update(invalidProductModel);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Delete_IdExisting_ReturnsDeletedProductModelWithSpecifiedId()
        {
            //Arrange
            int existingId = 12;
            ProductModel expected = new ProductModel
            {
                Id = existingId,
                Name = "Rust In Peace Hoodie",
                ProductCategory = new ProductCategory { Id = 2 },
                Price = 120,
                Products = null
            };

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            productModelRepository.Setup(repo => repo.Delete(existingId)).
                Returns(expected);
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            ProductModel actual = productModelService.Delete(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_IdNonExisting_ReturnsNull()
        {
            //Arrange
            int existingId = 12;
            ProductModel expected = null;

            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
            productModelRepository.Setup(repo => repo.Delete(existingId)).
                Returns(expected);
            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductModelService productModelService = new ProductModelService(productModelRepository.Object,
                productCategoryRepository.Object);

            //Act
            ProductModel actual = productModelService.Delete(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
