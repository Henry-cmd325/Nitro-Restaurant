using System;
using System.Collections.Generic;

namespace ApiNitroRestaurant.Models
{
    public partial class Modulo
    {
        public Modulo()
        {
            Operaciones = new HashSet<Operacione>();
        }

        public int IdModulo { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Operacione> Operaciones { get; set; }
    }
}
