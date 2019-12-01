using System;
using System.Collections.Generic;

namespace RUSTWebApplication.Core.Entity.Order
{
	public class Order
	{
		public int Id { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime DeliveryDate { get; set; }
		public List<OrderLine> OrderLines { get; set; }

		public string Address { get; set; }
		public string City { get; set; }
		public string ZipCode { get; set; }
		public Country Country { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
	}
}
