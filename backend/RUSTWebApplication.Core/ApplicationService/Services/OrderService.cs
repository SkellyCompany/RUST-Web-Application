using System;
using System.Collections.Generic;
using System.Linq;
using RUSTWebApplication.Core.Entity.Order;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.ApplicationService.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IProductStockRepository _productStockRepository;


        public OrderService(IOrderRepository orderRepository,
            ICountryRepository countryRepository,
            IProductStockRepository productStockRepository)
		{
			_orderRepository = orderRepository;
            _countryRepository = countryRepository;
            _productStockRepository = productStockRepository;
		}

		public Order Create(Order newOrder)
        {
            ValidateCreate(newOrder);
            return _orderRepository.Create(newOrder);
        }

		public Order Read(int orderId)
        {
            return _orderRepository.Read(orderId);
        }

		public List<Order> ReadAll()
		{
			return _orderRepository.ReadAll().ToList();
        }

		public Order Update(Order updatedOrder)
        {
            ValidateUpdate(updatedOrder);
            return _orderRepository.Update(updatedOrder);
        }

        public Order Delete(int orderId)
        {
            return _orderRepository.Delete(orderId);
        }
        private void ValidateCreate(Order order)
        {
            ValidateNull(order);
            if (order.Id != default)
            {
                throw new ArgumentException("You are not allowed to specify an ID when creating a Order.");
            }

            ValidateOrderDate(order);
            ValidateDeliveryDate(order);
            ValidateOrderLines(order);

            ValidateAddress(order);
            ValidateCity(order);
            ValidateZipCode(order);
            ValidateCountry(order);

            //ValidateFirstName(order);
            //ValidateLastName(order);
            ValidateEmail(order);
            ValidatePhone(order);
        }

        private void ValidateUpdate(Order order)
        {
            ValidateNull(order);
            ValidateOrderDate(order);
            ValidateDeliveryDate(order);
            if (order.OrderLines != null)
            {
                throw new ArgumentException("OrderLines specified.");
            }

            ValidateAddress(order);
            ValidateCity(order);
            ValidateZipCode(order);
            ValidateCountry(order);

            //ValidateFirstName(order);
            //ValidateLastName(order);
            ValidateEmail(order);
            ValidatePhone(order);
            if (_orderRepository.Read(order.Id) == null)
            {
                throw new ArgumentException($"Cannot find a Order with an ID: {order.Id}");
            }
        }

        private void ValidateNull(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException("Order is null");
            }
        }
        private void ValidateOrderDate(Order order)
        {
            if (order.OrderDate.Day > DateTime.Now.Day)
            {
                throw new ArgumentException("OrderDate is after today");
            }
        }

        private void ValidateDeliveryDate(Order order)
        {
            if (order.DeliveryDate < order.OrderDate)
            {
                throw new ArgumentException("Delivery Date is before Order Date.");
            }
        }

        private void ValidateOrderLines(Order order)
        {
            if (order.OrderLines == null)
            {
                throw new ArgumentException("OrderLines is null");
            }
            List<ProductStock> allProductStock = _productStockRepository.ReadAll().ToList();
            order.OrderLines.ForEach(ol =>
                {
                    if (ol.ProductStock == null)
                    {
                        throw new ArgumentException($"ProductStock of OrderLine is null");
                    }

                    if (ol.Quantity <= 0)
                    {
                        throw new ArgumentException($"Quantity of OrderLine is equal or less then zero.");
                    }

                    if (ol.Quantity > ol.ProductStock.Quantity)
                    {
                        throw new ArgumentException("OrderLine Quantity bigger then ProductStock Quantity");
                    }

                    ProductStock productStock = allProductStock.Find(p => p.Id == ol.ProductStock.Id);
                    ol.ProductStock = productStock ?? throw new ArgumentException($"Cannot find ProductStock with the Id {ol.ProductStock.Id}");

                }
                );
        }

        private void ValidateAddress(Order order)
        {
            if (string.IsNullOrEmpty(order.Address))
            {
                throw new ArgumentException("Address is null or empty");
            }
        }
        private void ValidateCity(Order order)
        {
            if (string.IsNullOrEmpty(order.City))
            {
                throw new ArgumentException("City is null or empty");
            }
        }
        private void ValidateZipCode(Order order)
        {
            if (string.IsNullOrEmpty(order.ZipCode))
            {
                throw new ArgumentException("ZipCode is null or empty");
            }
        }
        private void ValidateCountry(Order order)
        {
            if (order.Country == null)
            {
                throw new ArgumentException("Country is null");
            }
            if (_countryRepository.Read(order.Country.Id) == null)
            {
                throw new ArgumentException($"Country not with the ID: {order.Country.Id} not found.");
            }
        }

        private void ValidateFirstName(Order order)
        {
            if (string.IsNullOrEmpty(order.FirstName))
            {
                throw new ArgumentException("First Name is null or empty");
            }
        }
        private void ValidateLastName(Order order)
        {
            if (string.IsNullOrEmpty(order.LastName))
            {
                throw new ArgumentException("Last Name is null or empty");
            }
        }
        private void ValidateEmail(Order order)
        {
            if (string.IsNullOrEmpty(order.Email))
            {
                throw new ArgumentException("Email is null or empty");
            }

            if (!order.Email.Contains("@") || !order.Email.Contains("."))
            {
                throw new ArgumentException("Invalid Email format");
            }
        }

        private void ValidatePhone(Order order)
        {
            if (string.IsNullOrEmpty(order.Phone))
            {
                throw new ArgumentException("Phone is null or empty");
            }
        }
    }
}
