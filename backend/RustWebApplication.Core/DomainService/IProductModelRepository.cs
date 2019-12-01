using System;
using System.Collections.Generic;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.DomainService
{
    public interface IProductModelRepository
    {
        ProductModel Create(ProductModel newProductModel);

        ProductModel Read(int productModelId);

        IEnumerable<ProductModel> ReadAll();

        ProductModel Update(ProductModel updatedProductModel);

        ProductModel Delete(int productModelId);
    }
}
