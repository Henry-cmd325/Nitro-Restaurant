using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public interface IPrimaService
    {
        public ServerResponse<PrimaResponse> GetPrima(int id);
        public ServerResponse<List<PrimaResponse>> GetPrimas();
        public ServerResponse<PrimaResponse> CreatePrima(PrimaRequest request);
        public ServerResponse<List<PrimaResponse>> GetPrimas(string empleado);
        public ServerResponse<PrimaResponse> DeletePrima(int id);
        public ServerResponse<PrimaResponse> PutPrima(int id, PrimaRequest request);  
    }
}
