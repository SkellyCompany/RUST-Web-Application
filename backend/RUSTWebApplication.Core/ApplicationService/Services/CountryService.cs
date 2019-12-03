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
            ValidateCreateCountry(newCountry);
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
            ValidateUpdateCountry(updatedCountry);
            return _countryRepository.Update(updatedCountry);
        }

        public Country Delete(int countryId)
        {
            return _countryRepository.Delete(countryId);
        }

        /*   private void ValidateCountryId(int countryId)
           {
                if (countryId < 1)
                {
                    throw new InvalidDataException("ID must be over zero.");
                } 

            } */

        private void ValidateCountryName(Country country)
        {
            if (string.IsNullOrEmpty(country.Name))
            {
                throw new InvalidDataException("You need to specify a name for the Country.");
            }

            if (char.IsUpper(country.Name[0]))
            {
                throw new InvalidDataContractException("The countries name must start with an uppercase letter.");
            }
        }

        private void ValidateCreateCountry(Country country)
        {
            if (country.Id != default)
            {
                throw new InvalidDataException("You are not allowed to specify an ID when creating a country.");
            }
            ValidateCountryName(country);
        }

        private void ValidateUpdateCountry(Country country)
        {
            if (_countryRepository.Read(country.Id) == null)
            {
                throw new InvalidDataException($"Cannot find a country with an ID: {country.Id}");
            }
            ValidateCountryName(country);
        }

    }
}