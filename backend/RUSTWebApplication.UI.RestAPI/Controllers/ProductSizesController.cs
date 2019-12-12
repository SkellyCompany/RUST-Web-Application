using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RUSTWebApplication.Core.ApplicationService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSizesController : ControllerBase
    {

        private readonly IProductSizeService _productSizeService;

        public ProductSizesController(IProductSizeService productSizeService)
        {
            _productSizeService = productSizeService;
        }

        // GET api/productsizes
        [HttpGet]
        public ActionResult<IEnumerable<ProductSize>> Get()
        {
            try
            {
                return Ok(_productSizeService.ReadAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET api/productsizes/5
        [HttpGet("{id}")]
        public ActionResult<ProductSize> Get(int id)
        {
            try
            {
                return Ok(_productSizeService.Read(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


		// POST api/productsizes
		[Authorize(Roles = "Administrator")]
		[HttpPost]
        public ActionResult<ProductSize> Post([FromBody] ProductSize value)
        {
            try
            {
                return Ok(_productSizeService.Create(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

		// PUT api/productsizes/5
		[Authorize(Roles = "Administrator")]
		[HttpPut("{id}")]
        public ActionResult<ProductSize> Put(int id, [FromBody] ProductSize value)
        {
            try
            {
                if (id != value.Id)
                {
                    return BadRequest("Parameter ID does not match ProductSize id");
                }
                return Ok(_productSizeService.Update(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

		// DELETE api/productsizes/5
		[Authorize(Roles = "Administrator")]
		[HttpDelete("{id}")]
        public ActionResult<ProductSize> Delete(int id)
        {
            ProductSize deletedProductSize = _productSizeService.Delete(id);
            if (deletedProductSize == null)
            {
                return StatusCode(404, $"Did not find ProductSize with ID: {id}");
            }
            return Ok(deletedProductSize);
        }


    }
}
