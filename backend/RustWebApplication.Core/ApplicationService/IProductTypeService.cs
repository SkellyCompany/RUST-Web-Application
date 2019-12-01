using System.Collections.Generic;
using RUSTWebApplication.Core.Entity.Product

namespace RUSTWebApplication.Core.ApplicationService
{
	public interface IProductTypeService
	{
		ProductType Create(ProductType newProductType);

		ProductType Read(int productTypeId);

		List<ProductType> ReadAll();

		ProductType Update(ProductType updatedProductType);

		ProductType Delete(int productTypeId);
	}
}
