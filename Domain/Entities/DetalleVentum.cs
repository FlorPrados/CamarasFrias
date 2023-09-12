using System;
using System.Collections.Generic;

namespace CamarasFrias.Domain.Entities
{
    public partial class DetalleVentum
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int? PorcDescuento { get; set; }
        public decimal Subtotal { get; set; }

        public virtual Producto Producto { get; set; } = null!;
        public virtual Ventum Venta { get; set; } = null!;

    }
}
