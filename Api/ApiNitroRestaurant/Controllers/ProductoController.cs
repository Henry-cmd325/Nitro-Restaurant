using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiNitroRestaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductService _productoService;

        public ProductoController(IProductService productService)
        {
            _productoService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _productoService.GetAll();

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public IActionResult GetProductById(int id)
        {
            var response = _productoService.GetProduct(id);

            if (!response.Success) return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CrearEmpleado([FromBody] ProductRequest model)
        {
            var response = _productoService.CreateProduct(model);

            if(!response.Success) return BadRequest(response);

            return CreatedAtRoute(nameof(GetProductById), new { id = response.Data.IdProducto }, response);
        }

        [HttpPut("{id}")]
        public IActionResult EditarProducto(int id, [FromBody] ProductRequest model)
        {
            var response = _productoService.UpdateProduct(id, model);

            if (!response.Success) return NotFound(response);

            return NoContent();
        } 
    }
}
