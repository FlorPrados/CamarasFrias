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
                    NroComprobante = ventaDTO.NroComprobante,
                    ClienteId = ventaDTO.ClienteDNI,
                    Nota = ventaDTO.Nota
                };
            }
            return null;
        }
    }
}
