using System.Collections.Generic;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.ApplicationService.Services
{
    public class ProductMetricService : IProductMetricService
    {
        
        private readonly IProductMetricRepository _productMetricRepository;


        public ProductMetricService(IProductMetricRepository productMetricRepository)
        {
            _productMetricRepository = productMetricRepository;
        }
        
        public ProductMetric Create(ProductMetric newProductMetric)
        {
            throw new System.NotImplementedException();
        }

        public ProductMetric Read(int productMetricId)
        {
            throw new System.NotImplementedException();
        }

        public List<ProductMetric> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public ProductMetric Update(ProductMetric updatedProductMetric)
        {
            throw new System.NotImplementedException();
        }

        public ProductMetric Delete(int productMetricId)
        {
            throw new System.NotImplementedException();
        }
    }
}