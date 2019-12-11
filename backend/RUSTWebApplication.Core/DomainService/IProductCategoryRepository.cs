using System.Collections.Generic;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.DomainService
{
	public interface IProductCategoryRepository
	{
		ProductCategory Create(ProductCategory newProductCategory);

		ProductCategory Read(int productCategoryId);

		IEnumerable<ProductCategory> ReadAll();

		ProductCategory Update(ProductCategory updatedProductCategory);

		ProductCategory Delete(int productCategoryId);
	}
}
