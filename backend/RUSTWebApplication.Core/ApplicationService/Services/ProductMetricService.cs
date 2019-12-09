using System;
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
            ValidateCreate(newProductMetric);
            return _productMetricRepository.Create(newProductMetric);
        }

        public ProductMetric Read(int productMetricId)
        {
            return _productMetricRepository.Read(productMetricId);
        }

        public List<ProductMetric> ReadAll()
        {
            return _productMetricRepository.ReadAll();
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
            ValidateProductModel(productMetric);
        }

        private void ValidateUpdate(ProductMetric productMetric)
        {
            ValidateNull(productMetric);
            if (_productMetricRepository.Read(productMetric.Id) == null)
            {
                throw new ArgumentException($"Cannot find a Product Metric with the ID: {productMetric.Id}");
            }
            ValidateName(productMetric);
            ValidateMetricXValue(productMetric);
            ValidateProductModel(productMetric);

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
        private void ValidateProductModel(ProductMetric productMetric)
        {
            if (productMetric.ProductModel == null)
            {
                throw new ArgumentException("You need to specify a ProductModel for the ProductMetric.");
            }

            if (_productModelRepository.Read(productMetric.ProductModel.Id) == null)
            {
                throw new ArgumentException($"Product Model with the ID: {productMetric.ProductModel.Id} doesn't exist.'");
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