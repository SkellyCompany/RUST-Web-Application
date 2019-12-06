using System;
using System.Collections.Generic;
using System.Linq;
using RUSTWebApplication.Core.Entity.Order;
using RUSTWebApplication.Core.DomainService;

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
            return _orderRepository.Update(updatedOrder);
        }

        public Order Delete(int orderId)
        {
            return _orderRepository.Delete(orderId);
        }
    }
}
