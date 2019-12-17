using System;
using System.Linq;
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
            ValidateCreate(newProductMetric);
            return _productMetricRepository.Create(newProductMetric);
        }

        public ProductMetric Read(int productMetricId)
        {
            return _productMetricRepository.Read(productMetricId);
        }

        public List<ProductMetric> ReadAll()
        {
            return _productMetricRepository.ReadAll().ToList();
        }

        public ProductMetric Update(ProductMetric updatedProductMetric)
        {
            ValidateUpdate(updatedProductMetric);
            return _productMetricRepository.Update(updatedProductMetric);
        }

        public ProductMetric Delete(int productMetricId)
        {
            return _productMetricRepository.Delete(productMetricId);
        }
        private void ValidateCreate(ProductMetric productMetric)
        {
            ValidateNull(productMetric);
            if (productMetric.Id != default)
            {
                throw new ArgumentException("You are not allowed to specify an ID when creating a ProductMetric.");
            }
            ValidateName(productMetric);
            ValidateMetricXValue(productMetric);
        }

        private void ValidateUpdate(ProductMetric productMetric)
        {
            ValidateNull(productMetric);
            ValidateName(productMetric);
            ValidateMetricXValue(productMetric);
            if (_productMetricRepository.Read(productMetric.Id) == null)
            {
                throw new ArgumentException($"Cannot find a Product Metric with the ID: {productMetric.Id}");
            }
        }

        private void ValidateNull(ProductMetric productSize)
        {
            if (productSize == null)
            {
                throw new ArgumentNullException("ProductMetric cannot be null");
            }
        }

        private void ValidateName(ProductMetric productMetric)
        {
            if (string.IsNullOrEmpty(productMetric.Name))
            {
                throw new ArgumentException("You need to specify a Name for the ProductMetric.");
            }
        }

        private void ValidateMetricXValue(ProductMetric productMetric)
        {
            if (string.IsNullOrEmpty(productMetric.MetricX))
            {
                throw new ArgumentException("You need to specify a MetricX for the ProductMetric");
            }
        }
    }
}