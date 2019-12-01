using System.Collections.Generic;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.DomainService
{
	public interface IProductRepository
	{
		Product Create(Product newProduct);

		Product Read(int productId);

		IEnumerable<Product> ReadAll();

		Product Update(Product updatedProduct);

		Product Delete(int productId);
	}
}
