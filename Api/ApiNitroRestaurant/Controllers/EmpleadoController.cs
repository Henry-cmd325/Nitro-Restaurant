using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiNitroRestaurant.Models;

namespace ApiNitroRestaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly NitroRestaurantContext _context;
        public EmpleadoController(NitroRestaurantContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
                var lst = _context.Empleados.ToList();

                return Ok(lst);
        }
        
        [HttpGet("{id}", Name = "GetEmpleadoById")]
        public IActionResult GetEmpleadoById(int id)
        {
                var empleado = _context.Empleados.Find(id);

                return Ok(empleado);
        }
    }
}
