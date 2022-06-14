using System.ComponentModel.DataAnnotations;

namespace ApiNitroRestaurant.Models.Request
{
    public class SignInRequest
    {
        public string Nombre { get; set; } = null!;
        public string Paterno { get; set; } = null!;
        public string Materno { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public CuentaRequest Cuenta { get; set; } = null!;
        public TipoEmpleadoRequest TipoEmpleado { get; set; } = null!; 
    }

    public class CuentaRequest
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class TipoEmpleadoRequest
    {
        public string Nombre { get; set; } = null!
    }
}
