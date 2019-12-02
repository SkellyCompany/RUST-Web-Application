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


		public ProductSizeService(IProductSizeRepository productSizeRepository)
		{
			_productSizeRepository = productSizeRepository;
		}

		public ProductSize Create(ProductSize newProductSize)
        {
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
            return _productSizeRepository.Update(updatedProductSize);
        }

        public ProductSize Delete(int productSizeId)
        {
            return _productSizeRepository.Delete(productSizeId);
        }
    }
}
