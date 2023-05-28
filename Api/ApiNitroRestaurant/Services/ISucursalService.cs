using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public interface ISucursalService
    {
        public ServerResponse<SucursalResponse> GetSucursal(int id);
        public ServerResponse<List<SucursalResponse>> GetAllSucursal();
        public ServerResponse<SucursalResponse> PostSucursal(SucursalRequest request);
        public ServerResponse<SucursalResponse> PutSucursal(int id, SucursalRequest request);
    }
}
