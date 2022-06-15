using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Models
{
    public partial class TipoOperacione
    {
        public int IdOperacion { get; set; }
        public int IdTipoEmpleado { get; set; }
        public int IdTipoOperacion { get; set; }

        public virtual Operacione IdOperacionNavigation { get; set; } = null!;
        public virtual TipoEmpleado IdTipoEmpleadoNavigation { get; set; } = null!;
    }
}
