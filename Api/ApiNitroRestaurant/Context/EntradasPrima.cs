using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Context
{
    public partial class EntradasPrima
    {
        public int IdEntrada { get; set; }
        public int IdPrima { get; set; }
        public int IdProveedor { get; set; }
        public DateTime FechaHora { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public virtual Prima IdPrimaNavigation { get; set; } = null!;
        public virtual Proveedore IdProveedorNavigation { get; set; } = null!;
    }
}
