using System;
using System.Collections.Generic;
using Moq;
using RUSTWebApplication.Core.ApplicationService;
using RUSTWebApplication.Core.ApplicationService.Services;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Order;
using RUSTWebApplication.Core.Entity.Product;
using Xunit;

namespace RUSTWebApplication.UnitTests.Core
{
    public class OrderServiceTest
    {
        [Fact]
        public void Create_OrderValid_ReturnsCreatedOrderWithId()
        {
            //Arrange
            Order validOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 2
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 3
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country {  Id = 3},
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"

            };

            Order expected = new Order
            {
                Id = 1,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 2
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 3
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(repo => repo.Create(validOrder)).
                Returns(expected);
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            productCountryRepository.Setup(repo => repo.Read(validOrder.Country.Id)).
                Returns(validOrder.Country);
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.ReadAll()).
                Returns(new List<ProductStock> { validOrder.OrderLines[0].ProductStock,
                    validOrder.OrderLines[1].ProductStock });

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Order actual = orderService.Create(validOrder);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Create_OrderNull_ThrowsArgumentNullException()
        {
            //Arrange
            Order invalidOrder = null;

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Create_IdSpecified_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                Id = 1,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 2
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 3
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_OrderDateAfterToday_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now.AddDays(1),
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 2
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 3
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_DeliveryDateBeforeOrderDate_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(-3),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 2
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 3
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_OrderLinesNull_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = null,
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 1 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            productCountryRepository.Setup(repo => repo.Read(invalidOrder.Country.Id)).
                Returns(invalidOrder.Country);
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_OrderLineProductStockNull_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = null,
                        Quantity = 2
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 3
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 1 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            productCountryRepository.Setup(repo => repo.Read(invalidOrder.Country.Id)).
                Returns(invalidOrder.Country);
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.ReadAll()).
                Returns(new List<ProductStock> { invalidOrder.OrderLines[1].ProductStock });

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_OrderLineProductStockNonExisting_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 2
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 3
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 1 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            productCountryRepository.Setup(repo => repo.Read(invalidOrder.Country.Id)).
                Returns(invalidOrder.Country);
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.ReadAll()).
                Returns(new List<ProductStock> { invalidOrder.OrderLines[0].ProductStock});

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_OrderLineQuantityZero_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 2
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 0
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 1 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            productCountryRepository.Setup(repo => repo.Read(invalidOrder.Country.Id)).
                Returns(invalidOrder.Country);
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.ReadAll()).
                Returns(new List<ProductStock> { invalidOrder.OrderLines[0].ProductStock,
                    invalidOrder.OrderLines[1].ProductStock });

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_OrderLineQuantityNegative_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 2
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = -5
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 1 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            productCountryRepository.Setup(repo => repo.Read(invalidOrder.Country.Id)).
                Returns(invalidOrder.Country);
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.ReadAll()).
                Returns(new List<ProductStock> { invalidOrder.OrderLines[0].ProductStock,
                    invalidOrder.OrderLines[1].ProductStock });

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_OrderLineQuantityBiggerThenProductStockQuantity_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 2
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 10
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 1 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            productCountryRepository.Setup(repo => repo.Read(invalidOrder.Country.Id)).
                Returns(invalidOrder.Country);
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.ReadAll()).
                Returns(new List<ProductStock> { invalidOrder.OrderLines[0].ProductStock,
                    invalidOrder.OrderLines[1].ProductStock });
            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_AddressNull_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 3},
                        Quantity = 1
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 2},
                        Quantity = 2
                    },
                },
                Address = null,
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_AddressEmpty_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 3},
                        Quantity = 1
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 2},
                        Quantity = 2
                    },
                },
                Address = "",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }


        [Fact]
        public void Create_ZipCodeNull_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 3},
                        Quantity = 1
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 2},
                        Quantity = 2
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = null,
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_ZipCodeEmpty_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 3},
                        Quantity = 1
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 2},
                        Quantity = 2
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "",
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_CityNull_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 3},
                        Quantity = 1
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 2},
                        Quantity = 2
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = null,
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_CityEmpty_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 3},
                        Quantity = 1
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 2},
                        Quantity = 2
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-248",
                City = "",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_CountryNull_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 3},
                        Quantity = 1
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 2},
                        Quantity = 2
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = null,
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.ReadAll()).
                Returns(new List<ProductStock> { invalidOrder.OrderLines[0].ProductStock,
                    invalidOrder.OrderLines[1].ProductStock });

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_CountryNonExisting_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 3},
                        Quantity = 1
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 2},
                        Quantity = 2
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 1 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"
            };

            Country nullCountry = null;

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            productCountryRepository.Setup(repo => repo.Read(invalidOrder.Country.Id)).
                Returns(nullCountry);
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();
            productStockRepository.Setup(repo => repo.ReadAll()).
                Returns(new List<ProductStock> { invalidOrder.OrderLines[0].ProductStock,
                    invalidOrder.OrderLines[1].ProductStock });

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_PhoneNull_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 3},
                        Quantity = 1
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 2},
                        Quantity = 2
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 1 },
                Phone = null,
                Email = "schemaboi@gmail.com"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_PhoneEmpty_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 3},
                        Quantity = 1
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 2},
                        Quantity = 2
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 1 },
                Phone = "",
                Email = "schemaboi@gmail.com"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_EmailNull_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 3},
                        Quantity = 1
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 2},
                        Quantity = 2
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 1 },
                Phone = "+48594320005",
                Email = null
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_EmailEmpty_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 3},
                        Quantity = 1
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 2},
                        Quantity = 2
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 1 },
                Phone = "+48594320005",
                Email = ""
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_EmailIncorrect_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 3},
                        Quantity = 1
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock { Id = 2},
                        Quantity = 2
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 1 },
                Phone = "+48594320005",
                Email = "someincorrectmail"
            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Create(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Read_IdExisting_ReturnsOrderWithSpecifiedId()
        {
            //Arrange
            int existingId = 12;
            Order expected = new Order
            {
                Id = existingId,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 2
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 3
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(repo => repo.Read(existingId)).
                Returns(expected);
            Mock<ICountryRepository> productMetricRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productMetricRepository.Object,
                productStockRepository.Object);

            //Act
            Order actual = orderService.Read(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Read_IdNonExisting_ReturnsNull()
        {
            //Arrange
            int existingId = 12;
            Order expected = null;

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(repo => repo.Read(existingId)).
                Returns(expected);
            Mock<ICountryRepository> productMetricRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productMetricRepository.Object,
                productStockRepository.Object);

            //Act
            Order actual = orderService.Read(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_OrderValid_ReturnsUpdatedOrder()
        {
            //Arrange
            Order validOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = null,
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"

            };

            Order expected = validOrder;

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(repo => repo.Read(validOrder.Id)).
                Returns(validOrder);
            orderRepository.Setup(repo => repo.Update(validOrder)).
                Returns(expected);
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            productCountryRepository.Setup(repo => repo.Read(validOrder.Country.Id)).
                Returns(validOrder.Country);
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Order actual = orderService.Update(validOrder);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_OrderNull_ReturnsUpdatedOrder()
        {
            //Arrange
            Order invalidOrder = null;

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Update(invalidOrder);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Update_IdNonExisting_ReturnsUpdatedOrder()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = null,
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"

            };

            Order nullOrder = null;

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(repo => repo.Read(invalidOrder.Id)).
                Returns(nullOrder);
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            productCountryRepository.Setup(repo => repo.Read(invalidOrder.Country.Id)).
                Returns(invalidOrder.Country);
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Update(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_OrderDateAfterToday_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now.AddDays(2),
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = null,
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Update(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_DeliveryDateBeforeOrderDate_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(-4),
                OrderLines = null,
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Update(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_OrderLinesSpecified_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine { },
                    new OrderLine { }
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Update(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_AddressNull_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = null,
                Address = null,
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Update(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_AddressEmpty_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = null,
                Address = "",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Update(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_ZipCodeNull_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = null,
                Address = "Zelwerowicza 18/6",
                ZipCode = null,
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Update(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_ZipCodeEmpty_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = null,
                Address = "Zelwerowicza 18/6",
                ZipCode = null,
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Update(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_CityNull_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = null,
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = null,
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Update(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_CityEmpty_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = null,
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Update(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_CountryNull_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = null,
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warsaw",
                Country = null,
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(repo => repo.Read(invalidOrder.Id)).
                Returns(invalidOrder);
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Update(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_CountryNonExisting_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = null,
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warsaw",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"

            };

            Country nullCountry = null;

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(repo => repo.Read(invalidOrder.Id)).
                Returns(invalidOrder);
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            productCountryRepository.Setup(repo => repo.Read(invalidOrder.Country.Id)).
                Returns(nullCountry);
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Update(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_PhoneNull_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = null,
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warsaw",
                Country = new Country { Id = 3 },
                Phone = null,
                Email = "schemaboi@gmail.com"

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Update(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_PhoneEmpty_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = null,
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warsaw",
                Country = new Country { Id = 3 },
                Phone = "",
                Email = "schemaboi@gmail.com"

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Update(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_EmailNull_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = null,
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warsaw",
                Country = new Country { Id = 3 },
                Phone = "+48675903222",
                Email = null

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Update(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_EmailEmpty_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = null,
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warsaw",
                Country = new Country { Id = 3 },
                Phone = "+48675903222",
                Email = ""

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Update(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_EmailIncorrect_ThrowsArgumentException()
        {
            //Arrange
            Order invalidOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = null,
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warsaw",
                Country = new Country { Id = 3 },
                Phone = "+48675903222",
                Email = "someincorrectmailboy"

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            Mock<ICountryRepository> productCountryRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productCountryRepository.Object,
                productStockRepository.Object);

            //Act
            Action actual = () => orderService.Update(invalidOrder);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Delete_IdExisting_ReturnsDeletedOrderWithSpecifiedId()
        {
            //Arrange
            int existingId = 12;
            Order expected = new Order
            {
                Id = existingId,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(4),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 2
                    },
                    new OrderLine
                    {
                        ProductStock = new ProductStock
                        {
                            Id = 1,
                            Quantity = 8
                        },
                        Quantity = 3
                    },
                },
                Address = "Zelwerowicza 18/6",
                ZipCode = "54-238",
                City = "Warszawa",
                Country = new Country { Id = 3 },
                Phone = "+48509840123",
                Email = "schemaboi@gmail.com"

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(repo => repo.Delete(existingId)).
                Returns(expected);
            Mock<ICountryRepository> productMetricRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productMetricRepository.Object,
                productStockRepository.Object);

            //Act
            Order actual = orderService.Delete(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_IdNonExisting_ReturnsNull()
        {
            //Arrange
            int existingId = 12;
            Order expected = null;

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(repo => repo.Delete(existingId)).
                Returns(expected);
            Mock<ICountryRepository> productMetricRepository = new Mock<ICountryRepository>();
            Mock<IProductStockRepository> productStockRepository = new Mock<IProductStockRepository>();

            IOrderService orderService = new OrderService(orderRepository.Object,
                productMetricRepository.Object,
                productStockRepository.Object);

            //Act
            Order actual = orderService.Delete(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
