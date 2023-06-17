using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Context
{
    public partial class TiposCobro
    {
        public TiposCobro()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdTipoCobro { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
