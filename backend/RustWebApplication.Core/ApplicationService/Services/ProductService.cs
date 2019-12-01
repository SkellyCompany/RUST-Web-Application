using System;
using System.Collections.Generic;
using RustWebApplication.Core.DomainService;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.ApplicationService.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Create(Product newProduct)
        {
            throw new NotImplementedException();
        }

        public Product Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public Product Read(int productId)
        {
            throw new NotImplementedException();
        }

        public List<Product> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Product Update(Product updatedProduct)
        {
            throw new NotImplementedException();
        }
    }
}
