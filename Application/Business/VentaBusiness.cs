using CamarasFrias.Application.Business.Interfaces;
using CamarasFrias.Application.Mapper;
using CamarasFrias.Domain.DTO;
using CamarasFrias.Domain.Entities;
using CamarasFrias.Infrastructure.Persistence;
using System.Collections.Generic;

namespace CamarasFrias.Application.Business
{
    public class VentaBusiness : IVentaBusiness
    {

        private readonly CamarasFriasContext _context;

        public VentaBusiness(CamarasFriasContext context)
        {
            _context = context;
        }

        public bool ActualizarVenta(int NroComprobante, VentaDTO ventaDTO)
        {
            try
            {
                var venta = _context.Venta.FirstOrDefault(v => v.NroComprobante == NroComprobante);

                if (venta == null) return false;

                var detalleVenta = _context.DetalleVenta.Where(v => v.VentaId == NroComprobante).ToList();

                venta.ClienteId = ventaDTO.ClienteDNI;
                venta.Nota = ventaDTO.Nota;
                venta.PrecioFinal = productChoice(ventaDTO, venta);

                _context.SaveChanges();

                return true;
            }
            catch
            {
                throw;
            }
        }

        public VentaDTO CrearVenta(VentaDTO ventaDTO)
        {
            try
            {
                var venta = new Ventum
                {
                    ClienteId = ventaDTO.ClienteDNI,
                    Nota = ventaDTO.Nota,
                    Fecha = DateTime.Now
                };

                _context.Venta.Add(venta);
                _context.SaveChanges();   // ?

                venta.PrecioFinal = productChoice(ventaDTO, venta);
                _context.Venta.Update(venta);
                _context.SaveChanges();

                return ventaDTO;
            }
            catch
            {
                throw;
            }
        }

        private decimal productChoice(VentaDTO ventaDTO, Ventum venta)
        {
            try
            {
                decimal precioTotal = 0;

                var productos = _context.Productos.ToList();

                foreach (var pto in ventaDTO.Productos)
                {
                    var producto = productos.FirstOrDefault(p => p.Id == pto.ProductoID);
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
                        return 0; // TO DO
                }
                return precioTotal;
            }
            catch
            {
                throw;
            }
        }

        public bool EliminarVenta(int NroComprobante)
        {
            try
            {
                var comprobante = _context.Venta.FirstOrDefault(v => v.NroComprobante == NroComprobante);

                if (comprobante == null) return false;

                var detallesVenta = _context.DetalleVenta.Where(d => d.VentaId == NroComprobante).ToList();

                _context.DetalleVenta.RemoveRange(detallesVenta);
                _context.Venta.Remove(comprobante);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                throw;
            }

        }

        public VentaGetDTO VerVenta(int NroComprobante)
        {
            try
            {
                var venta = _context.Venta.FirstOrDefault(v => v.NroComprobante == NroComprobante);

                if (venta == null) return null;

                var detalles = _context.DetalleVenta.Where(d => d.VentaId == NroComprobante).ToList();
                var cliente = _context.Clientes.FirstOrDefault(c => c.Dni == venta.ClienteId);
                var ptos = _context.Productos.ToList();

                var productos = new List<DetalleGetProducto>();

                if (cliente == null) return new();

                return GetProductData(ptos, detalles, productos, venta, cliente);
            }
            catch
            {
                throw;
            }
        }

        public List<VentaGetDTO> VerVentasCliente(int NroDNI)
        {
            try
            {
                var cliente = _context.Clientes.FirstOrDefault(c => c.Dni == NroDNI);
                if (cliente == null) return null;

                var ventas = _context.Venta.Where(v=> v.ClienteId == NroDNI);
                var detalles = _context.DetalleVenta.ToList();
                var ptos = _context.Productos.ToList();

                List<VentaGetDTO> ventasDTO = new();

                foreach (Ventum venta in ventas)
                {
                    var detalleFiltered = detalles.Where(d => d.VentaId == venta.NroComprobante);

                    var productos = new List<DetalleGetProducto>();

                    ventasDTO.Add(GetProductData(ptos, detalleFiltered, productos, venta, cliente));
                }

                return ventasDTO;
            }
            catch
            {
                throw;
            }
        }

        public List<VentaGetDTO> VerVentas()
        {
            try
            {
                var ventas = _context.Venta.ToList();
                var detalles = _context.DetalleVenta.ToList();
                var clientes = _context.Clientes.ToList();
                var ptos = _context.Productos.ToList();

                List<VentaGetDTO> ventasDTO = new();

                foreach (Ventum venta in ventas)
                {

                    var detalleFiltered = detalles.Where(d => d.VentaId == venta.NroComprobante);

                    var cliente = clientes.FirstOrDefault(c => c.Dni == venta.ClienteId);

                    if (cliente == null) return new();

                    var productos = new List<DetalleGetProducto>();

                    ventasDTO.Add(GetProductData(ptos, detalleFiltered, productos, venta, cliente));
                }

                return ventasDTO;
            }
            catch
            {
                throw;
            }
        }

        private VentaGetDTO GetProductData(List<Producto> ptos, IEnumerable<DetalleVentum> detalleFiltered, List<DetalleGetProducto> productos, Ventum venta, Cliente cliente)
        {
            try
            {
                foreach (DetalleVentum detalle in detalleFiltered)
                {

                    var pto = ptos.FirstOrDefault(p => p.Id == detalle.ProductoId);

                    var detalleGetProducto = new DetalleGetProducto
                    {
                        ProductoID = detalle.ProductoId,
                        Nombre = pto.Nombre,
                        Precio = pto.Precio,
                        Cantidad = detalle.Cantidad,
                        PorcDescuento = detalle.PorcDescuento
                    };
                    productos.Add(detalleGetProducto);
                }
                return VentaMapper.ToVentaDTO(venta, productos, cliente);
            }
            catch
            {
                throw;
            }
        }

    }
}
