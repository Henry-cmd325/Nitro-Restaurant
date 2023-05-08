using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public interface IOrderService
    {
        public ServerResponse<List<OrderResponse>> GetAllOrders(string empleado);
        public ServerResponse<List<OrderResponse>> GetAllOrders();
        public ServerResponse<OrderResponse> GetOrder(int id);
        public ServerResponse<OrderResponse> DeleteOrder(int id);
        public ServerResponse<OrderResponse> PostOrder(OrderRequest model);
        public ServerResponse<OrderResponse> UpdateOrder(int id, OrderRequest model);
        public ServerResponse<OrderResponse> UpdateState(int id, OrderStateRequest model);
    }
}
