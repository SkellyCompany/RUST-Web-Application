using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RUSTWebApplication.Core.ApplicationService;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductModelsController : ControllerBase
    {

        private readonly IProductModelService _productModelService;

        public ProductModelsController(IProductModelService productModelService)
        {
            _productModelService = productModelService;
        }

        // GET api/productmodels
        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> Get()
        {
            try
            {
                return Ok(_productModelService.ReadAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET api/productmodels/5
        [HttpGet("{id}")]
        public ActionResult<ProductModel> Get(int id)
        {
            try
            {
                return Ok(_productModelService.Read(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // POST api/productmodels
        [HttpPost]
        public ActionResult<ProductModel> Post([FromBody] ProductModel value)
        {
            try
            {
                return Ok(_productModelService.Create(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        // PUT api/productmodels/5
        [HttpPut("{id}")]
        public ActionResult<ProductModel> Put(int id, [FromBody] ProductModel value)
        {
            try
            {
                if (id != value.Id)
                {
                    return BadRequest("Parameter ID does not match ProductModel id");
                }
                return Ok(_productModelService.Update(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/productmodels/5
        [HttpDelete("{id}")]
        public ActionResult<ProductModel> Delete(int id)
        {
            ProductModel deletedProductModel = _productModelService.Delete(id);
            if (deletedProductModel == null)
            {
                return StatusCode(404, $"Did not find ProductModel with ID: {id}");
            }
            return Ok(deletedProductModel);
        }


    }
}
