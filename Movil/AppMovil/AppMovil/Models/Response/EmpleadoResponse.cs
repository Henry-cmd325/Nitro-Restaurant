using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovil.Models.Response
{
    public class EmpleadoResponse
    {
        public int IdEmpleado { get; set; }
        public int IdTipoEmpleado { get; set; }
        public int? IdCuenta { get; set; }
        public string Nombre { get; set; } 
        public string Paterno { get; set; } 
        public string Materno { get; set; } 
        public string Telefono { get; set; }
    }
}
