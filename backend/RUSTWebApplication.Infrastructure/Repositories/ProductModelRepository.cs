using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Infrastructure.Repositories
{
    public class ProductModelRepository: IProductModelRepository
    {

        private readonly RUSTWebApplicationContext _ctx;

        public ProductModelRepository(RUSTWebApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public ProductModel Create(ProductModel newProductModel)
        {
            _ctx.ProductModels.Attach(newProductModel).State = EntityState.Added;
            _ctx.SaveChanges();
            return newProductModel;
        }

        public ProductModel Read(int productModelId)
        {
            return _ctx.ProductModels.AsNoTracking().FirstOrDefault(ps => ps.Id == productModelId);
        }

        public IEnumerable<ProductModel> ReadAll()
        {
            return _ctx.ProductModels.AsNoTracking();
        }

        public ProductModel Update(ProductModel updatedProductModel)
        {
            _ctx.ProductModels.Attach(updatedProductModel).State = EntityState.Modified;
            _ctx.Entry(updatedProductModel).Reference(pm => pm.ProductCategory).IsModified = true;
            _ctx.SaveChanges();
            return updatedProductModel;
        }

        public ProductModel Delete(int productModelId)
        {
            var productModelToDelete = _ctx.ProductModels.FirstOrDefault(ps => ps.Id == productModelId);
            _ctx.ProductModels.Remove(productModelToDelete);
            _ctx.SaveChanges();
            return productModelToDelete;
        }
    }
}