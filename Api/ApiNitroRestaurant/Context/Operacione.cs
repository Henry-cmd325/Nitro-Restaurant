using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Context
{
    public partial class Operacione
    {
        public Operacione()
        {
            TipoeOperaciones = new HashSet<TipoeOperacione>();
        }

        public int IdOperacion { get; set; }
        public int IdModulo { get; set; }
        public int Nombre { get; set; }

        public virtual Modulo IdModuloNavigation { get; set; } = null!;
        public virtual ICollection<TipoeOperacione> TipoeOperaciones { get; set; }
    }
}
