using System;
using System.Collections.Generic;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.DomainService
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
