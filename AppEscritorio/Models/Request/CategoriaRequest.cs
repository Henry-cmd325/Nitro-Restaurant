namespace ApiNitroRestaurant.Models.Request
{
    public class CategoriaRequest
    {
        public string Nombre { get; set; } = null!;
        public int IdSucursal { get; set; }
    }
}
