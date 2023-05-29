using ApiNitroRestaurant.Context;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public class EntranceService : IEntranceService
    {
        private readonly db_nitrorestaurantContext _context;
        public EntranceService(db_nitrorestaurantContext context)
        {
            _context = context;
        }
        public ServerResponse<bool> DeleteEntrance(int id)
        {
            ServerResponse<bool> response = new();

            var dbEntrance = _context.Entradas.Where(e => e.IdEntrada == id).FirstOrDefault();
            if (dbEntrance == null)
            {
                response.Success = false;
                response.Error = "El id introducido no corresponde con ninguna entrada";

                return response;
            }

            var dbProducto = _context.Productos.Where(p => p.IdProducto == dbEntrance.IdProducto).First();
            dbProducto.Cantidad -= dbEntrance.Cantidad;

            _context.Entry(dbProducto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.Remove(dbEntrance);

            response.Data = true;

            return response;
        }

        public ServerResponse<EntradaResponse> GetEntrance(int id)
        {
            ServerResponse<EntradaResponse> response = new();

            var dbEntrance = _context.Entradas.Where(e => e.IdEntrada == id).FirstOrDefault();

            if (dbEntrance == null)
            {
                response.Success = false;
                response.Error = "El id introducido no corresponde con ninguna entrada";

                return response;
            }

            var dbProduct = _context.Productos.Where(p => p.IdProducto == dbEntrance.IdProducto).First();
            var dbProveedor = _context.Proveedores.Where(p => p.IdProveedor == dbEntrance.IdProveedor).FirstOrDefault();

            response.Data = new()
            {
                IdEntrada = dbEntrance.IdEntrada,
                Producto = dbProduct.Nombre,
                Proveedor = dbProveedor!.Nombre,
                Cantidad = dbEntrance.Cantidad,
                Anio = dbEntrance.FechaHora.Year,
                Mes = dbEntrance.FechaHora.Minute,
                Dia = dbEntrance.FechaHora.Day,
                Hora = dbEntrance.FechaHora.Hour,
                Minuto = dbEntrance.FechaHora.Minute,
                Segundo = dbEntrance.FechaHora.Second
            };

            return response;
        }

        public ServerResponse<List<EntradaResponse>> GetEntrances(string empleado)
        {
            ServerResponse<List<EntradaResponse>> response = new();

            var dbEmpleado = _context.Empleados.Where(e => e.Usuario == empleado).First();
            var dbEntradas = _context.Entradas.Where(e => e.IdSucursal == dbEmpleado.IdSucursal).ToList();

            foreach(var dbEntrada in dbEntradas)
            {
                var dbProducto = _context.Productos.Where(e => e.IdProducto == dbEntrada.IdProducto).First();
                var dbProveedor = _context.Proveedores.Where(p => p.IdProveedor == dbEntrada.IdProveedor).First();

                response.Data.Add(new()
                {
                    IdEntrada = dbEntrada.IdEntrada,
                    Producto = dbProducto.Nombre,
                    Proveedor = dbProveedor.Nombre,
                    Cantidad = dbEntrada.Cantidad,
                    Anio = dbEntrada.FechaHora.Year,
                    Mes = dbEntrada.FechaHora.Month,
                    Dia = dbEntrada.FechaHora.Day,
                    Hora = dbEntrada.FechaHora.Hour,
                    Minuto = dbEntrada.FechaHora.Minute,
                    Segundo = dbEntrada.FechaHora.Second
                }) ;
            }

            return response;
        }

        public ServerResponse<EntradaResponse> PostEntrance(EntradaRequest request)
        {
            ServerResponse<EntradaResponse> response = new();

            DateTime fechahora;
            try
            {
                fechahora = new(request.Anio, request.Mes, request.Dia, request.Hora, request.Minuto, request.Segundo);
            }
            catch
            {
                response.Success = false;
                response.Error = "La fecha y hora introducidas no son validas";

                return response;
            }

            var dbProduct = _context.Productos.Where(p => p.IdProducto == request.IdProducto).First();
            if (dbProduct == null)
            {
                response.Success = false;
                response.Error = "El id introducido no corresponde con ningun producto";

                return response;
            }

            var dbProveedor = _context.Proveedores.Where(p => p.IdProveedor == request.IdProveedor).FirstOrDefault();
            if (dbProveedor == null)
            {
                response.Success = false;
                response.Error = "El id introducido no corresponde con ningun proveedor";

                return response;
            }

            var newEntrada = new Entrada()
            {
                IdProducto = request.IdProducto,
                IdProveedor = request.IdProveedor,
                IdSucursal = request.IdSucursal,
                Cantidad = request.Cantidad,
                FechaHora = fechahora
            };

            dbProduct.Cantidad += request.Cantidad;

            _context.Entry(dbProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.Entradas.Add(newEntrada);
            _context.SaveChanges();

            response.Data = new()
            {
                IdEntrada = newEntrada.IdEntrada,
                Producto = dbProduct.Nombre,
                Proveedor = dbProveedor!.Nombre,
                Cantidad = newEntrada.Cantidad,
                Anio = newEntrada.FechaHora.Year,
                Mes = newEntrada.FechaHora.Minute,
                Dia = newEntrada.FechaHora.Day,
                Hora = newEntrada.FechaHora.Hour,
                Minuto = newEntrada.FechaHora.Minute,
                Segundo = newEntrada.FechaHora.Second
            };

            return response;
        }

        public ServerResponse<EntradaResponse> PutEntrance(int id, EntradaRequest request)
        {
            ServerResponse<EntradaResponse> response = new();

            var dbEntrance = _context.Entradas.Where(e => e.IdEntrada == id).FirstOrDefault();
            if (dbEntrance == null)
            {
                response.Success = false;
                response.Error = "El id introducido no corresponde con ningun registro";

                return response;
            }

            DateTime dateTime;
            try
            {
                dateTime = new(request.Anio, request.Mes, request.Dia, request.Hora, request.Minuto, request.Segundo);
            }
            catch
            {
                response.Success = false;
                response.Error = "La fecha y hora introducidas no son válidas";

                return response;
            }

            var dbProducto = _context.Productos.Where(p => p.IdProducto == request.IdProducto).FirstOrDefault();
            if (dbProducto == null)
            {
                response.Success = false;
                response.Error = "El id introducido no corresponde con ningun producto";

                return response;
            }

            var dbProveedor = _context.Proveedores.Where(p => p.IdProveedor == request.IdProveedor).FirstOrDefault();
            if (dbProveedor == null)
            {
                response.Success = false;
                response.Error = "El id introducido no corresponde con ningun proveedor";

                return response;
            }

            dbProducto.Cantidad = dbProducto.Cantidad - dbEntrance.Cantidad + request.Cantidad; 

            dbEntrance.IdProducto = request.IdProducto;
            dbEntrance.IdProveedor = request.IdProveedor;
            dbEntrance.IdSucursal = request.IdSucursal;
            dbEntrance.Cantidad = request.Cantidad;
            dbEntrance.FechaHora = dateTime;

            _context.Entry(dbProducto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.Entry(dbEntrance).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return response;
        }
    }
}
