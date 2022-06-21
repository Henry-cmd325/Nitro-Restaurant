using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorio.Models.Response
{
    internal class UsuarioResponse
    {
        public int IdEmpleado { get; set; }
        public int ITipoEmpleado { get; set; } 
        public int? IdCuenta { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Telefono { get; set; }
    }
}
