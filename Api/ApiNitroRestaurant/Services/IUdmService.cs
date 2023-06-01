using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public interface IUdmService
    {
        public ServerResponse<UdmResponse> GetUdm(int id);
        public ServerResponse<List<UdmResponse>> GetUdms();
        public ServerResponse<UdmResponse> PostUdm(UdmRequest request);
        public ServerResponse<UdmResponse> PutUdm(int id, UdmRequest request);
    }
}
