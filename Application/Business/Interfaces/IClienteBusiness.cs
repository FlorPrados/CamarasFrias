using CamarasFrias.Domain.DTO;
using CamarasFrias.Domain.Entities;

namespace CamarasFrias.Application.Business.Interfaces
{
    public interface IClienteBusiness
    {
        public ClienteDTO CrearCliente();
        public List<ClienteDTO> TraerClientes();
        public ClienteDTO TraerClienteId(int Id);
        public bool EliminarCliente();
        public bool ActualizarCliente(int Id, Cliente cliente);

    }
}
