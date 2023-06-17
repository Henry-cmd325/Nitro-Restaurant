﻿using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Context
{
    public partial class Pedido
    {
        public Pedido()
        {
            DetallePedidos = new HashSet<DetallePedido>();
        }

        public int IdPedido { get; set; }
        public int IdEmpleado { get; set; }
        public int IdSucursal { get; set; }
        public int IdTipoPedido { get; set; }
        public DateTime FechaHora { get; set; }
        public ulong? Terminado { get; set; }
        public string Comentario { get; set; } = null!;
        public int IdMesa { get; set; }
        public ulong Cobrado { get; set; }
        public decimal Propina { get; set; }
        public int? IdTipoCobro { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
        public virtual Mesa IdMesaNavigation { get; set; } = null!;
        public virtual Sucursale IdSucursalNavigation { get; set; } = null!;
        public virtual TiposCobro? IdTipoCobroNavigation { get; set; }
        public virtual TipoPedido IdTipoPedidoNavigation { get; set; } = null!;
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}
