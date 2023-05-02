namespace ApiNitroRestaurant.Models.Response
{
    public class EmpleadoResponse
    {
        public int IdEmpleado { get; set; }
        public string TipoEmpleado { get; set; } = null!;
        public string Usuario { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Paterno { get; set; } = null!;
        public string Materno { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Sucursal { get; set; } = null!;
    }
}
