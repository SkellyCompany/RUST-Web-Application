using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Order;

namespace RUSTWebApplication.Infrastructure.Repositories
{
    public class OrderRepository: IOrderRepository
    {

        private readonly RUSTWebApplicationContext _ctx;

        public OrderRepository(RUSTWebApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public Order Create(Order newOrder)
        {
            _ctx.Orders.Attach(newOrder).State = EntityState.Added;
            _ctx.SaveChanges();
            return newOrder;
        }

        public Order Read(int orderId)
        {
            return _ctx.Orders.AsNoTracking().FirstOrDefault(o => o.Id == orderId);
        }

        public IEnumerable<Order> ReadAll()
        {
            return _ctx.Orders.AsNoTracking();
        }

        public Order Update(Order updatedOrder)
        {
            _ctx.Orders.Attach(updatedOrder).State = EntityState.Modified;
            _ctx.Entry(updatedOrder).Reference(o => o.Country).IsModified = true;
            _ctx.SaveChanges();
            return updatedOrder;
        }

        public Order Delete(int orderId)
        {
            var orderToDelete = _ctx.Orders.FirstOrDefault(pm => pm.Id == orderId);
            _ctx.Orders.Remove(orderToDelete);
            _ctx.SaveChanges();
            return orderToDelete;
        }
    }
}