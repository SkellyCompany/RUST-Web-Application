using System.Collections.Generic;
using RUSTWebApplication.Core.Entity.Order;

namespace RUSTWebApplication.Core.ApplicationService
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
