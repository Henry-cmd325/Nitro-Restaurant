using AppEscritorio.Models.Request;
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
        public static void ValidarSignUp(EmpleadoRequest usuario)
        {
            usuario.Nombre = usuario.Nombre.Trim();
            usuario.Paterno = usuario.Paterno.Trim();
            usuario.Materno = usuario.Materno.Trim();
            usuario.Telefono = usuario.Telefono.Trim();
            usuario.Usuario = usuario.Usuario.Trim();
            usuario.Contrasenia = usuario.Contrasenia.Trim();

            if (usuario.Nombre == "" || usuario.Paterno == "" || usuario.Materno == "" ||
                usuario.Telefono == "" || usuario.Usuario == "" || usuario.Contrasenia == "")
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

            if (usuario.Contrasenia.Length < 8)
            {
                throw new Exception("La contraseña debe ser de al menos 12 carácteres");
            }
            
            
            
            
        }



        public static void ValidarAñadirProduct(string product, int index, string investment, string price)
        {
            if (product.Trim() == "")
            {
                throw new Exception("Debe escribir un nombre para el producto");
            }

            if (index == -1)
            {
                throw new Exception("Debe seleccionar una categoria");
            }

            if(investment.Trim() == "")
            {
                throw new Exception("Debe escribir una cantidad invertida");
            }

            try 
            { 
                int InvestmentInt = Int32.Parse(investment); 
            }catch (Exception ex)
            {
                throw new Exception("Inserte solo numeros en la inversión");
            }

            if(price.Trim() == "")
            {
                throw new Exception("Debe escribir una cantidad invertida");
            }

            try
            {
                int PriceInt = Int32.Parse(investment);
            }
            catch (Exception ex)
            {
                throw new Exception("Inserte solo numeros en el precio");
            }
        }

        
    }
}
