using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.Entity.Order
{
	public class OrderLine
	{
        public int OrderId { get; set; }
        public int ProductStockId { get; set; }

        public Order Order { get; set; }
		public ProductStock ProductStock { get; set; }

		public int Quantity { get; set; }
	}
}
