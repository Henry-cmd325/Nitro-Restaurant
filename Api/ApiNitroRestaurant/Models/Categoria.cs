using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = null!;
        public string? ImgUrl { get; set; }
        public int IdSucursal { get; set; }

        public virtual Sucursale IdSucursalNavigation { get; set; } = null!;
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
