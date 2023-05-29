namespace AppEscritorio.Models.Response
{
    public class ProductResponse
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Inversion { get; set; }
        public decimal Precio { get; set; }
        public bool Contable { get; set; }
        public int Cantidad { get; set; }
        public int IdUm { get; set; }
        public string? ImgUrl { get; set; }
        public int IdSucursal { get; set; }
    }
}
