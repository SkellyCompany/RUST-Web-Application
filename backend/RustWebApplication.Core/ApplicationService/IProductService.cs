using System;
using System.Collections.Generic;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.ApplicationService
{
    public interface IProductService
    {
        Product Create(Product newProduct);

        Product Read(int productId);

        List<Product> ReadAll();

        Product Update(Product updatedProduct);

        Product Delete(int productId);
    }
}
