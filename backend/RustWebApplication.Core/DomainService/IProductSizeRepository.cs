using System;
using System.Collections.Generic;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.DomainService
{
    public interface IProductSizeRepository
    {
        ProductSize Create(ProductSize newProductSize);

        ProductSize Read(int productSizeId);

        IEnumerable<ProductSize> ReadAll();

        ProductSize Update(ProductSize updatedProductSize);

        ProductSize Delete(int productSizeId);
    }
}
