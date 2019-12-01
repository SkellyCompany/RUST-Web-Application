using System.Collections.Generic;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.ApplicationService
{
	public interface IProductModelService
	{
		ProductModel Create(ProductModel newProductModel);

		ProductModel Read(int productModelId);

		List<ProductModel> ReadAll();

		ProductModel Update(ProductModel updatedProductModel);

		ProductModel Delete(int productModelId);
	}
}
