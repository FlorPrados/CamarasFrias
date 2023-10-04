using CamarasFrias.Application.Business.Interfaces;
using CamarasFrias.Application.Mapper;
using CamarasFrias.Domain.DTO;
using CamarasFrias.Domain.Entities;
using CamarasFrias.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace CamarasFrias.Application.Business
{
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly CamarasFriasContext _context;
        public ClienteBusiness(CamarasFriasContext context)
        {
            _context =  context;   
        }

        public bool ActualizarCliente(int Id, ClientePutDTO cliente)
        {
            
            Cliente clienteExistente = _context.Clientes.FirstOrDefault(c => c.Dni == Id);

            if (clienteExistente == null) return false;

            clienteExistente.Nombre = cliente.Nombre;
            clienteExistente.Domicilio = cliente.Domicilio;
            clienteExistente.Telefono = cliente.Telefono;

            _context.SaveChanges();
            return true;
        }

        public ClienteDTO CrearCliente(ClienteDTO clienteDTO)
        {
            try
            {
                Cliente clienteDNI = _context.Clientes.FirstOrDefault(c => c.Dni == clienteDTO.Dni);

                if (clienteDNI != null)
                {
                    return null;
                    //throw new InvalidOperationException("Ya existe un cliente con el DNI registrado");
                }

                var cliente = ClienteMapper.createCliente(clienteDTO);
                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                return clienteDTO;
            }
            catch
            {
                throw;
            }
        }

        public bool EliminarCliente(int DNI)
        {
            try
            {
                Cliente cliente = _context.Clientes.FirstOrDefault(c => c.Dni == DNI);

                if (cliente == null) return false;

                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public ClienteDTO TraerClienteId(int DNI)
        {
            try
            {
                Cliente cliente = _context.Clientes.FirstOrDefault(c => c.Dni == DNI);

                ClienteDTO clienteDTO = ClienteMapper.ToClienteDTO(cliente);

                return clienteDTO;
            }
            catch
            {
                throw;
            }
        }

        public List<ClienteDTO> TraerClientes()
        {
            try
            {
                List<Cliente> clientes = _context.Clientes.ToList();

                List<ClienteDTO> clienteDTOs = ClienteMapper.ToClienteList(clientes);

                return clienteDTOs;
            }
            catch
            {
                throw;
            }
        }

    }
}
