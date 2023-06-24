using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiNitroRestaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimaController : ControllerBase
    {
        private readonly IPrimaService _service;
        public PrimaController(IPrimaService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetPrima")]
        public IActionResult GetPrima(int id)
        {
            var response = _service.GetPrima(id);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetPrimasS()
        {
            var user = HttpContext.User.Identity as ClaimsIdentity;
            var claim = user!.Claims.Where(c => c.Type == ClaimTypes.Name).First();

            var response = _service.GetPrimas(claim.Value);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [Route("All")]
        [HttpGet]
        public IActionResult GetPrimas()
        {
            return Ok(_service.GetPrimas());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreatePrima(PrimaRequest request)
        {
            var response = _service.CreatePrima(request);

            if (!response.Success) return BadRequest(response);

            return CreatedAtRoute(nameof(GetPrima), new { id = response.Data.IdPrima }, response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeletePrima(int id)
        {
            var response = _service.DeletePrima(id);

            if (!response.Success) return BadRequest(response);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult PutPrima(int id, PrimaRequest request)
        {
            var response = _service.PutPrima(id, request);

            if (!response.Success) return BadRequest(response);

            return NoContent();
        }
    }
}
