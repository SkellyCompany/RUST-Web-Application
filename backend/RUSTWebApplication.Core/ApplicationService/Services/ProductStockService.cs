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


        public ProductStockService(IProductStockRepository productStockRepository,
            IProductRepository productRepository,
            IProductSizeRepository productSizeRepository)
		{
			_productStockRepository = productStockRepository;
            _productRepository = productRepository;
            _productSizeRepository = productSizeRepository;
        }

		public ProductStock Create(ProductStock newProductStock)
        {
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
            return _productStockRepository.Update(updatedProductStock);
        }

        public ProductStock Delete(int productStockId)
        {
            return _productStockRepository.Delete(productStockId);
        }
    }
}
