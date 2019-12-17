using System;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Filters;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.ApplicationService.Services
{
	public class ProductModelService : IProductModelService
	{
		private readonly IProductModelRepository _productModelRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductMetricRepository _productMetricRepository;


        public ProductModelService(IProductModelRepository productModelRepository,
            IProductCategoryRepository productCategoryRepository,
            IProductMetricRepository productMetricRepository)
		{
			_productModelRepository = productModelRepository;
            _productCategoryRepository = productCategoryRepository;
            _productMetricRepository = productMetricRepository;
		}

		public ProductModel Create(ProductModel newProductModel)
        {
            ValidateCreate(newProductModel);
            return _productModelRepository.Create(newProductModel);
        }

		public ProductModel Read(int productModelId)
        {
            return _productModelRepository.Read(productModelId);
        }

		public FilteredList<ProductModel> ReadAll(ProductModelFilter filter)
        {
            return _productModelRepository.ReadAll(filter);
        }

		public ProductModel Update(ProductModel updatedProductModel)
        {
            ValidateUpdate(updatedProductModel);
            return _productModelRepository.Update(updatedProductModel);
        }

        public ProductModel Delete(int productModelId)
        {
            return _productModelRepository.Delete(productModelId);
        }

        private void ValidateCreate(ProductModel productModel)
        {
            ValidateNull(productModel);
            if (productModel.Id != default)
            {
                throw new ArgumentException("You are not allowed to specify the ID when creating a Product Model.");
            }
            ValidateName(productModel);
            ValidatePrice(productModel);
            ValidateProducts(productModel);
	        ValidateProductCategory(productModel);
            ValidateProductMetric(productModel);
        }

        private void ValidateUpdate(ProductModel productModel)
        {
            ValidateNull(productModel);
            ValidateName(productModel);
	        ValidatePrice(productModel);
	        ValidateProducts(productModel);
            ValidateProductCategory(productModel);
            ValidateProductMetric(productModel);
	        if (_productModelRepository.Read(productModel.Id) == null)
            {
                throw new ArgumentException($"Cannot find a ProductModel with the ID: {productModel.Id}");
            }
        }

        private void ValidateNull(ProductModel productModel) 
		{ 
            if (productModel == null)
            {
                throw new ArgumentNullException("ProductModel cannot be null");
            }
        }

        private void ValidateName(ProductModel productModel)
        {
            if (string.IsNullOrEmpty(productModel.Name))
            {
                throw new ArgumentException("You need to specify a Name for the ProductModel.");
            }
        }

        private void ValidateProductCategory(ProductModel productModel)
        {
            if (productModel.ProductCategory == null)
            {
                throw new ArgumentException("You need to specify a ProductCategory for the ProductModel");
            }

            if (_productCategoryRepository.Read(productModel.ProductCategory.Id) == null)
            {
                throw new ArgumentException($"ProductCategory with the ID: {productModel.ProductCategory.Id} doesn't exist.");
            }
        }

        private void ValidateProductMetric(ProductModel productModel)
        {
            if (productModel.ProductMetric == null)
            {
                throw new ArgumentException("You need to specify a ProductMetric for the ProductModel");
            }

            if (_productMetricRepository.Read(productModel.ProductMetric.Id) == null)
            {
                throw new ArgumentException($"ProductMetric with the ID: {productModel.ProductMetric.Id} doesn't exist.");
            }
        }

        private void ValidatePrice(ProductModel productModel)
        {
            if (productModel.Price < 0)
            {
                throw new ArgumentException("Price cannot be less then 0");
            }
        }

        private void ValidateProducts(ProductModel productModel)
        {
            if (productModel.Products != null)
            {
                throw new ArgumentException("You are not allowed to specify a Products for the ProductModel.");
            }
        }
    }
}
