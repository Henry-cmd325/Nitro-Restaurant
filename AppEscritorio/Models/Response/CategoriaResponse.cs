using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorio.Models.Response
{
    internal class CategoriaResponse
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
