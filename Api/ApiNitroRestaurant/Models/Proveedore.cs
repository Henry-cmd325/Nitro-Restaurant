using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Models
{
    public partial class Proveedore
    {
        public Proveedore()
        {
            Entrada = new HashSet<Entrada>();
        }

        public int IdProveedor { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Entrada> Entrada { get; set; }
    }
}
