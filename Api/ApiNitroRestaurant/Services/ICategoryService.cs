using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNitroRestaurant.Services
{
    public interface ICategoryService
    {
        public ServerResponse<CategoryResponse> GetCategory(int id);
        public ServerResponse<CategoryResponse> DeleteCategory(int id);
        public ServerResponse<CategoryResponse> PostCategory(CategoriaRequest categoryName);
    }
}
