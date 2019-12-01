using System.Collections.Generic;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.DomainService
{
	public interface IProductStockRepository
	{
		ProductStock Create(ProductStock newProductStock);

		ProductStock Read(int productStockId);

		IEnumerable<ProductStock> ReadAll();

		ProductStock Update(ProductStock updatedProductStock);

		ProductStock Delete(int productStockId);
	}
}
