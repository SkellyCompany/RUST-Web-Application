using System;
using System.Collections.Generic;
using RustWebApplication.Core.DomainService;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.ApplicationService.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;


        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public Country Create(Country newCountry)
        {
            throw new NotImplementedException();
        }

        public Country Delete(int countryId)
        {
            throw new NotImplementedException();
        }

        public Country Read(int countryId)
        {
            throw new NotImplementedException();
        }

        public List<Country> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Country Update(Country updatedCountry)
        {
            throw new NotImplementedException();
        }
    }
}
