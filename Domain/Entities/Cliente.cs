using System;
using System.Collections.Generic;

namespace CamarasFrias.Domain.Entities
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Ventum>();
        }

        public int Dni { get; set; }
        public string Nombre { get; set; } = null!;
        public int Telefono { get; set; }
        public string? Domicilio { get; set; }

        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
