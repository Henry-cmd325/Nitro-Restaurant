using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public interface IEmployeeService
    {
        public ServerResponse<EmpleadoResponse> Auth(EmpleadoAuthRequest model);
        public ServerResponse<EmpleadoResponse> SignIn(EmpleadoRequest model);
        public ServerResponse<EmpleadoResponse> Get(int id);

    }
}
