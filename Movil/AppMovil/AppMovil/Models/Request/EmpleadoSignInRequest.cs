using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovil.Models.Request
{
    public class EmpleadoSignInRequest
    {
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Telefono { get; set; }
        public TipoEmpleadoRequest TipoEmpleado { get; set; } = new TipoEmpleadoRequest()
        {
            Nombre = "Mesero"
        };
    }
}
