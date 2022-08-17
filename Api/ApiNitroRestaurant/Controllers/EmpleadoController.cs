using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiNitroRestaurant.Models;
using ApiNitroRestaurant.Models.Response;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Services;

namespace ApiNitroRestaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmpleadoController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        [HttpGet]
        public IActionResult GetEmpleados()
        {
            var response = _employeeService.GetAll();

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetEmpleadoById")]
        public IActionResult GetEmpleadoById(int id)
        {
            var response = _employeeService.Get(id);

            if (!response.Success) return NotFound(response);

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult EmpleadoLogin([FromBody] EmpleadoAuthRequest model)
        {
            var response = _employeeService.Auth(model);

            if(!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("signin")]
        public IActionResult EmpleadoSignIn([FromBody] EmpleadoRequest model)
        {
            var response = _employeeService.SignIn(model);

            if (!response.Success) return BadRequest(response);

            return CreatedAtRoute(nameof(GetEmpleadoById), new { id = response.Data.IdEmpleado }, response);
        }
    }
}
