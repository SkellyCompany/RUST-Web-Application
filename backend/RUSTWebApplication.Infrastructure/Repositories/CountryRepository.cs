using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Order;

namespace RUSTWebApplication.Infrastructure.Repositories
{
    public class CountryRepository: ICountryRepository
    {

        private readonly RUSTWebApplicationContext _ctx;

        public CountryRepository(RUSTWebApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public Country Create(Country newCountry)
        {
            _ctx.Countries.Attach(newCountry).State = EntityState.Added;
            _ctx.SaveChanges();
            return newCountry;
        }

        public Country Read(int countryId)
        {
            return _ctx.Countries.AsNoTracking().FirstOrDefault(c => c.Id == countryId);
        }

        public IEnumerable<Country> ReadAll()
        {
            return _ctx.Countries.AsNoTracking();
        }

        public Country Update(Country updatedCountry)
        {
            _ctx.Countries.Attach(updatedCountry).State = EntityState.Modified;
            _ctx.SaveChanges();
            return updatedCountry;
        }

        public Country Delete(int countryId)
        {
            var countryToDelete = _ctx.Countries.FirstOrDefault(c => c.Id == countryId);
            _ctx.Countries.Remove(countryToDelete);
            _ctx.SaveChanges();
            return countryToDelete;
        }
    }
}