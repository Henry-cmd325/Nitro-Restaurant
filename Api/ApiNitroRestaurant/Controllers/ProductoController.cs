using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var user = HttpContext.User.Identity as ClaimsIdentity;
            var claim = user!.Claims.Where(c => c.Type == ClaimTypes.Name).First();

            var response = _productoService.GetAll(claim.Value);

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllFromAllSubsidiaries()
        {
            var response = _productoService.GetAll();

            return Ok(response);
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetProductById")]
        public IActionResult GetProductById(int id)
        {
            var response = _productoService.GetProduct(id);

            if (!response.Success) return NotFound(response);

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CrearProducto(ProductRequest model)
        {
            var response = _productoService.CreateProduct(model);

            if(!response.Success) return BadRequest(response);

            return CreatedAtRoute(nameof(GetProductById), new { id = response.Data.IdProducto }, response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult EditarProducto(int id, ProductRequest model)
        {
            var response = _productoService.UpdateProduct(id, model);

            if (!response.Success) return NotFound(response);

            return NoContent();
        } 
    }
}
