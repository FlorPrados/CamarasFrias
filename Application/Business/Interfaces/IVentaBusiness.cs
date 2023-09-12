using CamarasFrias.Domain.DTO;

namespace CamarasFrias.Application.Business.Interfaces
{
    public interface IVentaBusiness
    {
        public VentaDTO CrearVenta(VentaDTO ventaDTO);
        public bool ActualizarVenta(VentaDTO ventaDTO);
        public VentaGetDTO VerVenta(int ClienteDNI);
        public bool EliminarVenta(int ClienteDNI);

    }
}
