using System;
using System.Collections.Generic;
using System.Linq;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.ApplicationService.Services
{
	public class ProductModelService : IProductModelService
	{
		private readonly IProductModelRepository _productModelRepository;


		public ProductModelService(IProductModelRepository productModelRepository)
		{
			_productModelRepository = productModelRepository;
		}

		public ProductModel Create(ProductModel newProductModel)
        {
            return _productModelRepository.Create(newProductModel);
        }

		public ProductModel Delete(int productModelId)
        {
            return _productModelRepository.Delete(productModelId);
        }

		public ProductModel Read(int productModelId)
        {
            return _productModelRepository.Read(productModelId);
        }

		public List<ProductModel> ReadAll()
        {
            return _productModelRepository.ReadAll().ToList();
        }

		public ProductModel Update(ProductModel updatedProductModel)
        {
            return _productModelRepository.Update(updatedProductModel);
        }
	}
}
