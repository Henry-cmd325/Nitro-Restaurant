using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Context
{
    public partial class TipoeOperacione
    {
        public int IdTipoeOperaciones { get; set; }
        public int IdTipoEmpleado { get; set; }
        public int IdTipoOperacion { get; set; }

        public virtual TipoEmpleado IdTipoEmpleadoNavigation { get; set; } = null!;
        public virtual Operacione IdTipoOperacionNavigation { get; set; } = null!;
    }
}
