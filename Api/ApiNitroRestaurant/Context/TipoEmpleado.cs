using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Context
{
    public partial class TipoEmpleado
    {
        public TipoEmpleado()
        {
            Empleados = new HashSet<Empleado>();
            TipoeOperaciones = new HashSet<TipoeOperacione>();
        }

        public int IdTipoEmpleado { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<TipoeOperacione> TipoeOperaciones { get; set; }
    }
}
