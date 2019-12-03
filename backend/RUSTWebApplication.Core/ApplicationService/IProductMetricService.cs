using System.Collections.Generic;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.ApplicationService
{
    public interface IProductMetricService
    {
        ProductMetric Create(ProductMetric newProductMetric);

        ProductMetric Read(int productMetricId);

        List<ProductMetric> ReadAll();

        ProductMetric Update(ProductMetric updatedProductMetric);

        ProductMetric Delete(int productMetricId);
    }
}