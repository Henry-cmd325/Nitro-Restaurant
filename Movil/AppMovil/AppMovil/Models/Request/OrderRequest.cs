using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovil.Models.Request
{
    public class OrderRequest
    {
        public int IdEmpleado { get; set; }
        public string NumeroMesa { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public int Segundo { get; set; }
        public List<DetalleRequest> DetallesPedidos { get; set; }
        public bool? Terminado { get; set; }
    }
}
