using System.Collections.Generic;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Infrastructure.Repositories
{
    public class ProductStockRepository: IProductStockRepository
    {
        public ProductStock Create(ProductStock newProductStock)
        {
            throw new System.NotImplementedException();
        }

        public ProductStock Read(int productStockId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductStock> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public ProductStock Update(ProductStock updatedProductStock)
        {
            throw new System.NotImplementedException();
        }

        public ProductStock Delete(int productStockId)
        {
            throw new System.NotImplementedException();
        }
    }
}