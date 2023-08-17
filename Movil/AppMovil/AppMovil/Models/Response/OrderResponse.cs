using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovil.Models.Response
{
    public class OrderResponse
    {
        public int IdPedido { get; set; }
        public int IdEmpleado { get; set; }
        public string NumeroMesa { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public int Segundo { get; set; }
        public List<DetalleResponse> DetallesPedidos { get; set; }
        public bool? Terminado { get; set; }
    }

    public class DetalleResponse
    {
        public int IdDetallePedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
