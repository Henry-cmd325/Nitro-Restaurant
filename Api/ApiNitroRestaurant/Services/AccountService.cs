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

         public AccountResponse Auth(AccountRequest model)
         {
             AccountResponse response = null;

             var password = Encrypt.GetSha256(model.Password);

             var account = _context.Cuentas.Where((acc) => acc.Password == password &&
                                                 acc.Username == model.Username).FirstOrDefault();

             if (account != null) response = new AccountResponse { Username = model.Username };

             return response;
         }

        public Empleado? SignIn(SignInRequest model)
        { 
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
                return null;
            else
                employee.IdTipoEmpleado = attributeType.IdTipoEmpleado;

            _context.SaveChanges();

            employee.IdCuenta = account.IdCuenta;
            _context.Empleados.Add(employee);
            _context.SaveChanges();

            var employeeDb = _context.Empleados.Where(e => e.IdEmpleado == employee.IdEmpleado).FirstOrDefault();

            return employeeDb;

        }

        public Cuenta? GetAccount(int id)
        {
            var account = _context.Cuentas.Where((c) => c.IdCuenta == id).FirstOrDefault();

            return account;
        }
    }
}