namespace ApiNitroRestaurant.Models.Response
{
    public class ProductResponse
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Inversion { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }
        public string? Imagen { get; set; }
    }
}
