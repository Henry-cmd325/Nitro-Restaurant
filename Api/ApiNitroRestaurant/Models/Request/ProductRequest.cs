namespace ApiNitroRestaurant.Models.Request
{
    public class ProductRequest
    {
        public string Categoria { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public decimal Inversion { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }
        public byte[]? Imagen { get; set; }
    }
}
