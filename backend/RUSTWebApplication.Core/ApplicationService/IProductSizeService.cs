using System.Collections.Generic;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.ApplicationService
{
	public interface IProductSizeService
	{
		ProductSize Create(ProductSize newProductSize);

		ProductSize Read(int productSizeId);

		List<ProductSize> ReadAll();

		ProductSize Update(ProductSize updatedProductSize);

		ProductSize Delete(int productSizeId);
	}
}
