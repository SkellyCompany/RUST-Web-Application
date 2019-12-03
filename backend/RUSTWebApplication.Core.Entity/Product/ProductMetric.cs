namespace RUSTWebApplication.Core.Entity.Product
{
    public class ProductMetric
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductModel ProductModel { get; set; }
        public string MetricX { get; set; }
        public string MetricY { get; set; }
        public string MetricZ { get; set; }
    }
}