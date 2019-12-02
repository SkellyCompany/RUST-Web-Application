using System.Collections.Generic;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.DomainService
{
	public interface IProductTypeRepository
	{
		ProductType Create(ProductType newProductType);

		ProductType Read(int productTypeId);

		IEnumerable<ProductType> ReadAll();

		ProductType Update(ProductType updatedProductType);

		ProductType Delete(int productTypeId);
	}
}
