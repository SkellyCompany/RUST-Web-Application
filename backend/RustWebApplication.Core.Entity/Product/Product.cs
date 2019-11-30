using System;
using System.Collections.Generic;

namespace RustWebApplication.Core.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public ProductModel ProductModel { get; set; }
        public List<ProductStock> ProductStocks { get; set; }
        public string Color { get; set; }
    }
}
