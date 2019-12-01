using System.Collections.Generic;

namespace RUSTWebApplication.Core.Entity.Product
{
	public class ProductModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ProductType ProductType { get; set; }
		public double Price { get; set; }
		public List<Product> Products { get; set; }
	}
}
