using ApiNitroRestaurant.Models;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;
using ApiNitroRestaurant.Tools;

namespace ApiNitroRestaurant.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly db_nitrorestaurantContext _context;
        public EmployeeService(db_nitrorestaurantContext context)
        {
            _context = context;
        }
        public ServerResponse<EmpleadoResponse> Auth(EmpleadoAuthRequest model)
        {
            ServerResponse<EmpleadoResponse> response = new();

            var password = Encrypt.GetSha256(model.Password);

            var employee = _context.Empleados.Where(e => e.Usuario == model.Username 
                                                    && e.Contrasenia == Encrypt.GetSha256(model.Password)).FirstOrDefault();

            if (employee == null)
            {
                response.Success = false;

                if (_context.Empleados.Where(e => e.Usuario == model.Username && e.ContraseniaAnterior == Encrypt.GetSha256(model.Password)).FirstOrDefault() == null)
                {
                    response.Error = "La contraseña ingresada es una contraseña anterior";

                    return response;
                }

                response.Error = "El usuario o la contraseña ingresada no corresponden con ningun registro";
                
                return response;
            }

            if (employee.Activo == 0)
            {
                response.Success = false;
                response.Error = "La cuenta con la que quiere ingresar ha sido dado de baja";

                return response;
            }

            var dbTipoEmpleado = _context.TipoEmpleados.Where(t => t.IdTipoEmpleado == employee.IdTipoEmpleado).First();
            var dbSucursal = _context.Sucursales.Where(s => s.IdSucursal == employee.IdSucursal).First();

            response.Data = new EmpleadoResponse()
            {
                IdEmpleado = employee.IdEmpleado,
                TipoEmpleado = dbTipoEmpleado.Nombre,
                Usuario = employee.Usuario,
                Nombre = employee.Nombre,
                Paterno = employee.Paterno,
                Materno = employee.Materno,
                Telefono = employee.Telefono,
                Activo = true,
                Sucursal = dbSucursal.Nombre
            };

            return response;
        }

        public ServerResponse<EmpleadoResponse> Disable(int id)
        {
            var response = new ServerResponse<EmpleadoResponse>();

            var dbEmployee = _context.Empleados.Where(e => e.IdEmpleado == id).FirstOrDefault();
            if (dbEmployee == null)
            {
                response.Success = false;
                response.Error = "El id introducido no corresponde con ningun empleado";

                return response;
            }

            dbEmployee.Activo = (ulong)(dbEmployee.Activo == 1? 0: 1);
            _context.Entry(dbEmployee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

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


            var dbTipoEmpleado = _context.TipoEmpleados.Where(t => t.IdTipoEmpleado == employee.IdTipoEmpleado).First();
            var dbSucursal = _context.Sucursales.Where(s => s.IdSucursal == employee.IdSucursal).First();

            response.Data = new EmpleadoResponse()
            {
                IdEmpleado = employee.IdEmpleado,
                TipoEmpleado = dbTipoEmpleado.Nombre,
                Usuario = employee.Usuario,
                Nombre = employee.Nombre,
                Paterno = employee.Paterno,
                Materno = employee.Materno,
                Activo = employee.Activo == 1,
                Telefono = employee.Telefono,
                Sucursal = dbSucursal.Nombre
            };

            return response;
        }

        public ServerResponse<List<EmpleadoResponse>> GetAll()
        {
            ServerResponse<List<EmpleadoResponse>> response = new();

            var listResponse = new List<EmpleadoResponse>();

            var listDb = _context.Empleados.ToList();

            if (listDb.Count == 0)
            {
                response.Error = "No existe ningun empleado en la base de datos";
                response.Success = false;

                return response;
            }

            foreach(var empleado in listDb)
            {
                var dbTipoEmpleado = _context.TipoEmpleados.Where(t => t.IdTipoEmpleado == empleado.IdTipoEmpleado).First();
                var dbSucursal = _context.Sucursales.Where(s => s.IdSucursal == empleado.IdSucursal).First();

                listResponse.Add(new EmpleadoResponse()
                {
                    IdEmpleado = empleado.IdEmpleado,
                    Materno = empleado.Materno,
                    Usuario = empleado.Usuario,
                    Telefono = empleado.Telefono,
                    Paterno = empleado.Paterno,
                    Nombre = empleado.Nombre,
                    TipoEmpleado = dbTipoEmpleado.Nombre,
                    Sucursal = dbSucursal.Nombre
                });
            }

            response.Data = listResponse;

            return response;
        }

        public ServerResponse<EmpleadoResponse> SignUp(EmpleadoRequest model)
        {
            ServerResponse<EmpleadoResponse> response = new();

            var employeeDb = _context.Empleados.Where(e => e.Telefono == model.Telefono).FirstOrDefault();

            if (employeeDb != null)
            {
                response.Success = false;
                response.Error = "Ya existe otra cuenta con este mismo numero de telefono";

                return response;
            }

            var atribbuteType = _context.TipoEmpleados.Where(t => t.Nombre == t.Nombre).FirstOrDefault();
            if (atribbuteType == null)
            {
                response.Success = false;
                response.Error = "El tipo de usuario elegido no existe";

                return response;
            }
          

            var employee = new Empleado();
            employee.Telefono = model.Telefono;
            employee.IdSucursal = model.IdSucursal;
            employee.Usuario = model.Usuario;
            employee.Materno = model.Materno;
            employee.Paterno = model.Paterno;
            employee.Nombre = model.Nombre;
            employee.Contrasenia = Encrypt.GetSha256(model.Contrasenia);
            employee.IdTipoEmpleado = atribbuteType.IdTipoEmpleado;
            employee.Activo = 1;

            _context.Empleados.Add(employee);
            _context.SaveChanges();

            var dbTipo = _context.Empleados.Where(e => e.IdTipoEmpleado == employee.IdTipoEmpleado).FirstOrDefault();
            if (dbTipo == null)
            {
                response.Success = false;
                response.Error = "El id del tipo-empleado introducido no existe";

                return response;
            }

            var dbSucursal = _context.Sucursales.Where(s => s.IdSucursal == employee.IdSucursal).FirstOrDefault();
            if (dbSucursal == null)
            {
                response.Success = false;
                response.Error = "El id de la sucursal introducida no existe";

                return response;
            }

            var employeeResponse = new EmpleadoResponse()
            {
                IdEmpleado = employee.IdEmpleado,
                Telefono = employee.Telefono,
                Materno = employee.Materno,
                Paterno = employee.Paterno,
                Nombre = employee.Nombre,
                TipoEmpleado = dbTipo.Nombre,
                Usuario = employee.Usuario,
                Contrasenia = employee.Contrasenia,
                Sucursal = dbSucursal.Nombre
            };

            response.Data = employeeResponse;

            return response;  
        }
    }
}
