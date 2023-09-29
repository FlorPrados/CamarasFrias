using CamarasFrias.Domain.DTO;
using CamarasFrias.Domain.Entities;

namespace CamarasFrias.Application.Mapper
{
    public class VentaMapper
    {

        public static Ventum createVenta(VentaDTO ventaDTO)
        {
            if(ventaDTO != null)
            {
                new DetalleVentum
                {
                    //ProductoId = ventaDTO.Productos[0]
                };


                return new Ventum
                {
                    ClienteId = ventaDTO.ClienteDNI,
                    Nota = ventaDTO.Nota
                };
            }
            return null;
        }

        //public static Ventum putVenta(Ventum venta)
        //{
        //    if(venta != null)
        //    {
        //        return new Ventum
        //        {
        //        ClienteId = ventaDTO.ClienteDNI,
        //        Nota = ventaDTO.Nota,
        //        Fecha = DateTime.Now
        //        };
        //    }
        //    return null;
        //}

        public static VentaGetDTO ToVentaDTO(Ventum venta, List<DetalleGetProducto> productos, Cliente cliente)
        {
            if (venta != null)
            {
                return new VentaGetDTO
                {
                    NroComprobante = venta.NroComprobante,
                    ClienteDNI = venta.ClienteId,
                    Nombre = cliente.Nombre,
                    Fecha = venta.Fecha,
                    Productos = productos,
                    Nota = venta.Nota,
                    Total = venta.PrecioFinal
                };
            }
            return null;
        }
    }
}
