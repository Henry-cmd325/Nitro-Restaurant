﻿namespace AppEscritorio.Models.Response
{
    public class CategoryResponse
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = null!;
        public string? ImgUrl { get; set; }
        public int IdSucursal { get; set; }
    }
}