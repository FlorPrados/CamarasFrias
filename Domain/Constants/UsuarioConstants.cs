using CamarasFrias.Domain.Entities;

namespace CamarasFrias.Domain.Constants
{
    public class UsuarioConstants
    {
        public static List<Usuario> Usuarios = new()
        {
            new Usuario(){username = "prados", clave = "camara123", rol = "Admin"},
            new Usuario(){username = "florencia", clave = "camara123", rol = "Cliente"}
        };
    }
}
