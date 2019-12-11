using System.Collections.Generic;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.ApplicationService
{
	public interface IProductStockService
	{
		ProductStock Create(ProductStock newProductStock);

		ProductStock Read(int productStockId);

		List<ProductStock> ReadAll();

		ProductStock Update(ProductStock updatedProductStock);

		ProductStock Delete(int productStockId);
	}
}
