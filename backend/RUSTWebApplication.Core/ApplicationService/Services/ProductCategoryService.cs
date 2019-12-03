using System;
using System.Collections.Generic;
using System.Linq;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.ApplicationService.Services
{
	public class ProductCategoryService : IProductCategoryService
	{
		private readonly IProductCategoryRepository _productCategoryRepository;


		public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
		{
			_productCategoryRepository = productCategoryRepository;
		}

		public ProductCategory Create(ProductCategory newProductCategory)
        {
            return _productCategoryRepository.Create(newProductCategory);
        }

		public ProductCategory Read(int productCategoryId)
        {
            return _productCategoryRepository.Read(productCategoryId);
        }

		public List<ProductCategory> ReadAll()
        {
            return _productCategoryRepository.ReadAll().ToList();
        }

		public ProductCategory Update(ProductCategory updatedProductCategory)
        {
            return _productCategoryRepository.Update(updatedProductCategory);
        }

        public ProductCategory Delete(int productCategoryId)
        {
            return _productCategoryRepository.Delete(productCategoryId);
        }
    }
}
