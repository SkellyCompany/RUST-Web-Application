using System.Collections.Generic;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.ApplicationService
{
	public interface IProductCategoryService
	{
		ProductCategory Create(ProductCategory newProductCategory);

		ProductCategory Read(int productCategoryId);

		List<ProductCategory> ReadAll();

		ProductCategory Update(ProductCategory updatedProductCategory);

		ProductCategory Delete(int productCategoryId);
	}
}
