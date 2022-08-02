using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovil.Models.Response
{
    public class ProductoResponse
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public decimal Inversion { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }
        public string Imagen { get; set; }
    }
}
