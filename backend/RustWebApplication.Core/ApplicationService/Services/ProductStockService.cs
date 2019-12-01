using System;
using System.Collections.Generic;
using RustWebApplication.Core.DomainService;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.ApplicationService.Services
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
            throw new NotImplementedException();
        }

        public ProductStock Delete(int productStockId)
        {
            throw new NotImplementedException();
        }

        public ProductStock Read(int productStockId)
        {
            throw new NotImplementedException();
        }

        public List<ProductStock> ReadAll()
        {
            throw new NotImplementedException();
        }

        public ProductStock Update(ProductStock updatedProductStock)
        {
            throw new NotImplementedException();
        }
    }
}
