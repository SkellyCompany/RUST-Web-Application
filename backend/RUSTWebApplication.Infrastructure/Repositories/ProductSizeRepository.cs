using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Infrastructure.Repositories
{
    public class ProductSizeRepository: IProductSizeRepository
    {

        private readonly RUSTWebApplicationContext _ctx;

        public ProductSizeRepository(RUSTWebApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public ProductSize Create(ProductSize newProductSize)
        {
            _ctx.ProductSizes.Attach(newProductSize).State = EntityState.Added;
            _ctx.SaveChanges();
            return newProductSize;
        }

        public ProductSize Read(int productSizeId)
        {
            return _ctx.ProductSizes.AsNoTracking().FirstOrDefault(c => c.Id == productSizeId);
        }

        public ProductSize ReadIncludeProductMetric(int productSizeId)
        {
            return _ctx.ProductSizes.AsNoTracking().
                Include(ps => ps.ProductMetric).
                FirstOrDefault(c => c.Id == productSizeId);
        }

        public IEnumerable<ProductSize> ReadAll()
        {
            return _ctx.ProductSizes.AsNoTracking();
        }

        public ProductSize Update(ProductSize updatedProductSize)
        {
            _ctx.ProductSizes.Attach(updatedProductSize).State = EntityState.Modified;
            _ctx.SaveChanges();
            return updatedProductSize;
        }

        public ProductSize Delete(int productSizeId)
        {
            var productSizeToDelete = _ctx.ProductSizes.FirstOrDefault(ps => ps.Id == productSizeId);
            _ctx.ProductSizes.Remove(productSizeToDelete);
            _ctx.SaveChanges();
            return productSizeToDelete;
        }
    }
}