using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorio
{
    internal class Usuarios
    {

        public string Nombre { get; set; } = null!;
        public string Paterno { get; set; } = null!;
        public string Materno { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public AccountRequest Cuenta { get; set; } = null!;
        public TipoEmpleadoRequest TipoEmpleado { get; set; } = null!;
    }

    class AccountRequest
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }

    class TipoEmpleadoRequest
    {
        public string Nombre { get; set; } = null!;
        
    }
}
