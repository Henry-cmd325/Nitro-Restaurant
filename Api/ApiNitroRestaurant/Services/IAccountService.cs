using ApiNitroRestaurant.Models;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public interface IAccountService
    {
        public ServerResponse<AccountResponse> Auth(AccountRequest model);
        public ServerResponse<EmpleadoResponse> SignIn(SignInRequest model);
        public ServerResponse<Cuenta> GetAccount(int id);
    }
}
