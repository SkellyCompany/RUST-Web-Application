using System.Collections.Generic;
using RUSTWebApplication.Core.Entity.Order;

namespace RUSTWebApplication.Core.DomainService
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
