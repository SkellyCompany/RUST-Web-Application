using System;
using System.Collections.Generic;
using System.Linq;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.ApplicationService.Services
{
	public class ProductTypeService : IProductTypeService
	{
		private readonly IProductTypeRepository _productTypeRepository;


		public ProductTypeService(IProductTypeRepository productTypeRepository)
		{
			_productTypeRepository = productTypeRepository;
		}

		public ProductType Create(ProductType newProductType)
        {
            return _productTypeRepository.Create(newProductType);
        }

		public ProductType Read(int productTypeId)
        {
            return _productTypeRepository.Read(productTypeId);
        }

		public List<ProductType> ReadAll()
        {
            return _productTypeRepository.ReadAll().ToList();
        }

		public ProductType Update(ProductType updatedProductType)
        {
            return _productTypeRepository.Update(updatedProductType);
        }

        public ProductType Delete(int productTypeId)
        {
            return _productTypeRepository.Delete(productTypeId);
        }
    }
}
