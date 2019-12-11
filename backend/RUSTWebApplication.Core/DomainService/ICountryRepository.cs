using System.Collections.Generic;
using RUSTWebApplication.Core.Entity.Order;

namespace RUSTWebApplication.Core.DomainService
{
	public interface ICountryRepository
	{
		Country Create(Country newCountry);

		Country Read(int countryId);

		IEnumerable<Country> ReadAll();

		Country Update(Country updatedCountry);

		Country Delete(int countryId);
	}
}
