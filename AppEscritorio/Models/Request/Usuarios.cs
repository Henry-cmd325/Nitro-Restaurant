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
        int id_tipo;
        string conPassword;
        string nombre;
        string paterno;
        string materno;
        string telefono;

        

  
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
        string nombre;
    }
}
