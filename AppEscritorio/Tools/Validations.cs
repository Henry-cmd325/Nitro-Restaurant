using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorio.Tools
{
    public static class Validations
    {
        public static void ValidarSignUp(Usuarios usuario)
        {
            if(usuario.Nombre == "" || usuario.Paterno == "" || usuario.Materno == "" || 
                usuario.Telefono == "" || usuario.Cuenta.Username == "" || usuario.Cuenta.Password == "")
            {
                throw new Exception("Rellene todos los campos por favor :)");
            }
            
            
            
        }
    }
}
