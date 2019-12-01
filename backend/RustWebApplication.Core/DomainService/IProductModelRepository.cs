using System.Collections.Generic;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.DomainService
{
	public interface IProductModelRepository
	{
		ProductModel Create(ProductModel newProductModel);

		ProductModel Read(int productModelId);

		IEnumerable<ProductModel> ReadAll();

		ProductModel Update(ProductModel updatedProductModel);

		ProductModel Delete(int productModelId);
	}
}
