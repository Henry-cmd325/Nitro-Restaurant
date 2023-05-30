using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Context
{
    public partial class Sucursale
    {
        public Sucursale()
        {
            Categoria = new HashSet<Categoria>();
            Empleados = new HashSet<Empleado>();
            Entrada = new HashSet<Entrada>();
            Mesas = new HashSet<Mesa>();
            Pedidos = new HashSet<Pedido>();
            Productos = new HashSet<Producto>();
        }

        public int IdSucursal { get; set; }
        public string Nombre { get; set; } = null!;
        public string NumMesas { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;

        public virtual ICollection<Categoria> Categoria { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<Entrada> Entrada { get; set; }
        public virtual ICollection<Mesa> Mesas { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
