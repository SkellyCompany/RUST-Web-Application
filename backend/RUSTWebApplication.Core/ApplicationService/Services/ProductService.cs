using System;
using System.Collections.Generic;
using System.Linq;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.ApplicationService.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
        private readonly IProductModelRepository _productModelRepository;


        public ProductService(IProductRepository productRepository,
            IProductModelRepository productModelRepository)
		{
			_productRepository = productRepository;
            _productModelRepository = productModelRepository;
		}

		public Product Create(Product newProduct)
        {
            ValidateCreate(newProduct);
            return _productRepository.Create(newProduct);
        }

		public Product Read(int productId)
        {
            return _productRepository.Read(productId);
        }

		public List<Product> ReadAll()
        {
            return _productRepository.ReadAll().ToList();
        }

		public Product Update(Product updatedProduct)
        {
            ValidateUpdate(updatedProduct);
            return _productRepository.Update(updatedProduct);
        }

        public Product Delete(int productId)
        {
            return _productRepository.Delete(productId);
        }
        private void ValidateCreate(Product product)
        {
            ValidateNull(product);
            if (product.Id != default)
            {
                throw new ArgumentException("You are not allowed to specify an ID when creating a Product.");
            }
            ValidateColor(product);
	    ValidateProductStock(product);
            ValidateProductModel(product);
        }

        private void ValidateUpdate(Product product)
        {
            ValidateNull(product);
	    ValidateColor(product);
	    ValidateProductStock(product);
	    if (product.ProductModel != null)
            {
                throw new ArgumentException("You are not allowed to specify the Project Model when updating a Product.");
            }	    
            if (_productRepository.Read(product.Id) == null)
            {
                throw new ArgumentException($"Cannot find a Product with an ID: {product.Id}");
            }          
            
        }

        private void ValidateNull(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product cannot be null");
            }
        }

        private void ValidateColor(Product product)
        {
            if (string.IsNullOrEmpty(product.Color))
            {
                throw new ArgumentException("You need to specify a Color.");
            }
        }

        private void ValidateProductModel(Product product)
        {
            if (product.ProductModel == null)
            {
                throw new ArgumentException("You need to specify a Product Model");
            }

            if (_productModelRepository.Read(product.ProductModel.Id) == null)
            {
                throw new ArgumentException($"Product Model with the ID: {product.ProductModel.Id} doesn't exist'");
            }
        }

        private void ValidateProductStock(Product product)
        {
            if (product.ProductStocks != null)
            {
                throw new ArgumentException("Product Stock must be null");
            }
        }
    }
}
