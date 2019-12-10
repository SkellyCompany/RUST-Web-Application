using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Infrastructure.Repositories
{
    public class ProductStockRepository: IProductStockRepository
    {

        private readonly RUSTWebApplicationContext _ctx;

        public ProductStockRepository(RUSTWebApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public ProductStock Create(ProductStock newProductStock)
        {
            _ctx.ProductStocks.Attach(newProductStock).State = EntityState.Added;
            _ctx.SaveChanges();
            return newProductStock;
        }

        public ProductStock Read(int productStockId)
        {
            return _ctx.ProductStocks.AsNoTracking().FirstOrDefault(c => c.Id == productStockId);
        }

        public IEnumerable<ProductStock> ReadAll()
        {
            return _ctx.ProductStocks.AsNoTracking();
        }

        public ProductStock Update(ProductStock updatedProductStock)
        {
            _ctx.ProductStocks.Attach(updatedProductStock).State = EntityState.Modified;
            _ctx.SaveChanges();
            return updatedProductStock;
        }

        public ProductStock Delete(int productStockId)
        {
            var productStockToDelete = _ctx.ProductStocks.FirstOrDefault(ps => ps.Id == productStockId);
            _ctx.ProductStocks.Remove(productStockToDelete);
            _ctx.SaveChanges();
            return productStockToDelete;
        }
    }
}