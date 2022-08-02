using ApiNitroRestaurant.Models;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public class OrderService : IOrderService
    {
        private readonly NitroRestaurantContext _context;
        public OrderService(NitroRestaurantContext context)
        {
            _context = context;
        }

        public ServerResponse<OrderResponse> DeleteOrder(int id)
        {
            ServerResponse<OrderResponse> response = new();

            var orderDb = _context.Pedidos.Where(p => p.IdPedido == id).FirstOrDefault();

            if (orderDb == null)
            {
                response.Error = "No existe ningun pedido con el id introducido";
                response.Success = false;

                return response;
            }

            while (_context.DetallePedidos.Where(d => d.IdPedido == orderDb.IdPedido).FirstOrDefault() != null)
            {
                var detailDb = _context.DetallePedidos.Where(d => d.IdPedido == orderDb.IdPedido).FirstOrDefault();

                if (detailDb != null) _context.DetallePedidos.Remove(detailDb);

                _context.SaveChanges();
            }

            _context.Pedidos.Remove(orderDb);
            _context.SaveChanges();

            return response;
        }

        public ServerResponse<List<OrderResponse>> GetAllOrders()
        {
            ServerResponse<List<OrderResponse>> serverResponse = new();

            var listResponse = new List<OrderResponse>();

            var listDb = _context.Pedidos.ToList();

            if (listDb.Count == 0)
            {
                serverResponse.Error = "No existe ninguna orden en la base de datos";
                serverResponse.Success = false;

                return serverResponse;
            }

            

            foreach (var order in listDb)
            {
                var detallesDb = _context.DetallePedidos.ToList();

                List<DetalleResponse> detallesResponse = new();

                foreach (var detalle in detallesDb)
                {
                    detallesResponse.Add(new DetalleResponse()
                    {
                        IdDetallePedido = order.IdPedido,
                        IdProducto = detalle.IdProducto,
                        Cantidad = detalle.Cantidad
                    });
                }

                bool? terminado = null;

                if (order.Terminado != null)
                {
                    if (order.Terminado == 1)
                        terminado = true;
                    else
                        terminado = false;
                }

                listResponse.Add(new OrderResponse()
                {
                    IdPedido = order.IdPedido,
                    IdEmpleado = order.IdEmpleado,
                    NumeroMesa = order.NumeroMesa,
                    Anio = order.FechaHora.Year,
                    Mes = order.FechaHora.Month,
                    Dia = order.FechaHora.Day, 
                    Hora = order.FechaHora.Hour,
                    Minuto = order.FechaHora.Minute, 
                    Segundo = order.FechaHora.Second,
                    DetallesPedidos = detallesResponse,
                    Terminado = terminado
                });
            }

            serverResponse.Data = listResponse;

            return serverResponse;
        }

        public ServerResponse<OrderResponse> GetOrder(int id)
        {
            ServerResponse<OrderResponse> response = new();

            var orderDb = _context.Pedidos.Where(p => p.IdPedido == id).FirstOrDefault();

            if (orderDb == null)
            {
                response.Error = "No existe ningun pedido con el id introducido";
                response.Success = false;

                return response;
            }

            var detallesDb = _context.DetallePedidos.ToList();

            if (detallesDb == null)
            {
                response.Error = "No hay ningun detalle del pedido";
                response.Success = false;

                return response;
            }

            var listDetalles = new List<DetalleResponse>();

            foreach(var detalle in detallesDb)
            {
                if (detalle.IdPedido == id)
                {
                    listDetalles.Add(new DetalleResponse()
                    {
                        IdDetallePedido = detalle.IdDetalle,
                        IdProducto = detalle.IdProducto,
                        Cantidad = detalle.Cantidad
                    });
                }
            }

            bool? terminado = null;

            if (orderDb.Terminado != null)
            {
                if (orderDb.Terminado == 1)
                    terminado = true;
                else
                    terminado = false;
            }

            response.Data = new OrderResponse()
            {
                IdEmpleado = orderDb.IdEmpleado,
                IdPedido = orderDb.IdPedido,
                NumeroMesa = orderDb.NumeroMesa,
                Anio = orderDb.FechaHora.Year,
                Mes = orderDb.FechaHora.Month,
                Dia = orderDb.FechaHora.Day,
                Hora = orderDb.FechaHora.Hour, 
                Minuto = orderDb.FechaHora.Minute, 
                Segundo = orderDb.FechaHora.Second,
                DetallesPedidos = listDetalles,
                Terminado = terminado
            };

            return response;
        }

        public ServerResponse<OrderResponse> PostOrder(OrderRequest model)
        {
            ServerResponse<OrderResponse> response = new();

            var empleadoDb = _context.Empleados.Where(e => e.IdEmpleado == model.IdEmpleado).FirstOrDefault();

            if (empleadoDb == null)
            {
                response.Success = false;
                response.Error = "No existe ningun empleado con el id introducido";

                return response;
            }

            foreach (var detalle in model.DetallesPedidos)
            {
                var productoDb = _context.Productos.Where(p => p.IdProducto == detalle.IdProducto).FirstOrDefault();

                if (productoDb == null)
                {
                    response.Success = false;
                    response.Error = "No existe ningun producto con el id introducido (" + detalle.IdProducto + ")";

                    return response;
                }
            }

            DateTime fechaHora;

            try
            {
                fechaHora = new DateTime(model.Anio, model.Mes, model.Dia, model.Hora, model.Minuto, model.Segundo);
            }
            catch (Exception ex)
            {
                response.Error = "La fecha dada no puede ser representada en el objeto DateTime";
                response.Success = false;

                return response;
            }

            var orderDb = new Pedido()
            {
                IdEmpleado = model.IdEmpleado,
                NumeroMesa = model.NumeroMesa,
                FechaHora = fechaHora,
            };

            _context.Pedidos.Add(orderDb);
            _context.SaveChanges();

            var listDetalleResponse = new List<DetalleResponse>();

            foreach(var detalle in model.DetallesPedidos)
            {
                var detalleDb = new DetallePedido()
                {
                    IdPedido = orderDb.IdPedido,
                    IdProducto = detalle.IdProducto,
                    Cantidad = detalle.Cantidad
                };

                _context.DetallePedidos.Add(detalleDb);

                _context.SaveChanges();

                listDetalleResponse.Add(new DetalleResponse()
                {
                    IdDetallePedido = detalleDb.IdDetalle,
                    IdProducto = detalleDb.IdProducto,
                    Cantidad = detalle.Cantidad
                });
            }

            var orderResponse = new OrderResponse()
            {
                IdPedido = orderDb.IdPedido,
                IdEmpleado = orderDb.IdEmpleado,
                NumeroMesa = orderDb.NumeroMesa,
                Anio = model.Anio,
                Mes = model.Mes,
                Dia = model.Dia,
                Hora = model.Hora,
                Minuto = model.Minuto,
                Segundo = model.Segundo,
                DetallesPedidos = listDetalleResponse,
                Terminado = model.Terminado
            };
            
            response.Data = orderResponse;

            return response;
        }

        public ServerResponse<OrderResponse> UpdateOrder(int id, OrderRequest model)
        {
            ServerResponse<OrderResponse> response = new();

            var orderDb = _context.Pedidos.Where(p => p.IdPedido == id).FirstOrDefault();

            if (orderDb == null)
            {
                response.Error = "El id introducido no coincide con el id de ningun pedido";
                response.Success = false;

                return response;
            }

            var empleadoDb = _context.Empleados.Where(e => e.IdEmpleado == model.IdEmpleado).FirstOrDefault();

            if (empleadoDb == null)
            {
                response.Success = false;
                response.Error = "No existe ningun empleado con el id introducido";

                return response;
            }

            while (_context.DetallePedidos.Where(d => d.IdPedido == orderDb.IdPedido).FirstOrDefault() != null)
            {
                var detailDb = _context.DetallePedidos.Where(d => d.IdPedido == orderDb.IdPedido).FirstOrDefault();

                if (detailDb != null) _context.DetallePedidos.Remove(detailDb);

                _context.SaveChanges();
            }

            foreach (var detalle in model.DetallesPedidos)
            {
                var productoDb = _context.Productos.Where(p => p.IdProducto == detalle.IdProducto).FirstOrDefault();

                if (productoDb == null)
                {
                    response.Success = false;
                    response.Error = "No existe ningun producto con el id introducido (" + detalle.IdProducto + ")";

                    return response;
                }
            }

            DateTime fechaHora;

            try
            {
                fechaHora = new DateTime(model.Anio, model.Mes, model.Dia, model.Hora, model.Minuto, model.Segundo);
            }
            catch (Exception ex)
            {
                response.Error = "La fecha y hora dadas no se pueden convertir a DateTime";
                response.Success = false;

                return response;
            }

            orderDb.IdEmpleado = model.IdEmpleado;
            orderDb.NumeroMesa = model.NumeroMesa;
            orderDb.FechaHora = fechaHora;

            _context.Entry(orderDb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            var listDetalleResponse = new List<DetalleResponse>();

            foreach (var detalle in model.DetallesPedidos)
            {
                var detalleDb = new DetallePedido()
                {
                    IdPedido = orderDb.IdPedido,
                    IdProducto = detalle.IdProducto,
                    Cantidad = detalle.Cantidad
                };

                _context.DetallePedidos.Add(detalleDb);

                _context.SaveChanges();

                listDetalleResponse.Add(new DetalleResponse()
                {
                    IdDetallePedido = detalleDb.IdDetalle,
                    IdProducto = detalleDb.IdProducto,
                    Cantidad = detalle.Cantidad
                });
            }

            response.Data = new OrderResponse()
            {
                IdPedido = orderDb.IdPedido,
                IdEmpleado = orderDb.IdEmpleado,
                NumeroMesa = orderDb.NumeroMesa,
                Anio = model.Anio,
                Mes = model.Mes,
                Dia = model.Dia,
                Hora = model.Hora,
                Minuto = model.Minuto,
                Segundo = model.Segundo,
                DetallesPedidos = listDetalleResponse,
                Terminado = model.Terminado,
            };

            return response;
        }
    }
}
