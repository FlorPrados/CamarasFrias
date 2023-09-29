using CamarasFrias.Domain.DTO;

namespace CamarasFrias.Application.Business.Interfaces
{
    public interface IVentaBusiness
    {
        public VentaDTO CrearVenta(VentaDTO ventaDTO);
        public bool ActualizarVenta(int NroComprobante, VentaDTO ventaDTO);
        public VentaGetDTO VerVenta(int NroComprobante);
        public VentaGetDTO VerVentasCliente(int NroDNI);
        public List<VentaGetDTO> VerVentas();
        public bool EliminarVenta(int NroComprobante);

    }
}
