using System;
using System.Collections.Generic;

namespace CamarasFrias.Domain.Entities
{
    public class Producto
    {
        public Producto()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
    }
}
