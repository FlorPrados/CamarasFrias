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

            if (clienteExistente != null)
            {
                clienteExistente.Nombre = cliente.Nombre;
                clienteExistente.Domicilio = cliente.Domicilio;
                clienteExistente.Telefono = cliente.Telefono;

                _context.SaveChanges();  // Guardar los cambios en la base de datos
                return true;  // Cliente actualizado con éxito
            }

            return false;

        }

        public ClienteDTO CrearCliente(ClienteDTO clienteDTO)
        {
            Cliente clienteDNI = _context.Clientes.FirstOrDefault(c => c.Dni == clienteDTO.Dni);

            if (clienteDNI != null)
            {
                return null;
            }

            var cliente = ClienteMapper.createCliente(clienteDTO);
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return clienteDTO;
        }

        public bool EliminarCliente(int DNI)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(c => c.Dni == DNI);

            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ClienteDTO TraerClienteId(int DNI)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(c => c.Dni == DNI);

            ClienteDTO clienteDTO = ClienteMapper.ToClienteDTO(cliente);

            return clienteDTO;
        }

        public List<ClienteDTO> TraerClientes()
        {
            List<Cliente> clientes = _context.Clientes.ToList();

            List<ClienteDTO> clienteDTOs = ClienteMapper.ToClienteList(clientes);

            return clienteDTOs;
        }


        private bool ClienteExists(int DNI)
        {
            return (_context.Clientes.Any(e => e.Dni == DNI));
        }
    }
}
