using CamarasFrias.Domain.DTO;
using CamarasFrias.Domain.Entities;

namespace CamarasFrias.Application.Mapper
{
    public class ClienteMapper
    {
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
    }
}
