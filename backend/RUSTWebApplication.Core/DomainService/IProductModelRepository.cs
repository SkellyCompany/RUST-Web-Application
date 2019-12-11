using RUSTWebApplication.Core.Entity.Filters;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.DomainService
{
	public interface IProductModelRepository
	{
		ProductModel Create(ProductModel newProductModel);

		ProductModel Read(int productModelId);

		FilteredList<ProductModel> ReadAll(ProductModelFilter filter);

		ProductModel Update(ProductModel updatedProductModel);

		ProductModel Delete(int productModelId);
	}
}
