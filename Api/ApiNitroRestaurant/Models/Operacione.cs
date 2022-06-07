using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Models
{
    public partial class Operacione
    {
        public Operacione()
        {
            TipoOperaciones = new HashSet<TipoOperacione>();
        }

        public int IdOperacion { get; set; }
        public int IdModulo { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual Modulo IdModuloNavigation { get; set; } = null!;
        public virtual ICollection<TipoOperacione> TipoOperaciones { get; set; }
    }
}
