﻿using System;
using System.Collections.Generic;
using System.Linq;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Core.ApplicationService.Services
{
	public class ProductModelService : IProductModelService
	{
		private readonly IProductModelRepository _productModelRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;


        public ProductModelService(IProductModelRepository productModelRepository,
            IProductCategoryRepository productCategoryRepository)
		{
			_productModelRepository = productModelRepository;
            _productCategoryRepository = productCategoryRepository;
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

		public List<ProductModel> ReadAll()
        {
            return _productModelRepository.ReadAll().ToList();
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
        }

        private void ValidateUpdate(ProductModel productModel)
        {
            ValidateNull(productModel);
            ValidateName(productModel);
	        ValidatePrice(productModel);
	        ValidateProducts(productModel);
            ValidateProductCategory(productModel);     
	        if (_productModelRepository.Read(productModel.Id) == null)
            {
                throw new ArgumentException($"Cannot find a Product Model with the ID: {productModel.Id}");
            }
        }


        private void ValidateNull(ProductModel productModel) 
	{ 
            if (productModel == null)
            {
                throw new ArgumentNullException("Product Model cannot be null");
            }
        }

        private void ValidateName(ProductModel productModel)
        {
            if (string.IsNullOrEmpty(productModel.Name))
            {
                throw new ArgumentException("You need to specify a Name for the Product Model.");
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
                throw new ArgumentException($"Product Category with the ID: {productModel.ProductCategory.Id} doesn't exist.");
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