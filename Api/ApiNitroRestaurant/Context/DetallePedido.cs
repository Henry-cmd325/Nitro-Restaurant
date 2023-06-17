using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Context
{
    public partial class DetallePedido
    {
        public int IdDetalle { get; set; }
        public int IdProducto { get; set; }
        public int IdPedido { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
