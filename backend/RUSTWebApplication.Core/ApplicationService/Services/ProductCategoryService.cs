using System;
using System.Linq;
using System.Collections.Generic;
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
            ValidateCreate(newProductCategory);
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
            ValidateUpdate(updatedProductCategory);
            return _productCategoryRepository.Update(updatedProductCategory);
        }

        public ProductCategory Delete(int productCategoryId)
        {
            return _productCategoryRepository.Delete(productCategoryId);
        }

        private void ValidateCreate(ProductCategory productCategory)
        {
            ValidateNull(productCategory);
            if (productCategory.Id != default)
            {
                throw new ArgumentException("You are not allowed to specify an ID when creating a ProductCategory.");
            }
            ValidateName(productCategory);
        }

        private void ValidateUpdate(ProductCategory productCategory)
        {
            ValidateNull(productCategory);
            ValidateName(productCategory);
            if (_productCategoryRepository.Read(productCategory.Id) == null)
            {
                throw new ArgumentException($"Cannot find a ProductCategory with an ID: {productCategory.Id}");
            }
        }

        private void ValidateNull(ProductCategory productCategory)
        {
            if (productCategory == null)
            {
                throw new ArgumentNullException("ProductCategory cannot be null");
            }
        }

        private void ValidateName(ProductCategory productCategory)
        {
            if (string.IsNullOrEmpty(productCategory.Name))
            {
                throw new ArgumentException("You need to specify a Name for the ProductCategory.");
            }
        }
    }
}
