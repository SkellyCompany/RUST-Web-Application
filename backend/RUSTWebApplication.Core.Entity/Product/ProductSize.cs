namespace RUSTWebApplication.Core.Entity.Product
{
	public class ProductSize
	{
		public int Id { get; set; }
		public ProductCategory ProductCategory { get; set; }
		public string Size { get; set; }
	}
}
