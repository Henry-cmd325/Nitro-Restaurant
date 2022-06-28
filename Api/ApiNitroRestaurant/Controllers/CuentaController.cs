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
        private readonly IAccountService _accountService;

        public CuentaController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{id}", Name = "GetCuentaById")]
        public IActionResult GetCuentaById(int id)
        {
            var accountDb = _accountService.GetAccount(id);

            return Ok(accountDb);
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AccountRequest model)
        {
            var response = _accountService.Auth(model);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("signin")]
        public IActionResult Registrarse([FromBody] SignInRequest model)
        {
            var response = _accountService.SignIn(model);
            
            if (!response.Success) return BadRequest(response);

            return CreatedAtRoute(nameof(GetCuentaById), new { id = response.Data.IdCuenta }, response);
        }
    }
}
