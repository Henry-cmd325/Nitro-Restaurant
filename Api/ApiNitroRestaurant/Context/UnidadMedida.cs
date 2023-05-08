using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Context
{
    public partial class UnidadMedida
    {
        public UnidadMedida()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdUm { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
