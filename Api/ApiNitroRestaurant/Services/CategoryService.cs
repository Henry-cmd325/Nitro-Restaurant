using ApiNitroRestaurant.Context;
using ApiNitroRestaurant.Models;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly db_nitrorestaurantContext _context;
        public CategoryService(db_nitrorestaurantContext context)
        {
            _context = context;
        }

        public ServerResponse<List<CategoryResponse>> GetAll(string empleado)
        {
            ServerResponse<List<CategoryResponse>> response = new();


            var listResponse = new List<CategoryResponse>();

            var empleadoDb = _context.Empleados.Where(e => e.Usuario == empleado).First();
            var listDb = _context.Categorias.Where(c => c.IdSucursal == empleadoDb.IdSucursal).ToList();

            if (listDb.Count == 0)
            {
                response.Error = "No existe ningún elemento en categorias";
                response.Success = false;

                return response;
            }

            foreach (var item in listDb)
            {
                listResponse.Add(new CategoryResponse()
                {
                    Nombre = item.Nombre,
                    IdCategoria = item.IdCategoria,
                    ImgUrl = item.ImgUrl,
                    IdSucursal = item.IdSucursal
                });
            }

            response.Data = listResponse;

            return response;
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

            var categoryResponse = new CategoryResponse()
            {
                IdCategoria = categoryDb.IdCategoria,
                Nombre = categoryDb.Nombre,
                ImgUrl = categoryDb.ImgUrl,
                IdSucursal = categoryDb.IdSucursal
            };

            response.Data = categoryResponse;

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
            category.IdSucursal = model.IdSucursal;
            category.ImgUrl = category.ImgUrl;

            _context.Categorias.Add(category);
            _context.SaveChanges();

            var categoryResponse = new CategoryResponse();

            categoryResponse.IdCategoria = category.IdCategoria;
            categoryResponse.IdSucursal = category.IdSucursal;
            categoryResponse.ImgUrl = category.ImgUrl;
            categoryResponse.Nombre = category.Nombre;

            response.Data = categoryResponse;

            return response;
        }

        public ServerResponse<CategoryResponse> PutCategory(int id, CategoriaRequest model)
        {
            ServerResponse<CategoryResponse> response = new();

            var categoryDb = _context.Categorias.Where(c => c.IdCategoria == id).FirstOrDefault();

            if (categoryDb == null)
            {
                response.Error = "No existe ninguna categoria con el id introducido";
                response.Success = false;

                return response;
            }

            categoryDb.Nombre = model.Nombre;

            _context.Entry(categoryDb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            response.Data = new CategoryResponse()
            {
                IdCategoria = categoryDb.IdCategoria,
                Nombre = model.Nombre
            };

            return response;
        }

        public ServerResponse<List<CategoryResponse>> GetAll()
        {
            ServerResponse<List<CategoryResponse>> response = new();

            var listResponse = new List<CategoryResponse>();

            var listDb = _context.Categorias.ToList();

            if (listDb.Count == 0)
            {
                response.Error = "No existe ningún elemento en categorias";
                response.Success = false;

                return response;
            }

            foreach (var item in listDb)
            {
                listResponse.Add(new CategoryResponse()
                {
                    Nombre = item.Nombre,
                    IdCategoria = item.IdCategoria,
                    ImgUrl = item.ImgUrl,
                    IdSucursal = item.IdSucursal
                });
            }

            response.Data = listResponse;

            return response;
        }
    }
}
