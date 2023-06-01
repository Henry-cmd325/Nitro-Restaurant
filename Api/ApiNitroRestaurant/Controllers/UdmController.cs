using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiNitroRestaurant.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UdmController : ControllerBase
    {
        private readonly IUdmService _service;

        public UdmController(IUdmService service)
        {
            _service = service;
        }

        [HttpGet("{id}", Name = "GetUdm")]
        public IActionResult GetUdm(int id)
        {
            var response = _service.GetUdm(id);

            if (!response.Success) return NotFound();

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetUdms()
        {
            return Ok(_service.GetUdms());
        }

        [HttpPost]
        public IActionResult PostUdm(UdmRequest request)
        {
            var response = _service.PostUdm(request);

            if (!response.Success) return BadRequest(response);

            return CreatedAtRoute(nameof(GetUdm), new { id = response.Data.IdUdm }, response);
        }

        [HttpPut("{id}")]
        public IActionResult PutUdm(int id, UdmRequest request)
        {
            var response = _service.PutUdm(id, request);

            if (!response.Success) return BadRequest(response);

            return NoContent();
        }
    }
}
