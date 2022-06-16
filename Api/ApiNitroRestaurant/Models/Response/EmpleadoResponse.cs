namespace ApiNitroRestaurant.Models.Response
{
    public class EmpleadoResponse
    {
        public int IdEmpleado { get; set; }
        public int IdTipoEmpleado { get; set; }
        public int? IdCuenta { get; set; }
        public string Nombre { get; set; } = null!;
        public string Paterno { get; set; } = null!;
        public string Materno { get; set; } = null!;
        public string Telefono { get; set; } = null!;
    }
}
