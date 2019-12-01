using System;
using System.Collections.Generic;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.ApplicationService
{
    public interface IProductSizeService
    {
        ProductSize Create(ProductSize newProductSize);

        ProductSize Read(int productSizeId);

        List<ProductSize> ReadAll();

        ProductSize Update(ProductSize updatedProductSize);

        ProductSize Delete(int productSizeId);
    }
}
