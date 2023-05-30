using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public interface IProveedorService
    {
        public ServerResponse<List<ProveedorResponse>> GetAllProveedores();
        public ServerResponse<ProveedorResponse> GetProveedor(int id);
        public ServerResponse<ProveedorResponse> PostProveedor(ProveedorRequest request);
        public ServerResponse<ProveedorResponse> PutProveedor(int id, ProveedorRequest request);
    }
}
