using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.DTO;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // default 

        // custmizatioon

        [HttpGet("{id}")]
        public void getProduct([FromRoute] int id)
        {

        }


        [HttpPost("create")]
        public void createProduct([FromForm] CreateProductDTO dTO)
        {
            // value // 
            // Product p = new Product();

            // return context.users.select(a=> new { responseDTO l})
        }

        [HttpPut("update")]
        public void update([FromQuery] int id, [FromBody] UpdateProductDTO dto)
        {
            // logic
            // response
        }
    }
}
