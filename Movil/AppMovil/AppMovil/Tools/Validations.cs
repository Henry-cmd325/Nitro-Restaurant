using AppMovil.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovil.Tools
{
    public static class Validations
    {
        public static void ValidarLogin(EmpleadoAuthRequest empleado, string connString)
        {
            empleado.Telefono = empleado.Telefono.Trim();
            connString = connString.Trim();

            if (empleado.Telefono == "" || connString == "")
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
            catch
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
            catch
            {
                throw new Exception("Introduzca solo caracteres numéricos en el telefono");
            }
        }

        public static void ValidarCrearPedido(OrderRequest order)
        {
            order.NumeroMesa = order.NumeroMesa.Trim();

            if (order.NumeroMesa == "")
            {
                throw new Exception("Debe de rellenar el campo numero mesa");
            }

            try
            {
                Int64.Parse(order.NumeroMesa);
            }
            catch
            {
                throw new Exception("Debe de introducir un número");
            }

            if (order.NumeroMesa.Length > 2)
            {
                throw new Exception("El valor introducido es muy grande");
            }
        }
    }
}
