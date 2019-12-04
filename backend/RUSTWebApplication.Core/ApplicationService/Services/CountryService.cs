using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
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
            ValidateCreate(newCountry);
            return _countryRepository.Create(newCountry);
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
            ValidateUpdate(updatedCountry);
            return _countryRepository.Update(updatedCountry);
        }

        public Country Delete(int countryId)
        {
            return _countryRepository.Delete(countryId);
        }
        
        private void ValidateCreate(Country country)
        {
            ValidateNull(country);
            if (country.Id != default)
            {
                throw new ArgumentException("You are not allowed to specify an ID when creating a Country.");
            }
            ValidateName(country);
        }

        private void ValidateUpdate(Country country)
        {
            ValidateNull(country);
            ValidateName(country);
            if (_countryRepository.Read(country.Id) == null)
            {
                throw new ArgumentException($"Cannot find a Country with an ID: {country.Id}");
            }
        }
        
        
        private void ValidateNull(Country country)
        {
            if (country == null)
            {
                throw new ArgumentNullException("Country is null");
            }
        }

        private void ValidateName(Country country)
        {
            if (string.IsNullOrEmpty(country.Name))
            {
                throw new ArgumentException("You need to specify a name for the Country.");
            }
            if (!char.IsUpper(country.Name[0]))
            {
                throw new ArgumentException("Country name must start with an uppercase letter.");
            }
        }
    }
}
