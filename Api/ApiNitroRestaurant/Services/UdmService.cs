using ApiNitroRestaurant.Context;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public class UdmService : IUdmService
    {
        private readonly db_nitrorestaurantContext _context;
        public UdmService(db_nitrorestaurantContext context)
        {
            _context = context;
        }
        public ServerResponse<UdmResponse> GetUdm(int id)
        {
            ServerResponse<UdmResponse> response = new();

            var udmDb = _context.UnidadMedidas.Where(u => u.IdUm == id).FirstOrDefault();
            if (udmDb == null)
            {
                response.Success = false;
                response.Error = "El id introducido no corresponde con ningun registro";

                return response;
            }

            response.Data = new()
            {
                IdUdm = id,
                Nombre = udmDb.Nombre
            };

            return response;
        }

        public ServerResponse<List<UdmResponse>> GetUdms()
        {
            ServerResponse<List<UdmResponse>> response = new();
            response.Data = new();

            var udmsDb = _context.UnidadMedidas.ToList();
            foreach (var udm in udmsDb)
            {
                response.Data.Add(new()
                {
                    IdUdm = udm.IdUm,
                    Nombre = udm.Nombre
                });
            }

            return response;
        }

        public ServerResponse<UdmResponse> PostUdm(UdmRequest request)
        {
            ServerResponse<UdmResponse> response = new();

            var udmDb = _context.UnidadMedidas.Where(u => u.Nombre == request.Nombre).FirstOrDefault();
            if (udmDb != null)
            {
                response.Success = false;
                response.Error = "La unidad de medida que quieres agregar ya existe";

                return response;
            }

            var newUdm = new UnidadMedida() { Nombre = request.Nombre };

            _context.UnidadMedidas.Add(newUdm);
            _context.SaveChanges();

            response.Data = new()
            {
                IdUdm = newUdm.IdUm,
                Nombre = newUdm.Nombre
            };

            return response;
        }

        public ServerResponse<UdmResponse> PutUdm(int id, UdmRequest request)
        {
            ServerResponse<UdmResponse> response = new();

            var udmDb = _context.UnidadMedidas.Where(u => u.IdUm == id).FirstOrDefault();
            if (udmDb == null)
            {
                response.Success = false;
                response.Error = "El id introducido no corresponde con ningun registro";

                return response;
            }

            udmDb.Nombre = request.Nombre;
            _context.Entry(udmDb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return response;
        }
    }
}
