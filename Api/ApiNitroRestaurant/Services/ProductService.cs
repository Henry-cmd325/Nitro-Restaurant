using ApiNitroRestaurant.Models;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;
using System.Text;

namespace ApiNitroRestaurant.Services
{
    public class ProductService : IProductService
    {
        private readonly NitroRestaurantContext _context;
        public ProductService(NitroRestaurantContext context)
        {
            _context = context; 
        }
        public ServerResponse<ProductResponse> CreateProduct(ProductRequest model)
        {
            ServerResponse<ProductResponse> response = new();

            var productDb = _context.Productos.Where(p => p.Nombre == model.Nombre).FirstOrDefault();

            if (productDb != null)
            {
                response.Success = false;
                response.Error = "El producto que se quiere crear ya existe";

                return response;
            }

            var categoria = _context.Categorias.Where(c => c.Nombre == model.Categoria).FirstOrDefault();

            if (categoria == null)
            {
                response.Success = false;
                response.Error = "La categoria elegida para el producto no existe";

                return response;
            }

            var product = new Producto()
            {
                IdCategoria = categoria.IdCategoria,
                Nombre = model.Nombre,
                Inversion = model.Inversion,
                Precio = model.Precio,
                Disponible = model.Disponible ? Convert.ToInt16(1) : Convert.ToInt16(0),
                Imagen = model.Imagen != null ? Encoding.ASCII.GetBytes(model.Imagen) : null
            };

            _context.Productos.Add(product);
            _context.SaveChanges();

            var productResponse = new ProductResponse()
            {
                IdProducto = product.IdProducto,
                IdCategoria = product.IdCategoria,
                Nombre = product.Nombre,
                Inversion = product.Inversion,
                Precio = product.Precio,
                Disponible = product.Disponible == 1 ? true : false,
                Imagen = product.Imagen != null ? Encoding.UTF8.GetString(product.Imagen) : null
            };

            response.Data = productResponse;

            return response;
        }

        public ServerResponse<ProductResponse> GetProduct(int id)
        {
            ServerResponse<ProductResponse> response = new();

            var product = _context.Productos.Where(p => p.IdProducto == id).FirstOrDefault();

            if (product == null)
            {
                response.Success = false;
                response.Error = "No existe ningun producto con el id introducido";

                return response;
            }

            var productResponse = new ProductResponse()
            {
                IdProducto = id,
                IdCategoria = product.IdCategoria,
                Nombre = product.Nombre,
                Inversion = product.Inversion,
                Precio = product.Precio,
                Disponible = product.Disponible == 1 ? true : false,
                Imagen = product.Imagen != null ? Encoding.UTF8.GetString(product.Imagen) : null
            };

            response.Data = productResponse;

            return response;
        }

        public ServerResponse<ProductResponse> UpdateProduct(int id, ProductRequest model)
        {
            ServerResponse<ProductResponse> response = new();

            var productDb = _context.Productos.Where(p => p.IdProducto == id).FirstOrDefault();

            if(productDb == null)
            {
                response.Error = "No existe ningun producto con el id introducido";
                response.Success = false;

                return response;
            }

            var categoria = _context.Categorias.Where(c => c.Nombre == model.Categoria).FirstOrDefault();

            if (categoria == null)
            {
                response.Error = "La categoria elegida para el producto no existe";
                response.Success = false;

                return response;
            }

            productDb.Nombre = model.Nombre;
            productDb.Disponible = model.Disponible? Convert.ToInt16(1) : Convert.ToInt16(0);
            productDb.Imagen = model.Imagen != null ? Encoding.ASCII.GetBytes(model.Imagen) : null;
            productDb.IdCategoria = categoria.IdCategoria;
            productDb.Precio = model.Precio;
            productDb.Inversion = model.Inversion;

            _context.Entry(productDb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            response.Data = new ProductResponse()
            {
                IdProducto = id,
                IdCategoria = productDb.IdCategoria,
                Nombre = productDb.Nombre,
                Inversion = productDb.Inversion,
                Precio = productDb.Precio,
                Disponible = productDb.Disponible == 1 ? true : false,
                Imagen = productDb.Imagen != null ? Encoding.UTF8.GetString(productDb.Imagen) : null
            };

            return response;
        }
    }
}
