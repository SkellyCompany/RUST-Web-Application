using System.Collections.Generic;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Infrastructure.Repositories
{
    public class ProductRepository: IProductRepository
    {
        public Product Create(Product newProduct)
        {
            throw new System.NotImplementedException();
        }

        public Product Read(int productId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public Product Update(Product updatedProduct)
        {
            throw new System.NotImplementedException();
        }

        public Product Delete(int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}