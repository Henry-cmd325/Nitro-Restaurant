using AppEscritorio.Pages;
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
            usuario.Nombre = usuario.Nombre.Trim();
            usuario.Paterno = usuario.Paterno.Trim();
            usuario.Materno = usuario.Materno.Trim();
            usuario.Telefono = usuario.Telefono.Trim();
            usuario.Cuenta.Username = usuario.Cuenta.Username.Trim();
            usuario.Cuenta.Password = usuario.Cuenta.Password.Trim();

            if (usuario.Nombre == "" || usuario.Paterno == "" || usuario.Materno == "" ||
                usuario.Telefono == "" || usuario.Cuenta.Username == "" || usuario.Cuenta.Password == "")
            {
                throw new Exception("Rellene todos los campos por favor :)");
            }

            if (usuario.Telefono.Length != 10)
            {
                throw new Exception("El numero de teléfono debe contener 10 caracteres");
            }
            try
            {
                Int64.Parse(usuario.Telefono);
            }
            catch (Exception)
            {
                throw new Exception("Introduzca solo caracteres numéricos en el telefono");
            }

            if (usuario.Cuenta.Password.Length < 8)
            {
                throw new Exception("La contraseña debe ser de al menos 12 carácteres");
            }
            
            
            
            
        }

        public static void ValidarProducto(string inversion, string precio)
        {
            try
            {
                float.Parse(inversion);
            }
            catch (Exception)
            {
                throw new Exception("Introduzca un valor númerico en la inversión por favor");
            }

            try
            {
                float.Parse(precio);
            }
            catch (Exception)
            {
                throw new Exception("Introduzca un valor númerico en el precio por favor");
            }
        }

        
    }
}
