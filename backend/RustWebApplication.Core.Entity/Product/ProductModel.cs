using System;
using System.Collections.Generic;

namespace RustWebApplication.Core.Entity
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductType ProductType { get; set; }
        public double Price { get; set; }
        public List<Product> Products { get; set; }
    }
}
