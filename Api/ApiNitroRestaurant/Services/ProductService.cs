using ApiNitroRestaurant.Context;
using ApiNitroRestaurant.Models;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;
using System.Text;

namespace ApiNitroRestaurant.Services
{
    public class ProductService : IProductService
    {
        private readonly db_nitrorestaurantContext _context;
        public ProductService(db_nitrorestaurantContext context)
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

            var categoria = _context.Categorias.Where(c => c.IdCategoria == model.IdCategoria).FirstOrDefault();

            if (categoria == null)
            {
                response.Success = false;
                response.Error = "La categoria elegida para el producto no existe";

                return response;
            }

            foreach (var item in model.primaList)
            {
                int repetidas = 0;
                foreach (var item2 in model.primaList)
                {
                    if (item.IdPrima == item2.IdPrima)
                        repetidas++;
                }

                if (repetidas >= 2)
                {
                    response.Success = false;
                    response.Error = "No puedes repetir un mismo ingrediente para un producto";

                    return response;
                }
            }

            var product = new Producto()
            {
                IdCategoria = categoria.IdCategoria,
                Nombre = model.Nombre,
                Inversion = model.Inversion,
                Precio = model.Precio,
                ImgUrl = model.ImgUrl,
                Cantidad = model.Cantidad,
                IdUm = model.IdUm,
                IdSucursal = model.IdSucursal
            };

            _context.Productos.Add(product);
            _context.SaveChanges();

            if (model.primaList.Count > 0)
            {
                foreach (var prima in model.primaList)
                {
                    _context.PrimasProductos.Add(new()
                    {
                        IdPrima = prima.IdPrima,
                        IdProduto = product.IdProducto,
                        CantidadPrima = prima.Cantidad
                    });
                }
                _context.SaveChanges();
            }
            

            var productResponse = new ProductResponse()
            {
                IdProducto = product.IdProducto,
                IdCategoria = product.IdCategoria,
                Nombre = product.Nombre,
                Inversion = product.Inversion,
                Precio = product.Precio,
                ImgUrl = product.ImgUrl,
                Cantidad = product.Cantidad,
                IdUm = product.IdUm,
                IdSucursal = product.IdSucursal
            };

            response.Data = productResponse;

            return response;
        }

        public ServerResponse<List<ProductResponse>> GetAll()
        {
            ServerResponse<List<ProductResponse>> response = new();

            var listResponse = new List<ProductResponse>();

            var productsDb = _context.Productos.ToList();

            if (productsDb.Count == 0)
            {
                response.Success = false;
                response.Error = "No existe ningún producto en la base de datos";

                return response;
            }

            foreach (var product in productsDb)
            {
                listResponse.Add(new ProductResponse()
                {
                    IdProducto = product.IdProducto,
                    IdCategoria = product.IdCategoria,
                    Nombre = product.Nombre,
                    Inversion = product.Inversion,
                    Precio = product.Precio,
                    ImgUrl = product.ImgUrl,
                    Cantidad = product.Cantidad,
                    IdUm = product.IdUm,
                    IdSucursal = product.IdSucursal
                });
            }

            response.Data = listResponse;

            return response;
        }

        public ServerResponse<List<ProductResponse>> GetAll(string empleado)
        {
            ServerResponse<List<ProductResponse>> response = new();

            var listResponse = new List<ProductResponse>();

            var empleadoDb = _context.Empleados.Where(e => e.Usuario == empleado).First();
            var productsDb = _context.Productos.Where(p => p.IdSucursal == empleadoDb.IdSucursal).ToList();

            if (productsDb.Count == 0)
            {
                response.Success = false;
                response.Error = "No existe ningún producto en la base de datos";

                return response;
            }

            foreach (var product in productsDb)
            {
                listResponse.Add(new ProductResponse()
                {
                    IdProducto = product.IdProducto,
                    IdCategoria = product.IdCategoria,
                    Nombre = product.Nombre,
                    Inversion = product.Inversion,
                    Precio = product.Precio,
                    ImgUrl = product.ImgUrl,
                    Cantidad = product.Cantidad,
                    IdUm = product.IdUm,
                    IdSucursal = product.IdSucursal
                });
            }

            response.Data = listResponse;

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
                ImgUrl = product.ImgUrl,
                Cantidad = product.Cantidad,
                IdUm = product.IdUm,
                IdSucursal = product.IdSucursal
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

            var categoria = _context.Categorias.Where(c => c.IdCategoria == model.IdCategoria).FirstOrDefault();
            if (categoria == null)
            {
                response.Error = "La categoria elegida para el producto no existe";
                response.Success = false;

                return response;
            }

            foreach (var item in model.primaList)
            {
                int repetidas = 0;
                foreach (var item2 in model.primaList)
                {
                    if (item.IdPrima == item2.IdPrima)
                        repetidas++;
                }

                if (repetidas >= 2)
                {
                    response.Success = false;
                    response.Error = "No puedes repetir un mismo ingrediente para un producto";

                    return response;
                }
            }

            productDb.Nombre = model.Nombre;
            productDb.IdCategoria = categoria.IdCategoria;
            productDb.Precio = model.Precio;
            productDb.Inversion = model.Inversion;
            productDb.ImgUrl = model.ImgUrl;
            productDb.Cantidad = model.Cantidad;
            productDb.IdUm = model.IdUm;
            productDb.IdSucursal = model.IdSucursal;

            _context.Entry(productDb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            if (model.primaList.Count > 0)
            {
                int count = 0;

                var dbList = _context.PrimasProductos.Where(p => p.IdProduto == productDb.IdProducto).ToList();
                while (model.primaList.Count < dbList.Count)
                {
                    _context.PrimasProductos.Remove(dbList.Last());
                    dbList.Remove(dbList.Last());
                }
                _context.SaveChanges();

                while (model.primaList.Count > count)
                {
                    dbList[count].IdPrima = model.primaList[count].IdPrima;
                    dbList[count].CantidadPrima = model.primaList[count].Cantidad;
                    _context.Entry(dbList[count]).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    count++;
                }

                _context.SaveChanges();
            }
            response.Data = new ProductResponse()
            {
                IdProducto = id,
                IdCategoria = productDb.IdCategoria,
                Nombre = productDb.Nombre,
                Inversion = productDb.Inversion,
                Precio = productDb.Precio,
                ImgUrl = model.ImgUrl,
                Cantidad = model.Cantidad,
                IdUm = model.IdUm,
                IdSucursal = model.IdSucursal
            };

            return response;
        }
    }
}
