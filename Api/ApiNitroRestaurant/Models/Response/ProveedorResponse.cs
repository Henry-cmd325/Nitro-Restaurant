namespace ApiNitroRestaurant.Models.Response
{
    public class ProveedorResponse
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Telefono2 { get; set; }
        public string Telefono1 { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? NumeroCuenta { get; set; }
        public string? Telefono3 { get; set; }
    }
}
