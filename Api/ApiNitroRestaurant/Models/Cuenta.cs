using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Models
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int IdCuenta { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
