using System;
using System.Collections.Generic;
using System.Linq;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;


namespace RUSTWebApplication.Core.ApplicationService.Services
{
	public class ProductStockService : IProductStockService
	{
		private readonly IProductStockRepository _productStockRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductSizeRepository _productSizeRepository;


        public ProductStockService(
            IProductStockRepository productStockRepository,
            IProductRepository productRepository,
            IProductSizeRepository productSizeRepository)
		{
			_productStockRepository = productStockRepository;
            _productRepository = productRepository;
            _productSizeRepository = productSizeRepository;
        }

		public ProductStock Create(ProductStock newProductStock)
        {
            ValidateCreate(newProductStock);
            return _productStockRepository.Create(newProductStock);
        }

		public ProductStock Read(int productStockId)
        {
            return _productStockRepository.Read(productStockId);
        }

		public List<ProductStock> ReadAll()
        {
            return _productStockRepository.ReadAll().ToList();
        }

		public ProductStock Update(ProductStock updatedProductStock)
        {
            ValidateUpdate(updatedProductStock);
            return _productStockRepository.Update(updatedProductStock);
        }

        public ProductStock Delete(int productStockId)
        {
            return _productStockRepository.Delete(productStockId);
        }
        private void ValidateCreate(ProductStock productStock)
        {
            ValidateNull(productStock);
	        if (productStock.Id != default)
            {
                throw new ArgumentException("You are not allowed to specify an ID when creating a Country.");
            }
	        ValidateQuantity(productStock);
            ValidateProduct(productStock);
            ValidateProductSize(productStock);
        }

        private void ValidateUpdate(ProductStock productStock)
        {
            ValidateNull(productStock);
            ValidateQuantity(productStock);
            if (productStock.Product != null)
            {
                throw new ArgumentException("You are not allowed to specify a Product when updating a ProductStock.");
            }
            if (productStock.ProductSize != null)
            {
                throw new ArgumentException("You are not allowed to specify a ProductSize when updating a ProductStock.");
            }
            if (_productStockRepository.Read(productStock.Id) == null)
            {
                throw new ArgumentException($"Cannot find a ProductStock with the ID: {productStock.Id}");
            }
        }

        private void ValidateNull(ProductStock productStock)
        {
            if (productStock == null)
            {
                throw new ArgumentNullException("ProductStock cannot be null");
            }
        }

        private void ValidateProduct(ProductStock productStock)
        {
            if (productStock.Product == null)
            {
                throw new ArgumentException("You need to specify a Product for the ProductStock.");
            }
            if (_productRepository.Read(productStock.Product.Id) == null)
            {
                throw new ArgumentException($"The Product with the ID: {productStock.Product.Id} doesn't exist.");
            }
        }

        private void ValidateProductSize(ProductStock productStock)
        {
            if (productStock.ProductSize == null)
            {
                throw new ArgumentException("You need to specify a ProductSize for the ProductStock.");
            }
            if (_productSizeRepository.Read(productStock.ProductSize.Id) == null)
            {
                throw new ArgumentException($"The ProductSize with the ID: {productStock.ProductSize.Id} doesn't exist.");
            }
        }

        private void ValidateQuantity(ProductStock productStock)
        {
            if (productStock.Quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative.");
            }

        }
    }
}
