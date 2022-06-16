using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiNitroRestaurant.Models;
using ApiNitroRestaurant.Models.Response;

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

            List<EmpleadoResponse> lstResponse = new();

            lst.ForEach(el =>
            {
                lstResponse.Add
                (
                    new EmpleadoResponse
                    {
                        IdCuenta = el.IdCuenta,
                        IdTipoEmpleado = el.IdTipoEmpleado,
                        Paterno = el.Paterno,
                        Materno = el.Materno,
                        Nombre = el.Nombre,
                        Telefono = el.Telefono,
                        IdEmpleado = el.IdEmpleado,
                    }
                ) ;
            });

            return Ok(lstResponse);
        }
        
        [HttpGet("{id}", Name = "GetEmpleadoById")]
        public IActionResult GetEmpleadoById(int id)
        {
            var empleadoDb = _context.Empleados.Find(id);

            if (empleadoDb == null) return NotFound();

            EmpleadoResponse empleado = new()
            {
                IdEmpleado = empleadoDb.IdEmpleado,
                IdTipoEmpleado = empleadoDb.IdTipoEmpleado,
                Paterno = empleadoDb.Paterno,
                Materno = empleadoDb.Materno,
                Nombre = empleadoDb.Nombre,
                Telefono = empleadoDb.Telefono,
                IdCuenta = empleadoDb.IdCuenta
            };

            return Ok(empleado);
        }
    }
}
