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
    public class ProductCategoriesController : ControllerBase
    {

        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoriesController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        // GET api/productcategories
        [HttpGet]
        public ActionResult<IEnumerable<ProductCategory>> Get()
        {
            try
            {
                return Ok(_productCategoryService.ReadAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/productcategories/5
        [HttpGet("{id}")]
        public ActionResult<ProductCategory> Get(int id)
        {
            try
            {
                return Ok(_productCategoryService.Read(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


		// POST api/productcategories
		[Authorize(Roles = "Administrator")]
		[HttpPost]
        public ActionResult<ProductCategory> Post([FromBody] ProductCategory value)
        {
            try
            {
                return Ok(_productCategoryService.Create(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

		// PUT api/productcategories/5
		[Authorize(Roles = "Administrator")]
		[HttpPut("{id}")]
        public ActionResult<ProductCategory> Put(int id, [FromBody] ProductCategory value)
        {
            try
            {
                if (id != value.Id)
                {
                    return Conflict("Parameter ID does not match ProductCategory id");
                }
                return Ok(_productCategoryService.Update(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

		// DELETE api/productcategories/5
		[Authorize(Roles = "Administrator")]
		[HttpDelete("{id}")]
        public ActionResult<ProductCategory> Delete(int id)
        {
            ProductCategory deletedCountry = _productCategoryService.Delete(id);
            if (deletedCountry == null)
            {
                return NotFound($"Did not find ProductCategory with ID: {id}");
            }
            return Ok(deletedCountry);
        }


    }
}
