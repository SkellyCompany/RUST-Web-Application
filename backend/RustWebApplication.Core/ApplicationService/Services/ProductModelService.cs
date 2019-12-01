using System;
using System.Collections.Generic;
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
			throw new NotImplementedException();
		}

		public ProductModel Delete(int productModelId)
		{
			throw new NotImplementedException();
		}

		public ProductModel Read(int productModelId)
		{
			throw new NotImplementedException();
		}

		public List<ProductModel> ReadAll()
		{
			throw new NotImplementedException();
		}

		public ProductModel Update(ProductModel updatedProductModel)
		{
			throw new NotImplementedException();
		}
	}
}
