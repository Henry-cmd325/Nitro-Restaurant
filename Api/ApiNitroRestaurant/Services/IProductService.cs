using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public interface IProductService
    {
        public ServerResponse<List<ProductResponse>> GetAll(string empleado);
        public ServerResponse<List<ProductResponse>> GetAll();
        public ServerResponse<ProductResponse> GetProduct(int id);
        public ServerResponse<ProductResponse> CreateProduct(ProductRequest model);
        public ServerResponse<ProductResponse> UpdateProduct(int id, ProductRequest model);
    }
}
