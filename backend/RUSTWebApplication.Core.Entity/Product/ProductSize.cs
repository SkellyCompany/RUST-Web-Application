namespace RUSTWebApplication.Core.Entity.Product
{
	public class ProductSize
	{
		public int Id { get; set; }
		public ProductMetric ProductMetric { get; set; }
		public string Size { get; set; }
		public double MetricXValue { get; set; }
		public double MetricYValue { get; set; }
		public double MetricZValue { get; set; }
	}
}
