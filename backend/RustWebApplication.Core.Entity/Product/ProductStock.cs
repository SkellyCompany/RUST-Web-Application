using System;
namespace RustWebApplication.Core.Entity
{
    public class ProductStock
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public ProductSize ProductSize { get; set; }
    }
}
