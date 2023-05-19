using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public interface IEntranceService
    {
        public ServerResponse<EntradaResponse> GetEntrance(int id);
        public ServerResponse<List<EntradaResponse>> GetEntrances(string empleado);
        public ServerResponse<EntradaResponse> PostEntrance(EntradaRequest request);
        public ServerResponse<bool> DeleteEntrance(int id);
        public ServerResponse<EntradaResponse> PutEntrance(int id, EntradaRequest request);
    }
}
