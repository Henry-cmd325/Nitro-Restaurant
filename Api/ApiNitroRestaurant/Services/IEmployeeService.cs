using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public interface IEmployeeService
    {
        public ServerResponse<EmpleadoResponse> Auth(EmpleadoAuthRequest model);
        public ServerResponse<EmpleadoResponse> SignUp(EmpleadoRequest model);
        public ServerResponse<EmpleadoResponse> Disable(int id);
        public ServerResponse<EmpleadoResponse> Get(int id);
        public ServerResponse<List<EmpleadoResponse>> GetAll(string empleado);
        public ServerResponse<List<EmpleadoResponse>> GetAll();
        public string GenerateToken(EmpleadoResponse request, IConfiguration config);
    }
}
