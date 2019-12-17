using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Infrastructure.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly RUSTWebApplicationContext _ctx;


        public ProductRepository(RUSTWebApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public Product Create(Product newProduct)
        {
            _ctx.Products.Attach(newProduct).State = EntityState.Added;
            _ctx.SaveChanges();
            return newProduct;
        }

        public Product Read(int productId)
        {
            return _ctx.Products.AsNoTracking().Include(p => p.ProductStocks).FirstOrDefault(p => p.Id == productId);
        }

        public IEnumerable<Product> ReadAll()
        {
            return _ctx.Products.AsNoTracking().Include(p => p.ProductStocks);
        }

        public Product Update(Product updatedProduct)
        {
            _ctx.Products.Attach(updatedProduct).State = EntityState.Modified;
            _ctx.SaveChanges();
            return updatedProduct;
        }

        public Product Delete(int productId)
        {
            var productToDelete = _ctx.Products.FirstOrDefault(p => p.Id == productId);
            _ctx.Products.Remove(productToDelete);
            _ctx.SaveChanges();
            return productToDelete;
        }
    }
}