using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Infrastructure.Repositories
{
    public class ProductMetricRepository : IProductMetricRepository
    {
        private readonly RUSTWebApplicationContext _ctx;


        public ProductMetricRepository(RUSTWebApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public ProductMetric Create(ProductMetric newProductMetric)
        {
            _ctx.ProductMetrics.Attach(newProductMetric).State = EntityState.Added;
            _ctx.SaveChanges();
            return newProductMetric;
        }

        public ProductMetric Read(int productMetricId)
        {
            return _ctx.ProductMetrics.AsNoTracking().FirstOrDefault(pm => pm.Id == productMetricId);
        }

        public IEnumerable<ProductMetric> ReadAll()
        {
            return _ctx.ProductMetrics.AsNoTracking();
        }

        public ProductMetric Update(ProductMetric updatedProductMetric)
        {
            _ctx.ProductMetrics.Attach(updatedProductMetric).State = EntityState.Modified;
            _ctx.SaveChanges();
            return updatedProductMetric;
        }

        public ProductMetric Delete(int productMetricId)
        {
            var productMetricToDelete = _ctx.ProductMetrics.FirstOrDefault(pm => pm.Id == productMetricId);
            _ctx.ProductMetrics.Remove(productMetricToDelete);
            _ctx.SaveChanges();
            return productMetricToDelete;
        }
    }
}