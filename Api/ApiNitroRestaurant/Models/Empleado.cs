using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdEmpleado { get; set; }
        public int IdTipoEmpleado { get; set; }
        public int? IdCuenta { get; set; }
        public string Nombre { get; set; } = null!;
        public string Paterno { get; set; } = null!;
        public string Materno { get; set; } = null!;
        public string Telefono { get; set; } = null!;

        public virtual Cuenta? IdCuentaNavigation { get; set; }
        public virtual TipoEmpleado IdTipoEmpleadoNavigation { get; set; } = null!;
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
