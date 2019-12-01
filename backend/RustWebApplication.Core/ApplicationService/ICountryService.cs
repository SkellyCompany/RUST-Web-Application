using System;
using System.Collections.Generic;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.ApplicationService
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
