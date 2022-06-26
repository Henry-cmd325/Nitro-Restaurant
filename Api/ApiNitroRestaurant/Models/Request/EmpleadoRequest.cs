namespace ApiNitroRestaurant.Models.Request
{
    public class EmpleadoRequest
    {
        public string Nombre { get; set; } = null!;
        public string Paterno { get; set; } = null!;
        public string Materno { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public TipoEmpleadoRequest TipoEmpleado { get; set; } = null!;
    }
}
