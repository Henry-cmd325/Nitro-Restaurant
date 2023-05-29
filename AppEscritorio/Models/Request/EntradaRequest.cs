namespace AppEscritorio.Models.Request
{
    public class EntradaRequest
    {
        public int IdProducto { get; set; }
        public int IdSucursal { get; set; }
        public int? IdProveedor { get; set; }
        public int Cantidad { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public int Segundo { get; set; }
    }
}
