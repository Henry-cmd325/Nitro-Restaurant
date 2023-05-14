using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Context
{
    public partial class Proveedore
    {
        public Proveedore()
        {
            Entrada = new HashSet<Entrada>();
        }

        public int IdProveedor { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Telefono2 { get; set; }
        public string Telefono1 { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? NumeroCuenta { get; set; }
        public string? Telefono3 { get; set; }

        public virtual ICollection<Entrada> Entrada { get; set; }
    }
}
