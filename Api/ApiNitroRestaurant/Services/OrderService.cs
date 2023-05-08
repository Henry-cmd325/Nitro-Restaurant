using ApiNitroRestaurant.Models;
using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Models.Response;

namespace ApiNitroRestaurant.Services
{
    public class OrderService : IOrderService
    {
        private readonly db_nitrorestaurantContext _context;
        public OrderService(db_nitrorestaurantContext context)
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

                if (detailDb != null)
                {
                    var product = _context.Productos.Where(p => p.IdProducto == detailDb.IdProducto).First();
                    if (product.Contable == 1)
                    {
                        product.Cantidad += detailDb.Cantidad;
                        _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }

                    _context.DetallePedidos.Remove(detailDb);
                }

                _context.SaveChanges();
            }

            _context.Pedidos.Remove(orderDb);
            _context.SaveChanges();

            return response;
        }

        public ServerResponse<List<OrderResponse>> GetAllOrders(string empleado)
        {
            ServerResponse<List<OrderResponse>> serverResponse = new();

            var listResponse = new List<OrderResponse>();

            var employee = _context.Empleados.Where(e => e.Usuario == empleado).First();

            var listDb = _context.Pedidos.Where(p => p.IdSucursal == employee.IdSucursal).ToList();

            foreach (var order in listDb)
            {
                var detallesDb = _context.DetallePedidos.ToList();

                List<DetalleResponse> detallesResponse = new();

                foreach (var detalle in detallesDb)
                {
                    if (detalle.IdPedido == order.IdPedido)
                    {
                        detallesResponse.Add(new DetalleResponse()
                        {
                            IdDetallePedido = order.IdPedido,
                            IdProducto = detalle.IdProducto,
                            Cantidad = detalle.Cantidad
                        });
                    }
                }

                bool? terminado = null;

                if (order.Terminado != null) terminado = order.Terminado == 1;

                var dbEmployee = _context.Empleados.Where(e => e.IdEmpleado == order.IdEmpleado).First();
                var dbTable = _context.Mesas.Where(m => m.IdMesa == order.IdMesa).First();
                var dbTipo = _context.TipoPedidos.Where(t => t.IdTipoPedido == order.IdTipoPedido).First();

                listResponse.Add(new OrderResponse()
                {
                    IdPedido = order.IdPedido,
                    Empleado = dbEmployee.Nombre,
                    Anio = order.FechaHora.Year,
                    Mes = order.FechaHora.Month,
                    Dia = order.FechaHora.Day, 
                    Hora = order.FechaHora.Hour,
                    Minuto = order.FechaHora.Minute, 
                    Segundo = order.FechaHora.Second,
                    DetallesPedidos = detallesResponse,
                    Comentario = order.Comentario,
                    Terminado = terminado,
                    TipoPedido = dbTipo.Nombre,
                    Mesa = dbTable.NumMesa
                });
            }
            serverResponse.Data = listResponse;

            return serverResponse;
        }

        public ServerResponse<List<OrderResponse>> GetAllOrders()
        {
            ServerResponse<List<OrderResponse>> serverResponse = new();

            var listResponse = new List<OrderResponse>();

            var listDb = _context.Pedidos.ToList();

            foreach (var order in listDb)
            {
                var detallesDb = _context.DetallePedidos.ToList();

                List<DetalleResponse> detallesResponse = new();

                foreach (var detalle in detallesDb)
                {
                    if (detalle.IdPedido == order.IdPedido)
                    {
                        detallesResponse.Add(new DetalleResponse()
                        {
                            IdDetallePedido = order.IdPedido,
                            IdProducto = detalle.IdProducto,
                            Cantidad = detalle.Cantidad
                        });
                    }
                }

                bool? terminado = null;

                if (order.Terminado != null) terminado = order.Terminado == 1;

                var dbEmployee = _context.Empleados.Where(e => e.IdEmpleado == order.IdEmpleado).First();
                var dbTable = _context.Mesas.Where(m => m.IdMesa == order.IdMesa).First();
                var dbTipo = _context.TipoPedidos.Where(t => t.IdTipoPedido == order.IdTipoPedido).First();

                listResponse.Add(new OrderResponse()
                {
                    IdPedido = order.IdPedido,
                    Empleado = dbEmployee.Nombre,
                    Anio = order.FechaHora.Year,
                    Mes = order.FechaHora.Month,
                    Dia = order.FechaHora.Day,
                    Hora = order.FechaHora.Hour,
                    Minuto = order.FechaHora.Minute,
                    Segundo = order.FechaHora.Second,
                    DetallesPedidos = detallesResponse,
                    Comentario = order.Comentario,
                    Terminado = terminado,
                    TipoPedido = dbTipo.Nombre,
                    Mesa = dbTable.NumMesa
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

            if (orderDb.Terminado != null) terminado = orderDb.Terminado == 1;

            var dbEmployee = _context.Empleados.Where(e => e.IdEmpleado == orderDb.IdEmpleado).First();
            var dbMesa = _context.Mesas.Where(m => m.IdMesa == orderDb.IdMesa).First();
            var dbTipo = _context.TipoPedidos.Where(t => t.IdTipoPedido == orderDb.IdTipoPedido).First();

            response.Data = new OrderResponse()
            {
                Empleado = dbEmployee.Nombre,
                IdPedido = orderDb.IdPedido,
                Anio = orderDb.FechaHora.Year,
                Mes = orderDb.FechaHora.Month,
                Dia = orderDb.FechaHora.Day,
                Hora = orderDb.FechaHora.Hour, 
                Minuto = orderDb.FechaHora.Minute, 
                Segundo = orderDb.FechaHora.Second,
                Comentario = orderDb.Comentario,
                TipoPedido = dbTipo.Nombre,
                Mesa = dbMesa.NumMesa,
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

            var dbTable = _context.Mesas.Where(e => e.IdMesa == model.IdMesa).FirstOrDefault();
            if (dbTable == null)
            {
                response.Success = false;
                response.Error = "No existe ninguna mesa con el id introducido";

                return response;
            }

            var dbTipoPedido = _context.TipoPedidos.Where(e => e.IdTipoPedido == model.IdTipoPedido).FirstOrDefault();
            if (dbTipoPedido == null)
            {
                response.Success = false;
                response.Error = "No existe ningun tipo de pedido con el id introducido";

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
            catch
            {
                response.Error = "La fecha dada no puede ser representada en el objeto DateTime";
                response.Success = false;

                return response;
            }

            var orderDb = new Pedido()
            {
                IdEmpleado = model.IdEmpleado,
                FechaHora = fechaHora,
                Terminado = null,
                IdSucursal = model.IdSucursal,
                IdTipoPedido = model.IdTipoPedido,
                Comentario = model.Comentario,
                IdMesa = model.IdMesa
            };

            _context.Pedidos.Add(orderDb);

            var listDetalleResponse = new List<DetalleResponse>();
            var listProducts = new List<Producto>();

            foreach(var detalle in model.DetallesPedidos)
            {
                var dbProduct = _context.Productos.Where(p => p.IdProducto == detalle.IdProducto).First();
                if (dbProduct == null)
                {
                    response.Error = "El id introducido no hace referencia a ningun producto: " + detalle.IdProducto;
                    response.Success = false;

                    return response;
                }

                listProducts.Add(dbProduct);
            }

            _context.SaveChanges();

            foreach (var detalle in model.DetallesPedidos)
            {
                var dbProduct = listProducts.Where(p => p.IdProducto == detalle.IdProducto).First();

                var detalleDb = new DetallePedido()
                {
                    IdPedido = orderDb.IdPedido,
                    IdProducto = detalle.IdProducto,
                    Cantidad = detalle.Cantidad
                };

                if (dbProduct.Contable == 1)
                {
                    dbProduct.Cantidad -= detalle.Cantidad;
                    _context.Entry(dbProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

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
                Empleado = empleadoDb.Nombre,
                Mesa = dbTable.NumMesa,
                Anio = model.Anio,
                Mes = model.Mes,
                Dia = model.Dia,
                Hora = model.Hora,
                Minuto = model.Minuto,
                Segundo = model.Segundo,
                DetallesPedidos = listDetalleResponse,
                TipoPedido = dbTipoPedido.Nombre,
                Comentario = model.Comentario,
                Terminado = null
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

            var mesaDb = _context.Mesas.Where(m => m.IdMesa == model.IdMesa).FirstOrDefault();
            if (mesaDb == null)
            {
                response.Success = false;
                response.Error = "No existe ninguna mesa con el id introducido";

                return response;
            }

            var tipoDb = _context.TipoEmpleados.Where(t => t.IdTipoEmpleado == model.IdTipoPedido).FirstOrDefault();
            if (tipoDb == null)
            {
                response.Success = false;
                response.Error = "No existe nungun tipo con el id introducido";

                return response;
            }

            foreach (var detalle in model.DetallesPedidos)
            {
                var productoDb = _context.Productos.Where(p => p.IdProducto == detalle.IdProducto).FirstOrDefault();

                if (productoDb == null)
                {
                    response.Success = false;
                    response.Error = "No existe ningun producto con el id introducido";

                    return response;
                }
            }

            DateTime fechaHora;

            try
            {
                fechaHora = new DateTime(model.Anio, model.Mes, model.Dia, model.Hora, model.Minuto, model.Segundo);
            }
            catch
            {
                response.Error = "La fecha y hora dadas no se pueden convertir a DateTime";
                response.Success = false;

                return response;
            }

            while (_context.DetallePedidos.Where(d => d.IdPedido == orderDb.IdPedido).FirstOrDefault() != null)
            {
                var detailDb = _context.DetallePedidos.Where(d => d.IdPedido == orderDb.IdPedido).FirstOrDefault();

                if (detailDb != null)
                {
                    var dbProduct = _context.Productos.Where(p => p.IdProducto == detailDb.IdProducto).First();
                    if (dbProduct.Contable == 1)
                    {
                        dbProduct.Cantidad -= detailDb.Cantidad;
                        _context.Entry(dbProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }

                    _context.DetallePedidos.Remove(detailDb);
                }

                _context.SaveChanges();
            }

            orderDb.IdEmpleado = model.IdEmpleado;
            orderDb.FechaHora = fechaHora;
            orderDb.Comentario = model.Comentario;
            orderDb.IdMesa = model.IdMesa;
            orderDb.IdTipoPedido = model.IdTipoPedido;

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
            }

            return response;
        }

        public ServerResponse<OrderResponse> UpdateState(int id, OrderStateRequest model)
        {
            ServerResponse<OrderResponse> response = new();

            var pedidoDb = _context.Pedidos.Where(p => p.IdPedido == id).FirstOrDefault();

            if (pedidoDb == null)
            {
                response.Error = "El id introducido no corresponde con ningun registro de pedido";
                response.Success = false;

                return response;
            }

            if (model.Terminado == null)
                pedidoDb.Terminado = null;
            else
                pedidoDb.Terminado = (ulong)((bool)(model.Terminado) ? 1 : 0);

            _context.Entry(pedidoDb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return response;
        }
    }
}
