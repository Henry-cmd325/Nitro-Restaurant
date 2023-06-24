using ApiNitroRestaurant.Context;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public class PrimaService : IPrimaService
    {
        private readonly db_nitrorestaurantContext _context;
        public PrimaService(db_nitrorestaurantContext context)
        {
            _context = context;
        }
        public ServerResponse<PrimaResponse> CreatePrima(PrimaRequest request)
        {
            ServerResponse<PrimaResponse> response = new();

            var dbPrima = _context.Primas.Where(p => p.Nombre == request.Nombre).FirstOrDefault();
            if (dbPrima != null)
            {
                response.Success = false;
                response.Error = "Ya existe una prima con el nombre introducido";

                return response;
            }

            var dbSucursal = _context.Sucursales.Where(s => s.IdSucursal == request.IdSucursal).FirstOrDefault();
            if (dbSucursal == null)
            {
                response.Success = false;
                response.Error = "No existe ninguna sucursal con el id introducido";

                return response;
            }

            var newPrima = new Prima()
            {
                IdUm = request.IdUm,
                Nombre = request.Nombre,
                IdSucursal = request.IdSucursal,
                Inversion = request.Inversion,
                Cantidad = request.Cantidad
            };

            _context.Primas.Add(newPrima);
            _context.SaveChanges();

            response.Data = new PrimaResponse()
            {
                IdUm = request.IdUm,
                Nombre = request.Nombre,
                IdSucursal = request.IdSucursal,
                Inversion = request.Inversion,
                Cantidad = request.Cantidad
            };

            return response;
        }

        public ServerResponse<PrimaResponse> DeletePrima(int id)
        {
            ServerResponse<PrimaResponse> response = new();

            var dbPrima = _context.Primas.Where(p => p.IdPrima == id).FirstOrDefault();

            if (dbPrima == null)
            {
                response.Success = false;
                response.Error = "El id introducido no corresponde con ninguna prima";

                return response;
            }

            _context.Remove(dbPrima);
            _context.SaveChanges();

            return response;
        }

        public ServerResponse<PrimaResponse> GetPrima(int id)
        {
            ServerResponse<PrimaResponse> response = new();

            var dbPrima = _context.Primas.Where(p => p.IdPrima == id).FirstOrDefault();

            if (dbPrima == null)
            {
                response.Success = false;
                response.Error = "El id introducio no corresponde con ninguna prima";

                return response;
            }

            response.Data = new()
            {
                IdUm = dbPrima.IdUm,
                Nombre = dbPrima.Nombre,
                IdPrima = dbPrima.IdPrima,
                IdSucursal = dbPrima.IdSucursal,
                Inversion = dbPrima.Inversion,
                Cantidad = dbPrima.Cantidad
            };

            return response;
        }

        public ServerResponse<List<PrimaResponse>> GetPrimas()
        {
            ServerResponse<List<PrimaResponse>> response = new();
            response.Data = new();

            foreach (var prima in _context.Primas.ToList())
            {
                response.Data.Add(new()
                {
                    IdUm = prima.IdUm,
                    Nombre = prima.Nombre,
                    IdPrima = prima.IdPrima,
                    IdSucursal = prima.IdSucursal,
                    Inversion = prima.Inversion,
                    Cantidad = prima.Cantidad
                });
            }

            return response;
        }

        public ServerResponse<List<PrimaResponse>> GetPrimas(string empleado)
        {
            ServerResponse<List<PrimaResponse>> response = new();
            response.Data = new();

            var dbEmpleado = _context.Empleados.Where(e => e.Usuario == empleado).First(); 

            foreach (var prima in _context.Primas.Where(p => p.IdSucursal == dbEmpleado.IdSucursal).ToList())
            {
                response.Data.Add(new()
                {
                    IdUm = prima.IdUm,
                    Nombre = prima.Nombre,
                    IdPrima = prima.IdPrima,
                    IdSucursal = prima.IdSucursal,
                    Inversion = prima.Inversion,
                    Cantidad = prima.Cantidad
                });
            }

            return response;
        }

        public ServerResponse<PrimaResponse> PutPrima(int id, PrimaRequest request)
        {
            ServerResponse<PrimaResponse> response = new();

            var dbPrima = _context.Primas.Where(p => p.IdPrima == id).FirstOrDefault();
            if (dbPrima == null)
            {
                response.Success = false;
                response.Error = "El id introducido no corresponde con ninguna prima";

                return response;
            }

            var dbSucursal = _context.Sucursales.Where(s => s.IdSucursal == request.IdSucursal).FirstOrDefault();
            if (dbSucursal == null)
            {
                response.Success = false;
                response.Error = "No existe ninguna sucursal con el id introducido";

                return response;
            }

            dbPrima.IdUm = request.IdUm;
            dbPrima.Nombre = request.Nombre;
            dbPrima.IdSucursal = request.IdSucursal;
            dbPrima.Inversion = request.Inversion;
            dbPrima.Cantidad = request.Cantidad;

            _context.Entry(dbPrima).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return response;
        }
    }
}
