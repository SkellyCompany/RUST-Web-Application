using System;
using Moq;
using RUSTWebApplication.Core.ApplicationService;
using RUSTWebApplication.Core.ApplicationService.Services;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;
using Xunit;

namespace RUSTWebApplication.UnitTests.Core
{
    public class ProductMetricServiceTest
    {
        [Fact]
        public void Create_ProductMetricValid_ReturnsCreatedProductMetricWithId()
        {
            //Arrange
            ProductMetric validProductMetric = new ProductMetric
            {
                Name = "Oversized Hoodie",
                MetricX = "Width",
                MetricY = "Length",
                MetricZ = "Sleeve Length"
            };
            ProductMetric expected = new ProductMetric
            {
                Id = 1,
                Name = "Oversized Hoodie",
                MetricX = "Width",
                MetricY = "Length",
                MetricZ = "Sleeve Length"
            };

            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            productMetricRepository.Setup(repo => repo.Create(validProductMetric)).
                Returns(expected);
            Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();

            IProductMetricService productMetricService = new ProductMetricService(productMetricRepository.Object);

            //Act
            ProductMetric actual = productMetricService.Create(validProductMetric);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Create_ProductMetricNull_ThrowsArgumentNullException()
        {
            //Arrange
            ProductMetric invalidProductMetric = null;

            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();

            IProductMetricService productMetricService = new ProductMetricService(productMetricRepository.Object);

            //Act
            Action actual = () => productMetricService.Create(invalidProductMetric);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Create_IdSpecified_ThrowsArgumentException()
        {
            //Arrange
            ProductMetric invalidProductMetric = new ProductMetric
            {
                Id = 1,
                Name = "Oversized Hoodie",
                MetricX = "Width",
                MetricY = "Length",
                MetricZ = "Sleeve Length"
            };

            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();

            IProductMetricService productMetricService = new ProductMetricService(productMetricRepository.Object);

            //Act
            Action actual = () => productMetricService.Create(invalidProductMetric);

            //Assert
            Assert.Throws<ArgumentException>(actual);

        }

        [Fact]
        public void Create_NameNull_ThrowsArgumentException()
        {
            //Arrange
            ProductMetric invalidProductMetric = new ProductMetric
            {
                Name = null,
                MetricX = "Width",
                MetricY = "Length",
                MetricZ = "Sleeve Length"
            };

            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();

            IProductMetricService productMetricService = new ProductMetricService(productMetricRepository.Object);

            //Act
            Action actual = () => productMetricService.Create(invalidProductMetric);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_NameEmpty_ThrowsArgumentException()
        {
            //Arrange
            ProductMetric invalidProductMetric = new ProductMetric
            {
                Name = "",
                MetricX = "Width",
                MetricY = "Length",
                MetricZ = "Sleeve Length"
            };

            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();

            IProductMetricService productMetricService = new ProductMetricService(productMetricRepository.Object);

            //Act
            Action actual = () => productMetricService.Create(invalidProductMetric);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_MetricXNull_ThrowsArgumentException()
        {
            //Arrange
            ProductMetric invalidProductMetric = new ProductMetric
            {
                Name = "Oversized Hoodie",
                MetricX = null,
                MetricY = "Length",
                MetricZ = "Sleeve Length"
            };

            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();

            IProductMetricService productMetricService = new ProductMetricService(productMetricRepository.Object);

            //Act
            Action actual = () => productMetricService.Create(invalidProductMetric);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_MetricXEmpty_ThrowsArgumentException()
        {
            //Arrange
            ProductMetric invalidProductMetric = new ProductMetric
            {
                Name = "Oversized Hoodie",
                MetricX = "",
                MetricY = "Length",
                MetricZ = "Sleeve Length"
            };

            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();

            IProductMetricService productMetricService = new ProductMetricService(productMetricRepository.Object);

            //Act
            Action actual = () => productMetricService.Create(invalidProductMetric);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Read_IdExisting_ReturnsProductMetricWithSpecifiedId()
        {
            //Arrange
            int existingId = 12;
            ProductMetric expected = new ProductMetric
            {
                Id = existingId,
                Name = "Oversized Hoodie",
                MetricX = "",
                MetricY = "Length",
                MetricZ = "Sleeve Length"
            };

            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            productMetricRepository.Setup(repo => repo.Read(existingId)).
                Returns(expected);

            IProductMetricService productMetricService = new ProductMetricService(productMetricRepository.Object);

            //Act
            ProductMetric actual = productMetricService.Read(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Read_IdNonExisting_ReturnsNull()
        {
            //Arrange
            int existingId = 12;
            ProductMetric expected = null;

            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            productMetricRepository.Setup(repo => repo.Read(existingId)).
                Returns(expected);

            IProductMetricService productMetricService = new ProductMetricService(productMetricRepository.Object);

            //Act
            ProductMetric actual = productMetricService.Read(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_ProductMetricValid_ReturnsUpdatedProductMetric()
        {
            //Arrange
            ProductMetric validProductMetric = new ProductMetric
            {
                Id = 1,
                Name = "Oversized Hoodie",
                MetricX = "Width",
                MetricY = "Length",
                MetricZ = "Sleeve Length"
            };

            ProductMetric expected = validProductMetric;

            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            productMetricRepository.Setup(repo => repo.Read(validProductMetric.Id)).
                Returns(validProductMetric);
            productMetricRepository.Setup(repo => repo.Update(validProductMetric)).
                Returns(expected);

            IProductMetricService productMetricService = new ProductMetricService(productMetricRepository.Object);

            //Act
            ProductMetric actual = productMetricService.Update(validProductMetric);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_ProductMetricNull_ThrowsArgumentNullException()
        {
            //Arrange
            ProductMetric invalidProductMetric = null;

            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();

            IProductMetricService productMetricService = new ProductMetricService(productMetricRepository.Object);

            //Act
            Action actual = () => productMetricService.Update(invalidProductMetric);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Update_IdNonExisting_ThrowsArgumentException()
        {
            //Arrange
            ProductMetric invalidProductMetric = new ProductMetric
            {
                Id = 1,
                Name = "Oversized Hoodie",
                MetricX = "Width",
                MetricY = "Length",
                MetricZ = "Sleeve Length"
            };

            ProductMetric nullProductMetric = null;

            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            productMetricRepository.Setup(repo => repo.Read(invalidProductMetric.Id)).
                Returns(nullProductMetric);

            IProductMetricService productMetricService = new ProductMetricService(productMetricRepository.Object);

            //Act
            Action actual = () => productMetricService.Update(invalidProductMetric);

            //Assert
            Assert.Throws<ArgumentException>(actual);

        }

        [Fact]
        public void Update_NameNull_ThrowsArgumentException()
        {
            //Arrange
            ProductMetric invalidProductMetric = new ProductMetric
            {
                Id = 1,
                Name = null,
                MetricX = "Width",
                MetricY = "Length",
                MetricZ = "Sleeve Length"
            };

            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();

            IProductMetricService productMetricService = new ProductMetricService(productMetricRepository.Object);

            //Act
            Action actual = () => productMetricService.Update(invalidProductMetric);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_NameEmpty_ThrowsArgumentException()
        {
            //Arrange
            ProductMetric invalidProductMetric = new ProductMetric
            {
                Id = 1,
                Name = "",
                MetricX = "Width",
                MetricY = "Length",
                MetricZ = "Sleeve Length"
            };

            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();

            IProductMetricService productMetricService = new ProductMetricService(productMetricRepository.Object);

            //Act
            Action actual = () => productMetricService.Update(invalidProductMetric);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_MetricXNull_ThrowsArgumentException()
        {
            //Arrange
            ProductMetric invalidProductMetric = new ProductMetric
            {
                Id = 5,
                Name = "Oversized Hoodie",
                MetricX = null,
                MetricY = "Length",
                MetricZ = "Sleeve Length"
            };

            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();

            IProductMetricService productMetricService = new ProductMetricService(productMetricRepository.Object);

            //Act
            Action actual = () => productMetricService.Update(invalidProductMetric);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_MetricXEmpty_ThrowsArgumentException()
        {
            //Arrange
            ProductMetric invalidProductMetric = new ProductMetric
            {
                Id = 3,
                Name = "Oversized Hoodie",
                MetricX = "",
                MetricY = "Length",
                MetricZ = "Sleeve Length"
            };

            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();

            IProductMetricService productMetricService = new ProductMetricService(productMetricRepository.Object);

            //Act
            Action actual = () => productMetricService.Update(invalidProductMetric);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Delete_IdExisting_ReturnsDeletedProductMetricWithSpecifiedId()
        {
            //Arrange
            int existingId = 12;
            ProductMetric expected = new ProductMetric
            {
                Id = existingId,
                Name = "Oversized Hoodie",
                MetricX = "",
                MetricY = "Length",
                MetricZ = "Sleeve Length"
            };

            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            productMetricRepository.Setup(repo => repo.Delete(existingId)).
                Returns(expected);

            IProductMetricService productMetricService = new ProductMetricService(productMetricRepository.Object);

            //Act
            ProductMetric actual = productMetricService.Delete(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_IdNonExisting_ReturnsNull()
        {
            //Arrange
            int existingId = 12;
            ProductMetric expected = null;

            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            productMetricRepository.Setup(repo => repo.Delete(existingId)).
                Returns(expected);

            IProductMetricService productMetricService = new ProductMetricService(productMetricRepository.Object);

            //Act
            ProductMetric actual = productMetricService.Delete(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
