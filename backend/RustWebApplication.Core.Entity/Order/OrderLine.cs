using System;
namespace RustWebApplication.Core.Entity
{
    public class OrderLine
    {
        public Order Order { get; set; }
        public ProductStock ProductStock { get; set; }
        public int Quantity { get; set; }
    }
}
