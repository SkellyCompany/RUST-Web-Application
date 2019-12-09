using System;
using System.Collections.Generic;
using System.Linq;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.ApplicationService.Services
{
	public class ProductSizeService : IProductSizeService
	{
		private readonly IProductSizeRepository _productSizeRepository;
        private readonly IProductMetricRepository _productMetricRepository;

        public ProductSizeService(IProductSizeRepository productSizeRepository,
            IProductMetricRepository productMetricRepository)
		{
			_productSizeRepository = productSizeRepository;
            _productMetricRepository = productMetricRepository;
		}

		public ProductSize Create(ProductSize newProductSize)
        {
            ValidateCreate(newProductSize);
            return _productSizeRepository.Create(newProductSize);
        }

		public ProductSize Read(int productSizeId)
        {
            return _productSizeRepository.Read(productSizeId);
        }

		public List<ProductSize> ReadAll()
        {
            return _productSizeRepository.ReadAll().ToList();
        }

		public ProductSize Update(ProductSize updatedProductSize)
        {
            ValidateUpdate(updatedProductSize);
            return _productSizeRepository.Update(updatedProductSize);
        }

        public ProductSize Delete(int productSizeId)
        {
            return _productSizeRepository.Delete(productSizeId);
        }
        private void ValidateCreate(ProductSize  productSize)
        {
            ValidateNull(productSize);
            if (productSize.Id != default)
            {
                throw new ArgumentException("You are not allowed to specify an ID when creating a ProductSize.");
            }
            ValidateSize(productSize);
            ValidateProductMetric(productSize);
            ValidateMetricValues(productSize);
        }

        private void ValidateUpdate(ProductSize productSize)
        {
            ValidateNull(productSize);
            ValidateSize(productSize);
            if (productSize.ProductMetric != null)
            {
                throw new ArgumentException("You are not allowed to specify a ProductMetric when updating the ProductSize.");
            }
            if (_productSizeRepository.Read(productSize.Id) == null)
            {
                throw new ArgumentNullException($"Cannot find a ProductSize with the ID: {productSize.Id}");
            }
        }

        private void ValidateNull(ProductSize productSize)
        {
            if (productSize == null)
            {
                throw new ArgumentNullException("Product Size cannot be null");
            }
        }

        private void ValidateProductMetric(ProductSize productSize)
        {
            if (productSize.ProductMetric == null)
            {
                throw new ArgumentException("You need to specify a ProductMetric for the ProductSize.");
            }

            if (_productMetricRepository.Read(productSize.ProductMetric.Id) == null)
            {
                throw new ArgumentException($"Product Metric with the ID: {productSize.ProductMetric.Id} doesn't exist.'");
            }
        }

        private void ValidateSize(ProductSize productSize)
        {
            if (string.IsNullOrEmpty(productSize.Size))
            {
                throw new ArgumentException("You need to specify a Size for the ProductSize.");
            }
        }

        private void ValidateMetricValues(ProductSize productSize)
        {
            ProductMetric sizeMetric = _productMetricRepository.Read(productSize.ProductMetric.Id);
            if(!string.IsNullOrEmpty(sizeMetric.MetricX))
            {
                ValidateMetricXValue(productSize);
            }
            if (!string.IsNullOrEmpty(sizeMetric.MetricY))
            {
                ValidateMetricYValue(productSize);
            }
            if (!string.IsNullOrEmpty(sizeMetric.MetricZ))
            {
                ValidateMetricZValue(productSize);
            }
        }

        private void ValidateMetricXValue(ProductSize productSize)
        {
            if (productSize.MetricXValue <= 0)
            {
                throw new ArgumentException("MetricX cannot be less then or equal to zero");
            }
        }

        private void ValidateMetricYValue(ProductSize productSize)
        {
            if (productSize.MetricYValue <= 0)
            {
                throw new ArgumentException("MetricY cannot be less then or equal to zero");
            }
        }

        private void ValidateMetricZValue(ProductSize productSize)
        {
            if (productSize.MetricZValue <= 0)
            {
                throw new ArgumentException("MetricZ can not be less or equals zero");
            }
        }
    }
}
