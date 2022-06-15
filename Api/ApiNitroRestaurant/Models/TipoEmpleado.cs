using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Models
{
    public partial class TipoEmpleado
    {
        public TipoEmpleado()
        {
            Empleados = new HashSet<Empleado>();
            TipoOperaciones = new HashSet<TipoOperacione>();
        }

        public int IdTipoEmpleado { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<TipoOperacione> TipoOperaciones { get; set; }
    }
}
