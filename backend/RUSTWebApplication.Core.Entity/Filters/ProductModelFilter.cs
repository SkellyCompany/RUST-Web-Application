namespace RUSTWebApplication.Core.Entity.Filters
{
	public enum CategoryType { Default, Top, Bottom };

	public class ProductModelFilter
	{
		public int CurrentPage { get; set; }
		public int ItemsPerPage { get; set; }
		public CategoryType CategoryType { get; set; }
	}
}
