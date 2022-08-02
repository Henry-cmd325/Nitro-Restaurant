using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorio.Models.Request
{
    internal class ProductRequest
    {
        public string Categoria { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public decimal Inversion { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }
        public string? Imagen { get; set; }
    }
}
