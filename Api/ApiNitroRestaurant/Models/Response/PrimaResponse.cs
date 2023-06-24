﻿namespace ApiNitroRestaurant.Models.Response
{
    public class PrimaResponse
    {
        public int IdUm { get; set; }
        public int IdPrima { get; set; }
        public int IdSucursal { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Inversion { get; set; }
        public int Cantidad { get; set; }
    }
}
