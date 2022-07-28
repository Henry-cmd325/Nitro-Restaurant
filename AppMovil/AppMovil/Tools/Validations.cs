using AppMovil.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovil.Tools
{
    public static class Validations
    {
        public static void ValidarLogin(EmpleadoAuthRequest empleado)
        {
            empleado.Telefono = empleado.Telefono.Trim();

            if (empleado.Telefono == "")
            {
                throw new Exception("No puede dejar el campo teléfono en blanco");
            }

            if (empleado.Telefono.Length != 10)
            {
                throw new Exception("El numero de teléfono debe contener 10 caracteres");
            }
            try
            {
                Int64.Parse(empleado.Telefono);
            }
            catch (Exception ex)
            {
                throw new Exception("Introduzca solo caracteres numéricos en el telefono");
            }
        }

        public static void ValidarSignin(EmpleadoSignInRequest empleado)
        {
            empleado.Telefono = empleado.Telefono.Trim();
            empleado.Materno = empleado.Materno.Trim();
            empleado.Paterno = empleado.Paterno.Trim();
            empleado.Nombre = empleado.Nombre.Trim();
     
            if (empleado.Telefono == "" || empleado.Materno == "" || empleado.Paterno == "" || empleado.Nombre == "")
            {
                throw new Exception("Debe de rellenar todos los campos");
            }

            if (empleado.Telefono.Length != 10)
            {
                throw new Exception("El numero de teléfono debe contener 10 caracteres");
            }
            try
            {
                Int64.Parse(empleado.Telefono);
            }
            catch (Exception ex)
            {
                throw new Exception("Introduzca solo caracteres numéricos en el telefono");
            }
        }
    }
}
