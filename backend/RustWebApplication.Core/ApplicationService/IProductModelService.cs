using System;
using System.Collections.Generic;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.ApplicationService
{
    public interface IProductModelService
    {
        ProductModel Create(ProductModel newProductModel);

        ProductModel Read(int productModelId);

        List<ProductModel> ReadAll();

        ProductModel Update(ProductModel updatedProductModel);

        ProductModel Delete(int productModelId);
    }
}
