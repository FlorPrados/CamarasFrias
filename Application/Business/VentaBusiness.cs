using CamarasFrias.Application.Business.Interfaces;
using CamarasFrias.Domain.DTO;
using CamarasFrias.Domain.Entities;
using CamarasFrias.Infrastructure.Persistence;

namespace CamarasFrias.Application.Business
{
    public class VentaBusiness : IVentaBusiness
    {

        private readonly CamarasFriasContext _context;

        public VentaBusiness(CamarasFriasContext context)
        {
            _context = context;
        }

        public bool ActualizarVenta(VentaDTO ventaDTO)
        {
            throw new NotImplementedException();
        }

        public VentaDTO CrearVenta(VentaDTO ventaDTO)
        {

            var venta = new Ventum
            {
                ClienteId = ventaDTO.ClienteDNI,
                Nota = ventaDTO.Nota,
                Fecha = DateTime.Now
            };

            _context.Venta.Add(venta);
            _context.SaveChanges();   // ?

            decimal precioTotal = 0;
            foreach(var pto in ventaDTO.Productos)
            {
                var producto = _context.Productos.FirstOrDefault(p => p.Id == pto.ProductoID);

                if (producto != null)
                {
                    var detalleVenta = new DetalleVentum
                    {
                        VentaId = venta.NroComprobante,
                        ProductoId = producto.Id,
                        Cantidad = pto.Cantidad,
                        PorcDescuento = pto.PorcDescuento,
                        Subtotal = (producto.Precio * pto.Cantidad)
                    };

                    
                    _context.DetalleVenta.Add(detalleVenta);
                    precioTotal += detalleVenta.Subtotal;
                }
                else
                    return null;
            }

            venta.PrecioFinal = precioTotal;
            _context.Venta.Update(venta);
            _context.SaveChanges();

            return ventaDTO;
        }

        public bool EliminarVenta(int ClienteDNI)
        {
            throw new NotImplementedException();
        }

        public VentaGetDTO VerVenta(int ClienteDNI)
        {
            throw new NotImplementedException();
        }
    }
}
