using System;
using System.Collections.Generic;
using System.Linq;
using RUSTWebApplication.Core.Entity.Order;
using RUSTWebApplication.Core.DomainService;

namespace RUSTWebApplication.Core.ApplicationService.Services
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
            return _countryRepository.Create(newCountry);
        }

        public Country Delete(int countryId)
        {
            return _countryRepository.Delete(countryId);
        }

        public Country Read(int countryId)
        {
            return _countryRepository.Read(countryId);
        }

        public List<Country> ReadAll()
        {
            return _countryRepository.ReadAll().ToList();
        }

        public Country Update(Country updatedCountry)
        {
            return _countryRepository.Update(updatedCountry);
        }

    }
}