using System.Collections.Generic;

namespace AppEscritorio.Models.Request
{
    public class OrderRequest
    {
        public int IdEmpleado { get; set; }
        public int IdTipoPedido { get; set; }
        public int IdSucursal { get; set; }
        public string Comentario { get; set; } = null!;
        public int IdMesa { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public int Segundo { get; set; }
        public List<DetalleRequest> DetallesPedidos { get; set; } = null!;
    }
}
