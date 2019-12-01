using System;
using System.Collections.Generic;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.ApplicationService
{
    public interface IOrderService
    {
        Order Create(Order newOrder);

        Order Read(int orderId);

        List<Order> ReadAll();

        Order Update(Order updatedOrder);

        Order Delete(int orderId);
    }
}
