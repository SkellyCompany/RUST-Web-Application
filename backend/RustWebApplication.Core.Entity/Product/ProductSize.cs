using System;
namespace RustWebApplication.Core.Entity
{
    public class ProductSize
    {
        public int Id { get; set; }
        public ProductType ProductType { get; set; }
        public string Size { get; set; }
    }
}
