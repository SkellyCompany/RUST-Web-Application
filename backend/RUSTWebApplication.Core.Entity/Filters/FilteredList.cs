using System.Collections.Generic;

namespace RUSTWebApplication.Core.Entity.Filters
{
	public class FilteredList<T>
	{
		public int CurrentPage { get; set; }
		public int ItemsPerPage { get; set; }
		public int TotalPages { get; set; }
		public IEnumerable<T> Data { get; set; }
	}
}
