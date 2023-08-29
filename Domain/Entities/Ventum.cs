using System;
using System.Collections.Generic;

namespace CamarasFrias.Domain.Entities
{
    public partial class Ventum
    {
        public Ventum()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
        }

        public int NroComprobante { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal PrecioFinal { get; set; }
        public string? Nota { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
    }
}
