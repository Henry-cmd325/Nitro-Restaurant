using Microsoft.AspNetCore.Mvc;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Services;
using Microsoft.AspNetCore.Authorization;

namespace ApiNitroRestaurant.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IConfiguration _config;   
        public EmpleadoController(IEmployeeService employeeService, IConfiguration config)
        {
            _employeeService = employeeService;
            _config = config;
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

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult EmpleadoLogin(EmpleadoAuthRequest model)
        {
            var response = _employeeService.Auth(model);

            if (!response.Success) return BadRequest(response);

            response.Data.Token = _employeeService.GenerateToken(response.Data, _config);

            return Ok(response);
        }

        [HttpPost("signup")]
        public IActionResult EmpleadoSignUp(EmpleadoRequest model)
        {
            var response = _employeeService.SignUp(model);

            if (!response.Success) return BadRequest(response);

            return CreatedAtRoute(nameof(GetEmpleadoById), new { id = response.Data.IdEmpleado }, response);
        }

        [HttpPut("disable/{id}")]
        public IActionResult DisableEmpleado(int id)
        {
            var response = _employeeService.Disable(id);

            if (!response.Success) return BadRequest(response);

            return NoContent();
        }
    }
}
