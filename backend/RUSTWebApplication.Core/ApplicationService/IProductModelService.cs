using RUSTWebApplication.Core.Entity.Filters;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.ApplicationService
{
	public interface IProductModelService
	{
		ProductModel Create(ProductModel newProductModel);

		ProductModel Read(int productModelId);

		FilteredList<ProductModel> ReadAll(ProductModelFilter filter);

		ProductModel Update(ProductModel updatedProductModel);

		ProductModel Delete(int productModelId);
	}
}
