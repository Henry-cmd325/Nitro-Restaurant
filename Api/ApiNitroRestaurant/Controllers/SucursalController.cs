using ApiNitroRestaurant.Context;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;
using ApiNitroRestaurant.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiNitroRestaurant.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly ISucursalService _context;
        public SucursalController(ISucursalService context)
        {
            _context = context;
        }

        [HttpGet("{id}", Name = "GetSucursal")]
        public IActionResult GetSucursal(int id)
        {
            var response = _context.GetSucursal(id);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAllSucursal()
        {
            var response = _context.GetAllSucursal();

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult PostSucursal(SucursalRequest request)
        {
            var response = _context.PostSucursal(request);

            if (!response.Success) return BadRequest(response);

            return CreatedAtRoute(nameof(GetSucursal), new { id = response.Data.IdSucursal }, response);
        }

        [HttpPut("{id}")]
        public IActionResult EditSucursal(int id, SucursalRequest request)
        {
            var response = _context.PutSucursal(id, request);

            if (!response.Success) return BadRequest(response);

            return NoContent();
        }
    }
}
