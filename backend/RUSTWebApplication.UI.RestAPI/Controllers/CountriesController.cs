using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RUSTWebApplication.Core.ApplicationService;
using RUSTWebApplication.Core.Entity.Order;

namespace RUSTWebApplication.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {

        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        // GET api/countries
        [HttpGet]
        public ActionResult<IEnumerable<Country>> Get()
        {
            try
            {
                return Ok(_countryService.ReadAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET api/countries/5
        [HttpGet("{id}")]
        public ActionResult<Country> Get(int id)
        {
            try
            {
                return Ok(_countryService.Read(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


		// POST api/countries
		[Authorize(Roles = "Administrator")]
		[HttpPost]
        public ActionResult<Country> Post([FromBody] Country value)
        {
            try
            {
                return Ok(_countryService.Create(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

		// PUT api/countries/5
		[Authorize(Roles = "Administrator")]
		[HttpPut("{id}")]
        public ActionResult<Country> Put(int id, [FromBody] Country value)
        {
            try
            {
                if (id != value.Id)
                {
                    return Conflict("Parameter ID does not match Country id");
                }
                return Ok(_countryService.Update(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

		// DELETE api/countries/5
		[Authorize(Roles = "Administrator")]
		[HttpDelete("{id}")]
        public ActionResult<Country> Delete(int id)
        {
            Country deletedCountry = _countryService.Delete(id);
            if (deletedCountry == null)
            {
                return NotFound($"Did not find Country with ID: {id}");
            }
            return Ok(deletedCountry);
        }


    }
}
