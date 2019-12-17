using System;
using Moq;
using Xunit;
using RUSTWebApplication.Core.ApplicationService;
using RUSTWebApplication.Core.ApplicationService.Services;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.UnitTests.Core
{
    public class ProductCategoryServiceTest
    {
        [Fact]
        public void Create_ProductCategoryValid_ReturnsCreatedProductCategoryWithId()
        {
            //Arrange
            ProductCategory validProductCategory = new ProductCategory { Name = "Accessories" };
            ProductCategory expected = new ProductCategory { Id = 1, Name = validProductCategory.Name };

            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
            productCategoryRepository.Setup(repo => repo.Create(validProductCategory)).
                Returns(expected);

            IProductCategoryService productCategoryService = new ProductCategoryService(productCategoryRepository.Object);

            //Act
            ProductCategory actual = productCategoryService.Create(validProductCategory);

            //Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Create_ProductCategoryNull_ThrowsArgumentNullException()
        {
            //Arrange
            ProductCategory invalidProductCategory = null;

            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
            IProductCategoryService productCategoryService = new ProductCategoryService(productCategoryRepository.Object);

            //Act
            Action actual = () => productCategoryService.Create(invalidProductCategory);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Create_IdSpecified_ThrowsArgumentException()
        {
            //Arrange
            ProductCategory invalidProductCategory = new ProductCategory { Id = 1, Name = "Accessories" };

            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
            IProductCategoryService productCategoryService = new ProductCategoryService(productCategoryRepository.Object);

            //Act
            Action actual = () => productCategoryService.Create(invalidProductCategory);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_NameNull_ThrowsArgumentException()
        {
            //Arrange
            ProductCategory invalidProductCategory = new ProductCategory { };

            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
            IProductCategoryService productCategoryService = new ProductCategoryService(productCategoryRepository.Object);

            //Act
            Action actual = () => productCategoryService.Create(invalidProductCategory);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_NameEmpty_ThrowsArgumentException()
        {
            //Arrange
            ProductCategory invalidProductCategory = new ProductCategory { Name = "" };

            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
            IProductCategoryService productCategoryService = new ProductCategoryService(productCategoryRepository.Object);

            //Act
            Action actual = () => productCategoryService.Create(invalidProductCategory);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Read_IdExisting_ReturnsProductCategoryWithSpecifiedId()
        {
            //Arrange
            int existingId = 12;
            ProductCategory expected = new ProductCategory { Id = existingId, Name = "Accessories" };

            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
            productCategoryRepository.Setup(repo => repo.Read(existingId)).
                Returns(expected);

            IProductCategoryService productCategoryService = new ProductCategoryService(productCategoryRepository.Object);

            //Act
            ProductCategory actual = productCategoryService.Read(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Read_IdNonExisting_ReturnsNull()
        {
            //Arrange
            int nonExistingId = 12;
            ProductCategory expected = null;

            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
            productCategoryRepository.Setup(repo => repo.Read(nonExistingId)).
                Returns(expected);

            IProductCategoryService productCategoryService = new ProductCategoryService(productCategoryRepository.Object);

            //Act
            ProductCategory actual = productCategoryService.Read(nonExistingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_ProductCategoryValid_ReturnsUpdatedProductCategory()
        {
            //Arrange
            ProductCategory validProductCategory = new ProductCategory { Id = 4, Name = "Accessories" };

            ProductCategory expected = validProductCategory;

            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
            productCategoryRepository.Setup(repo => repo.Read(validProductCategory.Id)).
                Returns(validProductCategory);
            productCategoryRepository.Setup(repo => repo.Update(validProductCategory)).
                Returns(expected);

            IProductCategoryService productCategoryService = new ProductCategoryService(productCategoryRepository.Object);

            //Act
            ProductCategory actual = productCategoryService.Update(validProductCategory);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_ProductCategoryNull_ThrowsArgumentNullException()
        {
            //Arrange
            ProductCategory invalidProductCategory = null;

            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
            IProductCategoryService productCategoryService = new ProductCategoryService(productCategoryRepository.Object);

            //Act
            Action actual = () => productCategoryService.Update(invalidProductCategory);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Update_IdNonExisting_ThrowsArgumentException()
        {
            //Arrange
            ProductCategory nonExistingProductCategory = new ProductCategory { Id = 4, Name = "Accessories" };
            ProductCategory nullProductCategory = null;

            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
            productCategoryRepository.Setup(repo => repo.Read(nonExistingProductCategory.Id)).
                Returns(nullProductCategory);

            IProductCategoryService productCategoryService = new ProductCategoryService(productCategoryRepository.Object);

            //Act
            Action actual = () => productCategoryService.Update(nonExistingProductCategory);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_NameNull_ThrowsArgumentException()
        {
            //Arrange
            ProductCategory invalidProductCategory = new ProductCategory { Id = 4, Name = null };

            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductCategoryService productCategoryService = new ProductCategoryService(productCategoryRepository.Object);

            //Act
            Action actual = () => productCategoryService.Update(invalidProductCategory);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_NameEmpty_ThrowsArgumentException()
        {
            //Arrange
            ProductCategory invalidProductCategory = new ProductCategory { Id = 4, Name = null };

            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();

            IProductCategoryService productCategoryService = new ProductCategoryService(productCategoryRepository.Object);

            //Act
            Action actual = () => productCategoryService.Update(invalidProductCategory);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Delete_IdExisting_ReturnsDeletedProductCategoryWithSpecifiedId()
        {
            //Arrange
            int existingId = 12;
            ProductCategory expected = new ProductCategory { Id = existingId, Name = "Accessories" };

            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
            productCategoryRepository.Setup(repo => repo.Delete(existingId)).
                Returns(expected);

            IProductCategoryService productCategoryService = new ProductCategoryService(productCategoryRepository.Object);

            //Act
            ProductCategory actual = productCategoryService.Delete(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_IdNonExisting_ReturnsNull()
        {
            //Arrange
            int nonExistingId = 12;
            ProductCategory expected = null;

            Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
            productCategoryRepository.Setup(repo => repo.Delete(nonExistingId)).
                Returns(expected);

            IProductCategoryService productCategoryService = new ProductCategoryService(productCategoryRepository.Object);

            //Act
            ProductCategory actual = productCategoryService.Delete(nonExistingId);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
