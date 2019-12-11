using System.Collections.Generic;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.ApplicationService
{
	public interface IProductService
	{
		Product Create(Product newProduct);

		Product Read(int productId);

		List<Product> ReadAll();

		Product Update(Product updatedProduct);

		Product Delete(int productId);
	}
}
