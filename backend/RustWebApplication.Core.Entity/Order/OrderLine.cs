using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.Entity.Order
{
	public class OrderLine
	{
		public Order Order { get; set; }
		public ProductStock ProductStock { get; set; }
		public int Quantity { get; set; }
	}
}
