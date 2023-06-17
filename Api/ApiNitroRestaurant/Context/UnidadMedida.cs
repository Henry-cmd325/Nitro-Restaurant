using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Context
{
    public partial class UnidadMedida
    {
        public UnidadMedida()
        {
            Primas = new HashSet<Prima>();
            Productos = new HashSet<Producto>();
        }

        public int IdUm { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Prima> Primas { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
