﻿using System;
using System.Collections.Generic;
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
			throw new NotImplementedException();
		}

		public ProductType Delete(int productTypeId)
		{
			throw new NotImplementedException();
		}

		public ProductType Read(int productTypeId)
		{
			throw new NotImplementedException();
		}

		public List<ProductType> ReadAll()
		{
			throw new NotImplementedException();
		}

		public ProductType Update(ProductType updatedProductType)
		{
			throw new NotImplementedException();
		}
	}
}
