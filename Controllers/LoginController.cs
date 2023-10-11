using CamarasFrias.Domain.Constants;
using CamarasFrias.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CamarasFrias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost]
        public IActionResult Login(LoginUsuario loginUsuario)
        {
            var user = Authenticate(loginUsuario);

            if (user == null) return NotFound("User not found");

            var token = Generate(user);
            return Ok(token);
        }

        private Usuario Authenticate(LoginUsuario loginUsuario)
        {
            var user = UsuarioConstants.Usuarios.FirstOrDefault(user => user.username.ToLower() == loginUsuario.username.ToLower()
                                                                     && user.clave == loginUsuario.clave);

            if (user == null) return null;

            return user;
        }

        private string Generate(Usuario user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.username),
                new Claim(ClaimTypes.Role, user.rol),
            };

            // Creacion del token
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        

    }
}
