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
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(_productService.ReadAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            try
            {
                return Ok(_productService.Read(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


		// POST api/products
		[Authorize(Roles = "Administrator")]
		[HttpPost]
        public ActionResult<Product> Post([FromBody] Product value)
        {
            try
            {
                return Ok(_productService.Create(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

		// PUT api/products/5
		[Authorize(Roles = "Administrator")]
		[HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] Product value)
        {
            try
            {
                if (id != value.Id)
                {
                    return Conflict("Parameter ID does not match Product id");
                }
                return Ok(_productService.Update(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

		// DELETE api/products/5
		[Authorize(Roles = "Administrator")]
		[HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            Product deletedProduct = _productService.Delete(id);
            if (deletedProduct == null)
            {
                return NotFound($"Did not find Product with ID: {id}");
            }
            return Ok(deletedProduct);
        }


    }
}
