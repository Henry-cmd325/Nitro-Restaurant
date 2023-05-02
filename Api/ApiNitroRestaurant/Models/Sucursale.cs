using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Models
{
    public partial class Sucursale
    {
        public Sucursale()
        {
            Empleados = new HashSet<Empleado>();
            Mesas = new HashSet<Mesa>();
            Pedidos = new HashSet<Pedido>();
            Productos = new HashSet<Producto>();
        }

        public int IdSucursal { get; set; }
        public string Nombre { get; set; } = null!;
        public string NumMesas { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<Mesa> Mesas { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
