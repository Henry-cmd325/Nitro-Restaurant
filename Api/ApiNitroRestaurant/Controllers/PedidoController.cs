using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiNitroRestaurant.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public PedidoController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllPedidos()
        {
            var user = HttpContext.User.Identity as ClaimsIdentity;
            var claim = user!.Claims.Where(c => c.Type == ClaimTypes.Name).First();

            var response = _orderService.GetAllOrders(claim.Value);

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("/admin")]
        public IActionResult GetAllPedidosFromAllSubsidiary()
        {
            var response = _orderService.GetAllOrders();

            return Ok(response);
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetPedido")]
        public IActionResult GetPedido(int id)
        {
            var response = _orderService.GetOrder(id);
            
            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public IActionResult PostPedido(OrderRequest model)
        {
            var response = _orderService.PostOrder(model);

            if (!response.Success) return BadRequest(response);

            return CreatedAtRoute(nameof(GetPedido), new { id = response.Data.IdPedido }, response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeletePedido(int id)
        {
            var response = _orderService.DeleteOrder(id);

            if(!response.Success) return BadRequest(response);

            return NoContent();
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult PutPedido(int id, OrderRequest model)
        {
            var response = _orderService.UpdateOrder(id, model);

            if (!response.Success) return BadRequest(response);

            return NoContent();
        }

        [Authorize]
        [HttpPut("state/{id}")]
        public IActionResult PutStatePedido(int id, OrderStateRequest model)
        {
            var response = _orderService.UpdateState(id, model);

            if (!response.Success) return BadRequest(response);

            return NoContent();
        }

    }
}
