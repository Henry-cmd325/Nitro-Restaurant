using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovil.Models.Request
{
    public class ProductoRequest
    {
        public string Categoria { get; set; }
        public string Nombre { get; set; }
        public decimal Inversion { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }
        public string Imagen { get; set; }
    }
}
