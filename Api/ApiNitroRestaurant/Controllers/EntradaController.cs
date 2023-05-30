using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiNitroRestaurant.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaController : ControllerBase
    {
        private readonly IEntranceService _service;
        public EntradaController(IEntranceService service)
        {
            _service = service;
        }

        [HttpGet("{id}", Name = "GetEntrance")]
        public IActionResult GetEntrance(int id)
        {
            var response = _service.GetEntrance(id);

            if (!response.Success) return NotFound(response);

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetEntrances()
        {
            var user = HttpContext.User.Identity as ClaimsIdentity;
            var claim = user!.Claims.Where(c => c.Type == ClaimTypes.Name).First();

            var response = _service.GetEntrances(claim.Value);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult PostEntrance(EntradaRequest request)
        {
            var response = _service.PostEntrance(request);

            if (!response.Success) BadRequest(response);

            return CreatedAtRoute(nameof(GetEntrance), new { id = response.Data.IdEntrada }, response);
        }


        [HttpPut("{id}")]
        public IActionResult PutEntrance(int id, EntradaRequest request)
        {
            var response = _service.PutEntrance(id, request);

            if (!response.Success) BadRequest(response);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEntrance(int id)
        {
            var response = _service.DeleteEntrance(id);

            if (!response.Success) NotFound(response);

            return NoContent();
        }
    }
}
