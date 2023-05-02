using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Models
{
    public partial class Mesa
    {
        public Mesa()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdSucursal { get; set; }
        public int? IdEmpleado { get; set; }
        public int IdMesa { get; set; }
        public string NumMesa { get; set; } = null!;

        public virtual Empleado? IdEmpleadoNavigation { get; set; }
        public virtual Sucursale IdSucursalNavigation { get; set; } = null!;
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
