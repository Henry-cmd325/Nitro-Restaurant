using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Models
{
    public partial class Entrada
    {
        public int IdEntrada { get; set; }
        public int IdProducto { get; set; }
        public int? IdProveedor { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaHora { get; set; }

        public virtual Producto IdProductoNavigation { get; set; } = null!;
        public virtual Proveedore? IdProveedorNavigation { get; set; }
    }
}
