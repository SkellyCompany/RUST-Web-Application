using System;
using System.Collections.Generic;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.ApplicationService
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
