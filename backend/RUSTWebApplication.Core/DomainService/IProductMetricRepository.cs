using System.Collections.Generic;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.DomainService
{
    public interface IProductMetricRepository
    {
        ProductMetric Create(ProductMetric newProductMetric);

        ProductMetric Read(int productMetricId);

        IEnumerable<ProductMetric> ReadAll();

        ProductMetric Update(ProductMetric updatedProductMetric);

        ProductMetric Delete(int productMetricId);
    }
}