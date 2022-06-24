using ApiNitroRestaurant.Models;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;
using ApiNitroRestaurant.Tools;

namespace ApiNitroRestaurant.Services
{
    public class AccountService : IAccountService
    {
        private readonly NitroRestaurantContext _context;
         public AccountService(NitroRestaurantContext context)
         {
             _context = context;
         }

         public ServerResponse<AccountResponse> Auth(AccountRequest model)
         {
            ServerResponse<AccountResponse> response = new();

             var password = Encrypt.GetSha256(model.Password);

             var account = _context.Cuentas.Where((acc) => acc.Password == password && acc.Username == model.Username)
                           .FirstOrDefault();

            if (account == null)
            {
                response.Error = "EL usuario o la contraseña son incorrectas";
                response.Success = false;

                return response;
            }

            var accountResponse = new AccountResponse();

            accountResponse.Username = model.Username;

            response.Data = accountResponse;

            return response;
         }

        public ServerResponse<Cuenta> GetAccount(int id)
        {
            var account = _context.Cuentas.Where((c) => c.IdCuenta == id).FirstOrDefault();

            ServerResponse<Cuenta> response = new();
          
            if (account == null)
            {
                response.Error = "El id se ha pasado del rango de datos disponible";
                response.Success = false;

                return response;
            }

            response.Data = account;
            return response;
        }

        public ServerResponse<EmpleadoResponse> SignIn(SignInRequest model)
        {
            ServerResponse<EmpleadoResponse> serverResponse = new();

            model.Cuenta.Password = Encrypt.GetSha256(model.Cuenta.Password);

            var accountDb = _context.Cuentas.Where(d => d.Username == model.Cuenta.Username
                                    && d.Password == model.Cuenta.Password).FirstOrDefault();

            if (accountDb != null) return null;

            var account = new Cuenta();
            account.Username = model.Cuenta.Username;
            account.Password = model.Cuenta.Password;

            _context.Cuentas.Add(account);

            var attributeType = _context.TipoEmpleados.Where(t => t.Nombre == model.TipoEmpleado.Nombre)
                                .FirstOrDefault();

            var employee = new Empleado();
            employee.Nombre = model.Nombre;
            employee.Paterno = model.Paterno;
            employee.Materno = model.Materno;
            employee.Telefono = model.Telefono;

            if (attributeType == null)
            {
                serverResponse.Success = false;
                serverResponse.Error = "El tipo de empleado elegido no existe";
            }
            else
                employee.IdTipoEmpleado = attributeType.IdTipoEmpleado;

            _context.SaveChanges();

            employee.IdCuenta = account.IdCuenta;
            _context.Empleados.Add(employee);
            _context.SaveChanges();

            var employeeDb = _context.Empleados.Where(e => e.IdEmpleado == employee.IdEmpleado).FirstOrDefault();

            var employeeResponse = new EmpleadoResponse();
            employeeResponse.Nombre = employeeDb.Nombre;
            employeeResponse.Materno = employeeDb.Materno;
            employeeResponse.Paterno = employeeDb.Paterno;
            employeeResponse.Telefono = employeeDb.Telefono;
            employeeResponse.IdTipoEmpleado = employeeDb.IdTipoEmpleado;
            employeeResponse.IdCuenta = employeeDb.IdCuenta;

            serverResponse.Data = employeeResponse;

            return serverResponse;
        }
    }
}