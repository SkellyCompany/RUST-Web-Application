using System;
using System.Collections.Generic;
using RustWebApplication.Core.DomainService;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.ApplicationService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;


        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Create(Order newOrder)
        {
            throw new NotImplementedException();
        }

        public Order Delete(int orderId)
        {
            throw new NotImplementedException();
        }

        public Order Read(int orderId)
        {
            throw new NotImplementedException();
        }

        public List<Order> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Order Update(Order updatedOrder)
        {
            throw new NotImplementedException();
        }
    }
}
