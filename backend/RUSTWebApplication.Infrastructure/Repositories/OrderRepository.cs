using System.Collections.Generic;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Order;

namespace RUSTWebApplication.Infrastructure.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        public Order Create(Order newOrder)
        {
            throw new System.NotImplementedException();
        }

        public Order Read(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public Order Update(Order updatedOrder)
        {
            throw new System.NotImplementedException();
        }

        public Order Delete(int orderId)
        {
            throw new System.NotImplementedException();
        }
    }
}