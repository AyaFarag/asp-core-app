using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.DTO;
using WebApplicationAPI.Service.Product;
using WebApplicationAPI.Validation;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        // Dependancy Injection
        public IProductService ProductService;
        public ProductController(IProductService _ProductService)
        {
            ProductService = _ProductService;   
        }

        [HttpGet]
        public IActionResult get()
        {
            var products = ProductService.getAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public void getProduct([FromRoute] int id)
        {
            ProductService.getAllProducts();
            // response
        }


        [HttpPost("create")]
        public IActionResult createProduct([FromBody] CreateProductCategoryDTO dTO)
        {
            var vaidator = new ProductValidator();
            var result = vaidator.Validate(dTO);
            if (!result.IsValid) 
            { 
                foreach (var errors in result.Errors) 
                {
                    return BadRequest(errors);    
                }
            
            }

            var product = ProductService.createProduct(dTO);
            return Ok(product);
        }

        [HttpPut("update")]
        public IActionResult update([FromQuery] int id, [FromBody] UpdateProductDTO dto)
        {
            var product = ProductService.updateProduct(id, dto);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            var result = ProductService.deleteProduct(id);
            return Ok(result);
        }
    }
}
