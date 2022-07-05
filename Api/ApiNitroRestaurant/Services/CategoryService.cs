using ApiNitroRestaurant.Models;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly NitroRestaurantContext _context;
        public CategoryService(NitroRestaurantContext context)
        {
            _context = context;
        }
        public ServerResponse<CategoryResponse> DeleteCategory(int id)
        {
            var response = new ServerResponse<CategoryResponse>();

            var categoryDb = _context.Categorias.Where(c => c.IdCategoria == id).FirstOrDefault();

            if (categoryDb == null)
            {
                response.Error = "El id introducido no coincide con el id de ninguna categoria registrada";
                response.Success = false;

                return response;
            }

            
            _context.Categorias.Remove(categoryDb);
            _context.SaveChanges();

            return response;
        }

        public ServerResponse<CategoryResponse> GetCategory(int id)
        {
            var response = new ServerResponse<CategoryResponse>();

            var categoryDb = _context.Categorias.Where(c => c.IdCategoria == id).FirstOrDefault();

            if(categoryDb == null)
            {
                response.Error = "El id introducido no coincide con el id de ninguna categoria registrada";
                response.Success = false;

                return response;
            }

            return response;
        }

        public ServerResponse<CategoryResponse> PostCategory(CategoriaRequest model)
        {
            var response = new ServerResponse<CategoryResponse>();

            var categoryDb = _context.Categorias.Where(c => c.Nombre == model.Nombre).FirstOrDefault();

            if (categoryDb != null)
            {
                response.Error = "La categoria que quieres crear ya existe";
                response.Success = false;

                return response;
            }

            var category = new Categoria();

            category.Nombre = model.Nombre;

            _context.Categorias.Add(category);
            _context.SaveChanges();

            var categoryResponse = new CategoryResponse();

            categoryResponse.IdCategoria = category.IdCategoria; 
            categoryResponse.Nombre = category.Nombre;

            response.Data = categoryResponse;

            return response;
        }
    }
}
