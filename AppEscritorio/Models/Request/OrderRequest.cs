using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorio.Models.Request
{
    internal class OrderRequest
    {
        public int IdEmpleado { get; set; }
        public string NumeroMesa { get; set; } = null!;
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public int Segundo { get; set; }
        public List<DetalleRequest> DetallesPedidos { get; set; } = null!;
        public bool? Terminado { get; set; }
    }
}
