using System.Collections.Generic;
using RUSTWebApplication.Core.Entity.Order;

namespace RUSTWebApplication.Core.ApplicationService
{
	public interface ICountryService
	{
		Country Create(Country newCountry);

		Country Read(int countryId);

		List<Country> ReadAll();

		Country Update(Country updatedCountry);

		Country Delete(int countryId);
	}
}
