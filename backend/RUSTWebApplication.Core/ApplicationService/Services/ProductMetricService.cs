using System.Collections.Generic;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.ApplicationService.Services
{
    public class ProductMetricService : IProductMetricService
    {
        
        private readonly IProductMetricRepository _productMetricRepository;
        private readonly IProductModelRepository _productModelRepository;


        public ProductMetricService(IProductMetricRepository productMetricRepository,
            IProductModelRepository productModelRepository)
        {
            _productMetricRepository = productMetricRepository;
            _productModelRepository = productModelRepository;
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