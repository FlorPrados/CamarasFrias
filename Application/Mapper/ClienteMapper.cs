using CamarasFrias.Domain.DTO;
using CamarasFrias.Domain.Entities;

namespace CamarasFrias.Application.Mapper
{
    public class ClienteMapper
    {

        public static Cliente createCliente(ClienteDTO clienteDTO)
        {
            //if (clienteDTO != null)
            //{
                return new Cliente
                {
                    Nombre = clienteDTO.Nombre,
                    Dni = clienteDTO.Dni,
                    Domicilio = clienteDTO.Domicilio,
                    Telefono = clienteDTO.Telefono
                };
            //}
            //return null;
        }


        public static List<ClienteDTO> ToClienteList(List<Cliente> cliente)
        {
            List<ClienteDTO> clienteDTO = new();
            if(cliente != null)
            {
                foreach(var c in cliente)
                {
                    clienteDTO.Add(
                        new ClienteDTO
                        {
                            Nombre = c.Nombre,
                            Dni = c.Dni,
                            Domicilio = c.Domicilio,
                            Telefono = c.Telefono
                        });
                }
                return clienteDTO;
            }
            return null;
        }

        public static ClienteDTO ToClienteDTO(Cliente cliente)
        {
            if (cliente != null)
            {
                return new ClienteDTO
                {
                    Nombre = cliente.Nombre,
                    Dni = cliente.Dni,
                    Domicilio = cliente.Domicilio,
                    Telefono = cliente.Telefono
                };
            }
            return null;
        }
    }
}
