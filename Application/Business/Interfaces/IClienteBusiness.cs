using CamarasFrias.Domain.DTO;
using CamarasFrias.Domain.Entities;

namespace CamarasFrias.Application.Business.Interfaces
{
    public interface IClienteBusiness
    {
        public ClienteDTO CrearCliente(ClienteDTO clienteDTO);
        public List<ClienteDTO> TraerClientes();
        public ClienteDTO TraerClienteId(int DNI);
        public bool EliminarCliente(int DNI);
        public bool ActualizarCliente(int DNI, ClientePutDTO cliente);

    }
}
