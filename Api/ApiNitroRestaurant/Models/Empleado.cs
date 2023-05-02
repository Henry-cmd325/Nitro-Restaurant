﻿using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Mesas = new HashSet<Mesa>();
            Pedidos = new HashSet<Pedido>();
        }

        public int IdEmpleado { get; set; }
        public int IdTipoEmpleado { get; set; }
        public int IdSucursal { get; set; }
        public string Nombre { get; set; } = null!;
        public string Paterno { get; set; } = null!;
        public string Materno { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Usuario { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public string? ContraseniaAnterior { get; set; }

        public virtual Sucursale IdSucursalNavigation { get; set; } = null!;
        public virtual TipoEmpleado IdTipoEmpleadoNavigation { get; set; } = null!;
        public virtual ICollection<Mesa> Mesas { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
