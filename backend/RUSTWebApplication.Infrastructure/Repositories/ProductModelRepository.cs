using System.Collections.Generic;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Infrastructure.Repositories
{
    public class ProductModelRepository: IProductModelRepository
    {
        public ProductModel Create(ProductModel newProductModel)
        {
            throw new System.NotImplementedException();
        }

        public ProductModel Read(int productModelId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductModel> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public ProductModel Update(ProductModel updatedProductModel)
        {
            throw new System.NotImplementedException();
        }

        public ProductModel Delete(int productModelId)
        {
            throw new System.NotImplementedException();
        }
    }
}