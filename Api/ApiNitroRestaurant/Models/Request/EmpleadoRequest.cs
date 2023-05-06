namespace ApiNitroRestaurant.Models.Request
{
    public class EmpleadoRequest
    {
        public string Nombre { get; set; } = null!;
        public string Paterno { get; set; } = null!;
        public string Materno { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public int IdTipoEmpleado { get; set; }
        public int IdSucursal { get; set; }
        public string Usuario { get; set; } = null!;
        public bool Activo { get; set; }
        public string Contrasenia { get; set; } = null!;
        public string? ContraseniaAnterior { get; set; }
    }
}
