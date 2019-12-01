using System;
using System.Collections.Generic;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.DomainService
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
