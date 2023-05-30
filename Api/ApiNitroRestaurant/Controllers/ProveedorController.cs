using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiNitroRestaurant.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _service;

        public ProveedorController(IProveedorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetProveedores()
        {
            return Ok(_service.GetAllProveedores());
        }

        [HttpGet("{id}")]
        public IActionResult GetIdProveedor(int id)
        {
            var response = _service.GetProveedor(id);

            if (!response.Success) return NotFound();

            return Ok(response);
        }

        [HttpPost]
        public IActionResult PostProveedor(ProveedorRequest request)
        {
            var response = _service.PostProveedor(request);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult PutProveedor(int id, ProveedorRequest request)
        {
            var response = _service.PutProveedor(id, request);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }
    }
}
