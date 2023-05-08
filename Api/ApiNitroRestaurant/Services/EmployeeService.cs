using ApiNitroRestaurant.Context;
using ApiNitroRestaurant.Models;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;
using ApiNitroRestaurant.Tools;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

                employee = _context.Empleados.Where(e => e.Usuario == model.Username 
                                                    && e.ContraseniaAnterior == Encrypt.GetSha256(model.Password)).FirstOrDefault();

                if (employee != null)
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
                response.Error = "La cuenta con la que quiere ingresar ha sido dada de baja";

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

        public string GenerateToken(EmpleadoResponse request, IConfiguration config)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.Nombre),
                new Claim(ClaimTypes.Role, request.TipoEmpleado)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("JWT:Key").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddHours(1), signingCredentials: creds);

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
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

            employeeDb = _context.Empleados.Where(e => e.Usuario == model.Usuario).FirstOrDefault();
            if (employeeDb != null)
            {
                response.Success = false;
                response.Error = "Ya existe otra cuenta con este mismo nombre de usuario";

                return response;
            }
         
            var dbTipo = _context.TipoEmpleados.Where(t => t.Nombre == t.Nombre).FirstOrDefault();
            if (dbTipo == null)
            {
                response.Success = false;
                response.Error = "El tipo de usuario elegido no existe";

                return response;
            }

            var dbSucursal = _context.Sucursales.Where(s => s.IdSucursal == model.IdSucursal).FirstOrDefault();
            if (dbSucursal == null)
            {
                response.Success = false;
                response.Error = "El id de la sucursal introducida no existe";

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
            employee.IdTipoEmpleado = model.IdTipoEmpleado;
            employee.Activo = 1;

            _context.Empleados.Add(employee);
            _context.SaveChanges();

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

        public ServerResponse<List<EmpleadoResponse>> GetAll(string empleado)
        {
            ServerResponse<List<EmpleadoResponse>> response = new();

            var listResponse = new List<EmpleadoResponse>();

            var employeeDb = _context.Empleados.Where(e => e.Usuario == empleado).First();
            var listDb = _context.Empleados.Where(e => e.IdSucursal == employeeDb.IdSucursal).ToList();

            if (listDb.Count == 0)
            {
                response.Error = "No existe ningun empleado en la base de datos";
                response.Success = false;

                return response;
            }

            foreach (var empleadoDb in listDb)
            {
                var dbTipoEmpleado = _context.TipoEmpleados.Where(t => t.IdTipoEmpleado == empleadoDb.IdTipoEmpleado).First();
                var dbSucursal = _context.Sucursales.Where(s => s.IdSucursal == empleadoDb.IdSucursal).First();

                listResponse.Add(new EmpleadoResponse()
                {
                    IdEmpleado = empleadoDb.IdEmpleado,
                    Materno = empleadoDb.Materno,
                    Usuario = empleadoDb.Usuario,
                    Telefono = empleadoDb.Telefono,
                    Paterno = empleadoDb.Paterno,
                    Nombre = empleadoDb.Nombre,
                    TipoEmpleado = dbTipoEmpleado.Nombre,
                    Sucursal = dbSucursal.Nombre
                });
            }

            response.Data = listResponse;

            return response;
        }
    }
}
