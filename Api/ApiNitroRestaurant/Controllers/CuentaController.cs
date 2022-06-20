using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;
using ApiNitroRestaurant.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNitroRestaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private IAccountService _accountService;

        public CuentaController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{id}", Name = "GetCuentaById")]
        public IActionResult GetCuentaById(int id)
        {
            var accountDb = _accountService.GetAccount(id);

            if (accountDb == null) return NotFound();

            AccountResponse response = new()
            {
                Username = accountDb.Username
            };

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AccountRequest model)
        {
            var response = _accountService.Auth(model);

            if (response == null) return BadRequest(new AccountResponse { Username = "El usuario o la contraseña son incorrectos" });

            return Ok(response);
        }

        [HttpPost("signin")]
        public IActionResult Registrarse([FromBody] SignInRequest model)
        {
            var employeeDb = _accountService.SignIn(model);
            
            if (employeeDb == null) return BadRequest("El usuario y la contraseña ya existen o te has equivocado en el nombre del tipo de empleado");

            return CreatedAtRoute(nameof(GetCuentaById), new { id = employeeDb.IdCuenta }, employeeDb);
        }
    }
}
