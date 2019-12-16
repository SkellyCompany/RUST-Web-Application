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
    public class ProductMetricsController : ControllerBase
    {

        private readonly IProductMetricService _productMetricService;

        public ProductMetricsController(IProductMetricService productMetricService)
        {
            _productMetricService = productMetricService;
        }

        // GET api/productmetrics
        [HttpGet]
        public ActionResult<IEnumerable<ProductMetric>> Get()
        {
            try
            {
                return Ok(_productMetricService.ReadAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET api/productmetrics/5
        [HttpGet("{id}")]
        public ActionResult<ProductMetric> Get(int id)
        {
            try
            {
                return Ok(_productMetricService.Read(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


		// POST api/productmetrics
		[Authorize(Roles = "Administrator")]
		[HttpPost]
        public ActionResult<ProductMetric> Post([FromBody] ProductMetric value)
        {
            try
            {
                return Ok(_productMetricService.Create(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

		// PUT api/productmetrics/5
		[Authorize(Roles = "Administrator")]
		[HttpPut("{id}")]
        public ActionResult<ProductMetric> Put(int id, [FromBody] ProductMetric value)
        {
            try
            {
                if (id != value.Id)
                {
                    return Conflict("Parameter ID does not match ProductMetric id");
                }
                return Ok(_productMetricService.Update(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

		// DELETE api/productmetrics/5
		[Authorize(Roles = "Administrator")]
		[HttpDelete("{id}")]
        public ActionResult<ProductMetric> Delete(int id)
        {
            ProductMetric deletedProductMetric = _productMetricService.Delete(id);
            if (deletedProductMetric == null)
            {
                return NotFound($"Did not find ProductMetric with ID: {id}");
            }
            return Ok(deletedProductMetric);
        }


    }
}
