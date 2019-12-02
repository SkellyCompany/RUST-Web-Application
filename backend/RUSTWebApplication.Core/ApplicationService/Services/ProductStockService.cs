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


		public ProductStockService(IProductStockRepository productStockRepository)
		{
			_productStockRepository = productStockRepository;
		}

		public ProductStock Create(ProductStock newProductStock)
        {
            return _productStockRepository.Create(newProductStock);
        }

		public ProductStock Delete(int productStockId)
        {
            return _productStockRepository.Delete(productStockId);
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
	}
}
