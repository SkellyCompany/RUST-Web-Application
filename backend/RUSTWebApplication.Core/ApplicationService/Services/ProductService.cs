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


		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public Product Create(Product newProduct)
        {
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
            return _productRepository.Update(updatedProduct);
        }

        public Product Delete(int productId)
        {
            return _productRepository.Delete(productId);
        }
    }
}
