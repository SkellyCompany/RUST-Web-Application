using System.Collections.Generic;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Infrastructure.Repositories
{
    public class ProductCategoryRepository: IProductCategoryRepository
    {
        public ProductCategory Create(ProductCategory newProductCategory)
        {
            throw new System.NotImplementedException();
        }

        public ProductCategory Read(int productCategoryId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductCategory> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public ProductCategory Update(ProductCategory updatedProductCategory)
        {
            throw new System.NotImplementedException();
        }

        public ProductCategory Delete(int productCategoryId)
        {
            throw new System.NotImplementedException();
        }
    }
}