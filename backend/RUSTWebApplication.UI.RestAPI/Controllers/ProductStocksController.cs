using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RUSTWebApplication.Core.Entity.Product;
using RUSTWebApplication.Core.ApplicationService;

namespace RUSTWebApplication.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStocksController : ControllerBase
    {
        private readonly IProductStockService _productStockService;


        public ProductStocksController(IProductStockService productStockService)
        {
            _productStockService = productStockService;
        }

        // GET api/productstocks
        [HttpGet]
        public ActionResult<IEnumerable<ProductStock>> Get()
        {
            try
            {
                return Ok(_productStockService.ReadAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET api/productstocks/5
        [HttpGet("{id}")]
        public ActionResult<ProductStock> Get(int id)
        {
            try
            {
                return Ok(_productStockService.Read(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


		// POST api/productstocks
		[Authorize(Roles = "Administrator")]
		[HttpPost]
        public ActionResult<ProductStock> Post([FromBody] ProductStock value)
        {
            try
            {
                return Ok(_productStockService.Create(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

		// PUT api/productstocks/5
		[Authorize(Roles = "Administrator")]
		[HttpPut("{id}")]
        public ActionResult<ProductStock> Put(int id, [FromBody] ProductStock value)
        {
            try
            {
                if (id != value.Id)
                {
                    return Conflict("Parameter ID does not match ProductStock id");
                }
                return Ok(_productStockService.Update(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

		// DELETE api/productstocks/5
		[Authorize(Roles = "Administrator")]
		[HttpDelete("{id}")]
        public ActionResult<ProductStock> Delete(int id)
        {
            ProductStock deletedProductStock = _productStockService.Delete(id);
            if (deletedProductStock == null)
            {
                return NotFound($"Did not find ProductStock with ID: {id}");
            }
            return Ok(deletedProductStock);
        }


    }
}
