using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiNitroRestaurant.Models;

namespace ApiNitroRestaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (NitroRestaurantContext db = new())
            {
                var lst = db.Empleados.ToList();

                return Ok(lst);
            }
        }

        [HttpGet("{id}", Name = "GetEmpleadoById")]
        public IActionResult GetEmpleadoById(int id)
        {
            using(NitroRestaurantContext db = new())
            {
                var empleado = db.Empleados.Find(id);

                return Ok(empleado);
            }
        }
    }
}
