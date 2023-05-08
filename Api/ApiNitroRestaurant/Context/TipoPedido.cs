using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Context
{
    public partial class TipoPedido
    {
        public TipoPedido()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdTipoPedido { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
