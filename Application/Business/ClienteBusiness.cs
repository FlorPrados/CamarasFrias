using CamarasFrias.Application.Business.Interfaces;
using CamarasFrias.Application.Mapper;
using CamarasFrias.Domain.DTO;
using CamarasFrias.Domain.Entities;
using CamarasFrias.Infrastructure.Persistence;

namespace CamarasFrias.Application.Business
{
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly CamarasFriasContext _context;
        public ClienteBusiness(CamarasFriasContext context)
        {
            _context =  context;   
        }

        public bool ActualizarCliente(int Id, Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public ClienteDTO CrearCliente()
        {
            throw new NotImplementedException();
        }

        public bool EliminarCliente()
        {
            throw new NotImplementedException();
        }

        public ClienteDTO TraerClienteId(int Id)
        {
            throw new NotImplementedException();
        }

        public List<ClienteDTO> TraerClientes()
        {
            List<Cliente> clientes = _context.Clientes.ToList();

            List<ClienteDTO> clienteDTOs = ClienteMapper.ToClienteList(clientes);

            return clienteDTOs;
        }
    }
}
