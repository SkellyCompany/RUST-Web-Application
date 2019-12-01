using System;
using System.Collections.Generic;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.DomainService
{
    public interface IOrderRepository
    {
        Order Create(Order newOrder);

        Order Read(int orderId);

        IEnumerable<Order> ReadAll();

        Order Update(Order updatedOrder);

        Order Delete(int orderId);
    }
}
