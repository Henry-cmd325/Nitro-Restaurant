using ApiNitroRestaurant.Context;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public class SucursalService : ISucursalService
    {
        private readonly db_nitrorestaurantContext _context;
        public SucursalService(db_nitrorestaurantContext context)
        {
            _context = context;
        }

        public ServerResponse<List<SucursalResponse>> GetAllSucursal()
        {
            ServerResponse<List<SucursalResponse>> response = new();
            response.Data = new();

            var dbSucursales = _context.Sucursales.ToList();

            foreach (var dbSucursal in dbSucursales)
            {
                response.Data.Add(new()
                {
                    IdSucursal = dbSucursal.IdSucursal,
                    Nombre = dbSucursal.Nombre,
                    NumMesas = dbSucursal.NumMesas,
                    Ubicacion = dbSucursal.Ubicacion
                });
            }

            return response;
        }

        public ServerResponse<SucursalResponse> GetSucursal(int id)
        {
            ServerResponse<SucursalResponse> response = new();

            var dbSucursal = _context.Sucursales.Where(s => s.IdSucursal == id).FirstOrDefault();
            if (dbSucursal == null)
            {
                response.Success = false;
                response.Error = "El id introducido no corresponde con ningun registro";

                return response;
            }

            response.Data = new()
            {
                IdSucursal = dbSucursal.IdSucursal,
                Nombre = dbSucursal.Nombre,
                NumMesas = dbSucursal.NumMesas,
                Ubicacion = dbSucursal.Ubicacion
            };

            return response;
        }

        public ServerResponse<SucursalResponse> PostSucursal(SucursalRequest request)
        {
            ServerResponse<SucursalResponse> response = new();

            var dbSucursal = _context.Sucursales.Where(s => s.Nombre == request.Nombre).FirstOrDefault();
            if (dbSucursal != null)
            {
                response.Success = false;
                response.Error = "Ya existe una sucursal con ese mismo nombre";

                return response;
            }

            Sucursale newSucursal = new()
            {
                Nombre = request.Nombre,
                NumMesas = request.NumMesas,
                Ubicacion = request.Ubicacion
            };
        
            _context.Sucursales.Add(newSucursal);
            _context.SaveChanges();

            response.Data = new()
            {
                IdSucursal = newSucursal.IdSucursal,
                Nombre = request.Nombre,
                NumMesas = request.NumMesas,
                Ubicacion = request.Ubicacion
            };

            return response;
        }

        public ServerResponse<SucursalResponse> PutSucursal(int id, SucursalRequest request)
        {
            ServerResponse<SucursalResponse> response = new();

            var dbSucursal = _context.Sucursales.Where(s => s.IdSucursal == id).FirstOrDefault();
            if (dbSucursal == null)
            {
                response.Success = false;
                response.Error = "El id introducido no corresponde con ningun registro";

                return response;
            }

            dbSucursal.Nombre = request.Nombre;
            dbSucursal.NumMesas = request.NumMesas;
            dbSucursal.Ubicacion = request.Ubicacion;

            _context.Entry(dbSucursal);
            _context.SaveChanges();

            return response;
        }
    }
}
