using System;
using Moq;
using RUSTWebApplication.Core.ApplicationService;
using RUSTWebApplication.Core.ApplicationService.Services;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;
using Xunit;

namespace RUSTWebApplication.UnitTests.Core
{
    public class ProductTypeServiceTest
    {
        [Fact]
        public void Create_ProductTypeValid_ReturnsCreatedProductTypeWithId()
        {
            //Arrange
            ProductType validProductType = new ProductType { Name = "Accessories" };
            ProductType expected = new ProductType { Id = 1, Name = validProductType.Name };

            Mock<IProductTypeRepository> productTypeRepository = new Mock<IProductTypeRepository>();
            productTypeRepository.Setup(repo => repo.Create(validProductType)).
                Returns(expected);

            IProductTypeService productTypeService = new ProductTypeService(productTypeRepository.Object);

            //Act
            ProductType actual = productTypeService.Create(validProductType);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Create_IdSpecified_ThrowsArgumentException()
        {
            //Arrange
            ProductType invalidProductType = new ProductType { Id = 1, Name = "Accessories" };

            Mock<IProductTypeRepository> productTypeRepository = new Mock<IProductTypeRepository>();
            IProductTypeService productTypeService = new ProductTypeService(productTypeRepository.Object);

            //Act
            Action actual = () => productTypeService.Create(invalidProductType);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_ProductTypeNull_ThrowsArgumentNullException()
        {
            //Arrange
            ProductType invalidProductType = null;

            Mock<IProductTypeRepository> productTypeRepository = new Mock<IProductTypeRepository>();
            IProductTypeService productTypeService = new ProductTypeService(productTypeRepository.Object);

            //Act
            Action actual = () => productTypeService.Create(invalidProductType);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Create_NameNull_ThrowsArgumentException()
        {
            //Arrange
            ProductType invalidProductType = new ProductType { };

            Mock<IProductTypeRepository> productTypeRepository = new Mock<IProductTypeRepository>();
            IProductTypeService productTypeService = new ProductTypeService(productTypeRepository.Object);

            //Act
            Action actual = () => productTypeService.Create(invalidProductType);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_NameEmpty_ThrowsArgumentException()
        {
            //Arrange
            ProductType invalidProductType = new ProductType { Name = "" };

            Mock<IProductTypeRepository> productTypeRepository = new Mock<IProductTypeRepository>();
            IProductTypeService productTypeService = new ProductTypeService(productTypeRepository.Object);

            //Act
            Action actual = () => productTypeService.Create(invalidProductType);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Read_ExistingId_ReturnsProductTypeWithSpecifiedId()
        {
            //Arrange
            int existingId = 12;
            ProductType expected = new ProductType { Id = existingId, Name = "Accessories" };

            Mock<IProductTypeRepository> productTypeRepository = new Mock<IProductTypeRepository>();
            productTypeRepository.Setup(repo => repo.Read(existingId)).
                Returns(expected);

            IProductTypeService productTypeService = new ProductTypeService(productTypeRepository.Object);

            //Act
            ProductType actual = productTypeService.Read(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Read_NonExistingId_ReturnsNull()
        {
            //Arrange
            int nonExistingId = 12;
            ProductType expected = null;

            Mock<IProductTypeRepository> productTypeRepository = new Mock<IProductTypeRepository>();
            productTypeRepository.Setup(repo => repo.Read(nonExistingId)).
                Returns(expected);

            IProductTypeService productTypeService = new ProductTypeService(productTypeRepository.Object);

            //Act
            ProductType actual = productTypeService.Read(nonExistingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_ProductTypeValid_ReturnsUpdatedProductType()
        {
            //Arrange
            ProductType validProductType = new ProductType { Id = 4, Name = "Accessories" };

            ProductType expected = validProductType;

            Mock<IProductTypeRepository> productTypeRepository = new Mock<IProductTypeRepository>();
            productTypeRepository.Setup(repo => repo.Read(4)).
                Returns(validProductType);
            productTypeRepository.Setup(repo => repo.Update(validProductType)).
                Returns(expected);

            IProductTypeService productTypeService = new ProductTypeService(productTypeRepository.Object);

            //Act
            ProductType actual = productTypeService.Update(validProductType);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_ProductTypeNull_ThrowsArgumentNullException()
        {
            //Arrange
            ProductType invalidProductType = null;

            Mock<IProductTypeRepository> productTypeRepository = new Mock<IProductTypeRepository>();
            IProductTypeService productTypeService = new ProductTypeService(productTypeRepository.Object);

            //Act
            Action actual = () => productTypeService.Update(invalidProductType);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Update_NonExistingId_ReturnsNull()
        {
            //Arrange
            ProductType nonExistingProductType = new ProductType { Id = 4, Name = "Accessories" };
            ProductType expected = null;

            Mock<IProductTypeRepository> productTypeRepository = new Mock<IProductTypeRepository>();
            productTypeRepository.Setup(repo => repo.Read(4)).
                Returns(expected);

            IProductTypeService productTypeService = new ProductTypeService(productTypeRepository.Object);

            //Act
            ProductType actual = productTypeService.Update(nonExistingProductType);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_NameNull_ThrowsArgumentException()
        {
            //Arrange
            ProductType invalidProductType = new ProductType { Id = 4, Name = null };

            Mock<IProductTypeRepository> productTypeRepository = new Mock<IProductTypeRepository>();

            IProductTypeService productTypeService = new ProductTypeService(productTypeRepository.Object);

            //Act
            Action actual = () => productTypeService.Update(invalidProductType);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_NameEmpty_ThrowsArgumentException()
        {
            //Arrange
            ProductType invalidProductType = new ProductType { Id = 4, Name = null };

            Mock<IProductTypeRepository> productTypeRepository = new Mock<IProductTypeRepository>();

            IProductTypeService productTypeService = new ProductTypeService(productTypeRepository.Object);

            //Act
            Action actual = () => productTypeService.Update(invalidProductType);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Delete_ExistingId_ReturnsDeletedProductTypeWithSpecifiedId()
        {
            //Arrange
            int existingId = 12;
            ProductType expected = new ProductType { Id = existingId, Name = "Accessories" };

            Mock<IProductTypeRepository> productTypeRepository = new Mock<IProductTypeRepository>();
            productTypeRepository.Setup(repo => repo.Delete(existingId)).
                Returns(expected);

            IProductTypeService productTypeService = new ProductTypeService(productTypeRepository.Object);

            //Act
            ProductType actual = productTypeService.Delete(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_NonExistingId_ReturnsNull()
        {
            //Arrange
            int nonExistingId = 12;
            ProductType expected = null;

            Mock<IProductTypeRepository> productTypeRepository = new Mock<IProductTypeRepository>();
            productTypeRepository.Setup(repo => repo.Delete(nonExistingId)).
                Returns(expected);

            IProductTypeService productTypeService = new ProductTypeService(productTypeRepository.Object);

            //Act
            ProductType actual = productTypeService.Delete(nonExistingId);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
