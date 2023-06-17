using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Context
{
    public partial class PrimasProducto
    {
        public int IdPrima { get; set; }
        public int IdProduto { get; set; }
        public int CantidadPrima { get; set; }

        public virtual Prima IdPrimaNavigation { get; set; } = null!;
        public virtual Producto IdProdutoNavigation { get; set; } = null!;
    }
}
