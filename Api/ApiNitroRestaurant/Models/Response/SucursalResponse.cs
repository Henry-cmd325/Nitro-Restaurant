﻿using ApiNitroRestaurant.Models.Request;

namespace ApiNitroRestaurant.Models.Response
{
    public class SucursalResponse
    {
        public int IdSucursal { get; set; }
        public string Nombre { get; set; } = null!;
        public string NumMesas { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
    }
}