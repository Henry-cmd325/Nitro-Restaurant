using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetallePedidos = new HashSet<DetallePedido>();
            Entrada = new HashSet<Entrada>();
        }

        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Inversion { get; set; }
        public decimal Precio { get; set; }
        public ulong Contable { get; set; }
        public string? ImgUrl { get; set; }
        public int Cantidad { get; set; }
        public int IdUm { get; set; }
        public int IdSucursal { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; } = null!;
        public virtual Sucursale IdSucursalNavigation { get; set; } = null!;
        public virtual UnidadMedida IdUmNavigation { get; set; } = null!;
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
        public virtual ICollection<Entrada> Entrada { get; set; }
    }
}
