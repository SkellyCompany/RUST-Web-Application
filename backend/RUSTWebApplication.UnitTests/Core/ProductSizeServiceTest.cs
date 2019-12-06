using System;
using Moq;
using RUSTWebApplication.Core.ApplicationService;
using RUSTWebApplication.Core.ApplicationService.Services;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;
using Xunit;

namespace RUSTWebApplication.UnitTests.Core
{
    public class ProductSizeServiceTest
    {
        [Fact]
        public void Create_ProductSizeValid_ReturnsCreatedProductSizeWithId()
        {
            //Arrange
            ProductSize validProductSize = new ProductSize
            {
                ProductMetric = new ProductMetric { Id = 1},
                Size = "L",
                MetricXValue = 70,
                MetricYValue = 100,
                MetricZValue = 75
            };
            ProductSize expected = new ProductSize
            {
                Id = 1,
                ProductMetric = new ProductMetric { Id = 1 },
                Size = "L",
                MetricXValue = 70,
                MetricYValue = 100,
                MetricZValue = 75
            };

            ProductMetric fetchedProductMetric = new ProductMetric
            {
                Id = 1,
                Name = "Oversized Hoodie",
                ProductModel = new ProductModel { Id = 1 },
                MetricX = "Length",
                MetricY = "Width",
                MetricZ = "Sleeve Length"

            };

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Create(validProductSize)).
                Returns(expected);
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            productMetricRepository.Setup(repo => repo.Read(validProductSize.ProductMetric.Id)).
                Returns(fetchedProductMetric);
            
            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            ProductSize actual = productSizeService.Create(validProductSize);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Create_ProductSizeNull_ThrowsArgumentNullException()
        {
            //Arrange
            ProductSize invalidProductSize = null;

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            Action actual = () => productSizeService.Create(invalidProductSize);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Create_IdSpecified_ThrowsArgumentException()
        {
            //Arrange
            ProductSize invalidProductSize = new ProductSize
            {
                Id = 1,
                ProductMetric = new ProductMetric { Id = 1 },
                Size = "L",
                MetricXValue = 70,
                MetricYValue = 100,
                MetricZValue = 75
            };

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            Action actual = () => productSizeService.Create(invalidProductSize);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_ProductMetricNull_ThrowsArgumentException()
        {
            //Arrange
            ProductSize invalidProductSize = new ProductSize
            {
                ProductMetric = null,
                Size = "L",
                MetricXValue = 70,
                MetricYValue = 100,
                MetricZValue = 75
            };

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            Action actual = () => productSizeService.Create(invalidProductSize);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_ProductMetricNonExisting_ThrowsArgumentException()
        {
            //Arrange
            ProductSize invalidProductSize = new ProductSize
            {
                ProductMetric = new ProductMetric { Id = 1 },
                Size = "L",
                MetricXValue = 70,
                MetricYValue = 100,
                MetricZValue = 75
            };

            ProductMetric nullProductMetric = null;

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            productMetricRepository.Setup(repo => repo.Read(invalidProductSize.ProductMetric.Id)).
                Returns(nullProductMetric);
            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            Action actual = () => productSizeService.Create(invalidProductSize);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_SizeNull_ThrowsArgumentException()
        {
            //Arrange
            ProductSize invalidProductSize = new ProductSize
            {
                ProductMetric = new ProductMetric { Id = 1 },
                Size = null,
                MetricXValue = 70,
                MetricYValue = 100,
                MetricZValue = 75
            };

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            Action actual = () => productSizeService.Create(invalidProductSize);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_SizeEmpty_ThrowsArgumentException()
        {
            //Arrange
            ProductSize invalidProductSize = new ProductSize
            {
                ProductMetric = new ProductMetric { Id = 1 },
                Size = "",
                MetricXValue = 70,
                MetricYValue = 100,
                MetricZValue = 75
            };

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            Action actual = () => productSizeService.Create(invalidProductSize);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_MetricsNotFilled_ThrowsArgumentException()
        {
            //Arrange
            ProductSize invalidProductSize = new ProductSize
            {
                ProductMetric = new ProductMetric { Id = 1 },
                Size = "XL",
                MetricXValue = 70,
                MetricYValue = 100
            };

            ProductMetric fetchedProductMetric = new ProductMetric
            {
                Id = 1,
                Name = "Oversized Hoodie",
                ProductModel = new ProductModel { Id = 1 },
                MetricX = "Length",
                MetricY = "Width",
                MetricZ = "Sleeve Length"

            };

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            productMetricRepository.Setup(repo => repo.Read(invalidProductSize.ProductMetric.Id)).
                Returns(fetchedProductMetric);
            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            Action actual = () => productSizeService.Create(invalidProductSize);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_MetricSpecifiedValueZero_ThrowsArgumentException()
        {
            //Arrange
            ProductSize invalidProductSize = new ProductSize
            {
                ProductMetric = new ProductMetric { Id = 1 },
                Size = "XL",
                MetricXValue = 70,
                MetricYValue = 100,
                MetricZValue = 0
            };

            ProductMetric fetchedProductMetric = new ProductMetric
            {
                Id = 1,
                Name = "Oversized Hoodie",
                ProductModel = new ProductModel { Id = 1 },
                MetricX = "Length",
                MetricY = "Width",
                MetricZ = "Sleeve Length"

            };

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            productMetricRepository.Setup(repo => repo.Read(invalidProductSize.ProductMetric.Id)).
                Returns(fetchedProductMetric);
            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            Action actual = () => productSizeService.Create(invalidProductSize);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_MetricValueNegative_ThrowsArgumentException()
        {
            //Arrange
            ProductSize invalidProductSize = new ProductSize
            {
                ProductMetric = new ProductMetric { Id = 1 },
                Size = "XL",
                MetricXValue = 70,
                MetricYValue = -13,
                MetricZValue = 20
            };

            ProductMetric fetchedProductMetric = new ProductMetric
            {
                Id = 1,
                Name = "Oversized Hoodie",
                ProductModel = new ProductModel { Id = 1 },
                MetricX = "Length",
                MetricY = "Width",
                MetricZ = "Sleeve Length"

            };

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            productMetricRepository.Setup(repo => repo.Read(invalidProductSize.ProductMetric.Id)).
                Returns(fetchedProductMetric);
            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            Action actual = () => productSizeService.Create(invalidProductSize);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Read_IdExisting_ReturnsProductSizeWithSpecifiedId()
        {
            //Arrange
            int existingId = 12;
            ProductSize expected = new ProductSize
            {
                Id = existingId,
                ProductMetric = new ProductMetric { Id = 1 },
                Size = "XL",
                MetricXValue = 70,
                MetricYValue = -13,
                MetricZValue = 20
            };

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(existingId)).
                Returns(expected);
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();

            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            ProductSize actual = productSizeService.Read(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Read_IdNonExisting_ReturnsNull()
        {
            //Arrange
            int existingId = 12;
            ProductSize expected = null;

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(existingId)).
                Returns(expected);
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();

            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            ProductSize actual = productSizeService.Read(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_ProductSizeValid_ReturnsUpdatedProductSize()
        {
            //Arrange
            ProductSize validProductSize = new ProductSize
            {
                Id = 1,
                ProductMetric = null,
                Size = "L",
                MetricXValue = 70,
                MetricYValue = 100,
                MetricZValue = 75
            };

            ProductSize expected = validProductSize;

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(validProductSize.Id)).
                Returns(expected);
            productSizeRepository.Setup(repo => repo.Update(validProductSize)).
                Returns(expected);
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();

            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            ProductSize actual = productSizeService.Update(validProductSize);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_ProductSizeNull_ThrowsArgumentNullException()
        {
            //Arrange
            ProductSize invalidProductSize = null;

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            Action actual = () => productSizeService.Update(invalidProductSize);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Update_IdNonExisting_ThrowsArgumentException()
        {
            //Arrange
            ProductSize invalidProductSize = new ProductSize
            {
                Id = 1,
                ProductMetric = null,
                Size = "L",
                MetricXValue = 70,
                MetricYValue = 100,
                MetricZValue = 75
            };

            ProductSize nullProductSize = null;

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(invalidProductSize.Id)).
                Returns(nullProductSize);
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();

            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            Action actual = () => productSizeService.Update(invalidProductSize);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Update_ProductMetricSpecified_ThrowsArgumentException()
        {
            //Arrange
            ProductSize invalidProductSize = new ProductSize
            {
                Id = 1,
                ProductMetric = new ProductMetric { Id = 1 },
                Size = "L",
                MetricXValue = 70,
                MetricYValue = 100,
                MetricZValue = 75
            };

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            Action actual = () => productSizeService.Update(invalidProductSize);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_SizeNull_ThrowsArgumentException()
        {
            //Arrange
            ProductSize invalidProductSize = new ProductSize
            {
                Id = 1,
                ProductMetric = null,
                Size = null,
                MetricXValue = 70,
                MetricYValue = 100,
                MetricZValue = 75
            };

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            Action actual = () => productSizeService.Update(invalidProductSize);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_SizeEmpty_ThrowsArgumentException()
        {
            //Arrange
            ProductSize invalidProductSize = new ProductSize
            {
                Id = 1,
                ProductMetric = null,
                Size = "",
                MetricXValue = 70,
                MetricYValue = 100,
                MetricZValue = 75
            };

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            Action actual = () => productSizeService.Update(invalidProductSize);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_MetricsNotFilled_ThrowsArgumentException()
        {
            //Arrange
            ProductSize invalidProductSize = new ProductSize
            {
                Id = 1,
                ProductMetric = null,
                Size = "XL",
                MetricXValue = 70,
                MetricYValue = 100
            };

            ProductSize fetchedProductSize = new ProductSize
            {
                Id = 1,
                ProductMetric = new ProductMetric { Id = 1 },
                Size = "XL",
                MetricXValue = 70,
                MetricYValue = 100,
                MetricZValue = 150
            };

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(invalidProductSize.Id)).
                Returns(fetchedProductSize);
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            Action actual = () => productSizeService.Update(invalidProductSize);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_MetricSpecifiedValueZero_ThrowsArgumentException()
        {
            //Arrange
            ProductSize invalidProductSize = new ProductSize
            {
                Id = 1,
                ProductMetric = new ProductMetric { Id = 1 },
                Size = "XL",
                MetricXValue = 70,
                MetricYValue = 100,
                MetricZValue = 0
            };

            ProductSize fetchedProductSize = new ProductSize
            {
                Id = 1,
                ProductMetric = new ProductMetric { Id = 1 },
                Size = "XL",
                MetricXValue = 70,
                MetricYValue = 100,
                MetricZValue = 150
            };

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(invalidProductSize.Id)).
                Returns(fetchedProductSize);
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            Action actual = () => productSizeService.Update(invalidProductSize);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_MetricValueNegative_ThrowsArgumentException()
        {
            //Arrange
            ProductSize invalidProductSize = new ProductSize
            {
                Id = 1,
                ProductMetric = new ProductMetric { Id = 1 },
                Size = "XL",
                MetricXValue = 70,
                MetricYValue = 100,
                MetricZValue = -40
            };

            ProductSize fetchedProductSize = new ProductSize
            {
                Id = 1,
                ProductMetric = new ProductMetric { Id = 1 },
                Size = "XL",
                MetricXValue = 70,
                MetricYValue = 100,
                MetricZValue = 150
            };

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Read(invalidProductSize.Id)).
                Returns(fetchedProductSize);
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();
            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            Action actual = () => productSizeService.Update(invalidProductSize);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Delete_IdExisting_ReturnsDeletedProductSizeWithSpecifiedId()
        {
            //Arrange
            int existingId = 12;
            ProductSize expected = new ProductSize
            {
                Id = existingId,
                ProductMetric = new ProductMetric { Id = 1 },
                Size = "XL",
                MetricXValue = 70,
                MetricYValue = -13,
                MetricZValue = 20
            };

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Delete(existingId)).
                Returns(expected);
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();

            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            ProductSize actual = productSizeService.Delete(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_IdNonExisting_ReturnsNull()
        {
            //Arrange
            int existingId = 12;
            ProductSize expected = null;

            Mock<IProductSizeRepository> productSizeRepository = new Mock<IProductSizeRepository>();
            productSizeRepository.Setup(repo => repo.Delete(existingId)).
                Returns(expected);
            Mock<IProductMetricRepository> productMetricRepository = new Mock<IProductMetricRepository>();

            IProductSizeService productSizeService = new ProductSizeService(productSizeRepository.Object,
                productMetricRepository.Object);

            //Act
            ProductSize actual = productSizeService.Delete(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
