using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Infrastructure.Repositories
{
    public class ProductCategoryRepository: IProductCategoryRepository
    {

        private readonly RUSTWebApplicationContext _ctx;

        public ProductCategoryRepository(RUSTWebApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public ProductCategory Create(ProductCategory newProductCategory)
        {
            _ctx.ProductCategories.Attach(newProductCategory).State = EntityState.Added;
            _ctx.SaveChanges();
            return newProductCategory;
        }

        public ProductCategory Read(int productCategoryId)
        {
            return _ctx.ProductCategories.AsNoTracking().FirstOrDefault(pc => pc.Id == productCategoryId);
        }

        public IEnumerable<ProductCategory> ReadAll()
        {
            return _ctx.ProductCategories.AsNoTracking();
        }

        public ProductCategory Update(ProductCategory updatedProductCategory)
        {
            _ctx.ProductCategories.Attach(updatedProductCategory).State = EntityState.Modified;
            _ctx.SaveChanges();
            return updatedProductCategory;
        }

        public ProductCategory Delete(int productCategoryId)
        {
            var productCategoryToDelete = _ctx.ProductCategories.FirstOrDefault(pc => pc.Id == productCategoryId);
            _ctx.ProductCategories.Remove(productCategoryToDelete);
            _ctx.SaveChanges();
            return productCategoryToDelete;
        }
    }
}