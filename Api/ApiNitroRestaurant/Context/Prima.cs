using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Context
{
    public partial class Prima
    {
        public Prima()
        {
            PrimasProductos = new HashSet<PrimasProducto>();
        }

        public int IdUm { get; set; }
        public int IdPrima { get; set; }
        public int IdSucursal { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Inversion { get; set; }
        public int Cantidad { get; set; }

        public virtual Sucursale IdSucursalNavigation { get; set; } = null!;
        public virtual UnidadMedida IdUmNavigation { get; set; } = null!;
        public virtual ICollection<PrimasProducto> PrimasProductos { get; set; }
    }
}
