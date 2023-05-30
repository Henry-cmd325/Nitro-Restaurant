using ApiNitroRestaurant.Context;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly db_nitrorestaurantContext _context;
        public ProveedorService(db_nitrorestaurantContext context)
        {
            _context = context;
        }
        public ServerResponse<List<ProveedorResponse>> GetAllProveedores()
        {
            var response = new ServerResponse<List<ProveedorResponse>>();
            response.Data = new();

            var dbProveedores = _context.Proveedores.ToList();

            foreach (var proveedor in dbProveedores)
            {
                response.Data.Add(new()
                {
                    IdProveedor = proveedor.IdProveedor,
                    Nombre = proveedor.Nombre,
                    Telefono1 = proveedor.Telefono1,
                    Telefono2 = proveedor.Telefono2,
                    Telefono3 = proveedor.Telefono3,
                    Direccion = proveedor.Direccion,
                    NumeroCuenta = proveedor.NumeroCuenta,
                });
            }

            return response;
        }

        public ServerResponse<ProveedorResponse> GetProveedor(int id)
        {
            var response = new ServerResponse<ProveedorResponse>();

            var dbProveedor = _context.Proveedores.Where(p => p.IdProveedor == id).FirstOrDefault();
            if (dbProveedor == null)
            {
                response.Success = false;
                response.Error = "El id introducido no corresponde con ningun proveedor";

                return response;
            }

            response.Data = new()
            {
                IdProveedor = dbProveedor.IdProveedor,
                Nombre = dbProveedor.Nombre,
                Telefono1 = dbProveedor.Telefono1,
                Telefono2 = dbProveedor.Telefono2,
                Telefono3 = dbProveedor.Telefono3,
                Direccion = dbProveedor.Direccion,
                NumeroCuenta = dbProveedor.NumeroCuenta,
            };

            return response;
        }

        public ServerResponse<ProveedorResponse> PostProveedor(ProveedorRequest request)
        {
            ServerResponse<ProveedorResponse> response = new();

            var dbProveedor = _context.Proveedores.Where(p => p.Nombre == request.Nombre).FirstOrDefault();
            if (dbProveedor == null)
            {
                response.Success = false;
                response.Error = "El proveedor que quieres agregar ya fue agregado anteriormente";

                return response;
            }

            var newProveedor = new Proveedore()
            {
                Nombre = dbProveedor.Nombre,
                Telefono1 = dbProveedor.Telefono1,
                Telefono2 = dbProveedor.Telefono2,
                Telefono3 = dbProveedor.Telefono3,
                Direccion = dbProveedor.Direccion,
                NumeroCuenta = dbProveedor.NumeroCuenta
            };

            _context.Proveedores.Add(newProveedor);
            _context.SaveChanges();

            response.Data = new()
            {
                Nombre = dbProveedor.Nombre,
                Telefono1 = dbProveedor.Telefono1,
                Telefono2 = dbProveedor.Telefono2,
                Telefono3 = dbProveedor.Telefono3,
                Direccion = dbProveedor.Direccion,
                NumeroCuenta = dbProveedor.NumeroCuenta
            };

            return response;
        }

        public ServerResponse<ProveedorResponse> PutProveedor(int id, ProveedorRequest request)
        {
            ServerResponse<ProveedorResponse> response = new();

            var dbProveedor = _context.Proveedores.Where(p => p.IdProveedor == id).FirstOrDefault();
            if (dbProveedor == null)
            {
                response.Success = false;
                response.Error = "El id introducido no corresponde con ningun registro";

                return response;
            }

            dbProveedor.Nombre = request.Nombre;
            dbProveedor.Telefono1 = request.Telefono1;
            dbProveedor.Telefono2 = request.Telefono2;
            dbProveedor.Telefono3 = request.Telefono3;
            dbProveedor.Direccion = request.Direccion;
            dbProveedor.NumeroCuenta = request.NumeroCuenta;

            _context.Entry(dbProveedor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            response.Data = new()
            {
                IdProveedor = dbProveedor.IdProveedor,
                Telefono1 = dbProveedor.Telefono1,
                Telefono2 = dbProveedor.Telefono2,
                Telefono3 = dbProveedor.Telefono3,
                Direccion = dbProveedor.Direccion,
                NumeroCuenta = dbProveedor.NumeroCuenta
            };

            return response;
        }
    }
}
