using System;
using System.Collections.Generic;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.DomainService
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
