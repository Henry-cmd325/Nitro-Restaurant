using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}", Name = "GetPedido")]
        public IActionResult GetPedido(int id)
        {
            var response = _orderService.GetOrder(id);
            
            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult PostPedido([FromBody] OrderRequest model)
        {
            var response = _orderService.PostOrder(model);

            if (!response.Success) return BadRequest(response);

            return CreatedAtRoute(nameof(GetPedido), new { id = response.Data.IdPedido }, response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePedido(int id)
        {
            var response = _orderService.DeleteOrder(id);

            if(!response.Success) return BadRequest(response);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutPedido(int id, [FromBody] OrderRequest model)
        {
            var response = _orderService.UpdateOrder(id, model);

            if (!response.Success) return BadRequest(response);

            return NoContent();
        }
    }
}
