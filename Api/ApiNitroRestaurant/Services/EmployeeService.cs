using ApiNitroRestaurant.Models;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly NitroRestaurantContext _context;
        public EmployeeService(NitroRestaurantContext context)
        {
            _context = context;
        }
        public ServerResponse<EmpleadoResponse> Auth(EmpleadoAuthRequest model)
        {
            ServerResponse<EmpleadoResponse> response = new();

            var employee = _context.Empleados.Where(e => e.Telefono == model.Telefono).FirstOrDefault();

            if (employee == null)
            {
                response.Success = false;
                response.Error = "El numero telefonico no esta registrado";

                return response;
            }

            response.Data = new EmpleadoResponse()
            {
                IdEmpleado = employee.IdEmpleado,
                IdTipoEmpleado = employee.IdTipoEmpleado,
                Nombre = employee.Nombre,
                Paterno = employee.Paterno,
                Materno = employee.Materno,
                Telefono = employee.Telefono
            };

            return response;
        }

        public ServerResponse<EmpleadoResponse> Get(int id)
        {
            var employee = _context.Empleados.Where(e => e.IdEmpleado == id).FirstOrDefault();

            ServerResponse<EmpleadoResponse> response = new();

            if (employee == null)
            {
                response.Success = false;
                response.Error = "No existe ningun empleado con el id introducido";

                return response;
            }

            response.Data = new EmpleadoResponse()
            {
                IdEmpleado = employee.IdEmpleado,
                IdTipoEmpleado = employee.IdTipoEmpleado,
                Nombre = employee.Nombre,
                Paterno = employee.Paterno,
                Materno = employee.Materno,
                Telefono = employee.Telefono
            };

            return response;
        }

        public ServerResponse<EmpleadoResponse> SignIn(EmpleadoRequest model)
        {
            ServerResponse<EmpleadoResponse> response = new();

            var employeeDb = _context.Empleados.Where(e => e.Telefono == model.Telefono).FirstOrDefault();

            if (employeeDb != null)
            {
                response.Success = false;
                response.Error = "Ya existe otra cuenta con este mismo numero de telefono";

                return response;
            }

            var atribbuteType = _context.TipoEmpleados.Where(t => t.Nombre == model.TipoEmpleado.Nombre).FirstOrDefault();

            if (atribbuteType == null)
            {
                response.Success = false;
                response.Error = "El tipo de usuario elegido no existe";

                return response;
            }
            else if (atribbuteType.Nombre != "Mesero")
            {
                response.Success = false;
                response.Error = "Este endpoint solo es para crear usuarios de tipo Mesero";

                return response;
            }

            var employee = new Empleado();
            employee.Telefono = model.Telefono;
            employee.Materno = model.Materno;
            employee.Paterno = model.Paterno;
            employee.Nombre = model.Nombre;
            employee.IdTipoEmpleado = atribbuteType.IdTipoEmpleado;

            _context.Empleados.Add(employee);
            _context.SaveChanges();

            var employeeResponse = new EmpleadoResponse()
            {
                IdEmpleado = employee.IdEmpleado,
                Telefono = employee.Telefono,
                Materno = employee.Materno,
                Paterno = employee.Paterno,
                Nombre = employee.Nombre
            };

            response.Data = employeeResponse;

            return response;  
        }
    }
}
