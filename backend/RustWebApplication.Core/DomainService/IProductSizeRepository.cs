using System.Collections.Generic;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.DomainService
{
	public interface IProductSizeRepository
	{
		ProductSize Create(ProductSize newProductSize);

		ProductSize Read(int productSizeId);

		IEnumerable<ProductSize> ReadAll();

		ProductSize Update(ProductSize updatedProductSize);

		ProductSize Delete(int productSizeId);
	}
}
