using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CamarasFrias.Domain.Entities;
using CamarasFrias.Infrastructure.Persistence;
using CamarasFrias.Application.Business.Interfaces;
using System.Net;
using CamarasFrias.Domain.DTO;
using Microsoft.AspNetCore.Authorization;

namespace CamarasFrias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteBusiness _clienteBusiness;

        public ClientesController(IClienteBusiness clientBusiness)
        {
            _clienteBusiness = clientBusiness;
        } 

        // GET: api/Clientes
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientes()
        {
            var result = new JsonResult(_clienteBusiness.TraerClientes());
            result.StatusCode = (int)HttpStatusCode.OK;
            return result;
        }

        //// GET: api/Clientes/5
        [HttpGet("{DNI}")]
        [Authorize]
        public async Task<ActionResult<Cliente>> GetCliente(int DNI)
        {
            var result = new JsonResult(_clienteBusiness.TraerClienteId(DNI));
            var cliente = _clienteBusiness.TraerClienteId(DNI);
            if (cliente == null)
            {
                result.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else
            {
                result.StatusCode = (int)HttpStatusCode.OK;
            }
            return result;
        }

        //// PUT: api/Clientes/5
        [HttpPut("{id}")]
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> PutCliente(int id, ClientePutDTO cliente)
        {
            var clienteDNI = _clienteBusiness.TraerClienteId(id);
            var result = new JsonResult(_clienteBusiness.ActualizarCliente(id, cliente));
            if (clienteDNI == null)
            {
                result.StatusCode = (int)HttpStatusCode.NotFound;
                
            }
            else
            {
                result.StatusCode = (int)HttpStatusCode.OK;
            }
            return result;

        }

        //// POST: api/Clientes
        [HttpPost]
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> Create(ClienteDTO cliente)
        {
            var clienteCreado = _clienteBusiness.CrearCliente(cliente);

            if (clienteCreado != null)
            {
                var result = new JsonResult(clienteCreado);
                result.StatusCode = (int)HttpStatusCode.Created;
                return result;
            }
            else
            {
                return BadRequest();
            }
        }

        //// DELETE: api/Clientes/5
        [HttpDelete("{DNI}")]
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> Delete(int DNI)
        {
            var cliente = _clienteBusiness.EliminarCliente(DNI);
            if(cliente)
            {
                var result = new JsonResult(cliente);
                result.StatusCode = (int)HttpStatusCode.OK;
                return result;
            }
            return NotFound();
        }
    }
}
