namespace ApiNitroRestaurant.Models.Request
{
    public class ProductRequest
    {
        public int IdCategoria { get; set; }
        public int IdSucursal { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Inversion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int IdUm { get; set; }
        public string? ImgUrl { get; set; }
        public List<PrimaCantidad> primaList { get; set; } = new();    
    }

    public class PrimaCantidad
    {
        public int Cantidad { get; set; }
        public int IdPrima { get; set; }
    }
}
