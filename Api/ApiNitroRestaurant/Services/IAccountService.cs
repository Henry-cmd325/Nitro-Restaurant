using ApiNitroRestaurant.Models;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public interface IAccountService
    {
        public AccountResponse Auth(AccountRequest model);
        public Empleado? SignIn(SignInRequest model);
        public Cuenta? GetAccount(int id);
    }
}
