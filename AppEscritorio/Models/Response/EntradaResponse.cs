namespace AppEscritorio.Models.Response
{
    public class EntradaResponse
    {
        public int IdEntrada { get; set; }  
        public int IdSucursal { get; set; }
        public string Producto { get; set; } = string.Empty;
        public string? Proveedor { get; set; }
        public int Cantidad { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public int Segundo { get; set; }
    }
}
