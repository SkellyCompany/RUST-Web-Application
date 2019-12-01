using System;
using System.Collections.Generic;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.DomainService
{
    public interface IProductRepository
    {
        Product Create(Product newProduct);

        Product Read(int productId);

        IEnumerable<Product> ReadAll();

        Product Update(Product updatedProduct);

        Product Delete(int productId);
    }
}
