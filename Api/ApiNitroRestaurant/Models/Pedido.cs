using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            DetallePedidos = new HashSet<DetallePedido>();
        }

        public int IdPedido { get; set; }
        public int IdEmpleado { get; set; }
        public string NumeroMesa { get; set; } = null!;
        public DateTime FechaHora { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}
