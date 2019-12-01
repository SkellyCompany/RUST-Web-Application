using System;
using System.Collections.Generic;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.ApplicationService
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
