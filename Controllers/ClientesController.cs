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
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientes()
        {
            var result = new JsonResult(_clienteBusiness.TraerClientes());
            result.StatusCode = (int)HttpStatusCode.OK;
            return result;
        }

        //// GET: api/Clientes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Cliente>> GetCliente(int id)
        //{
        //  if (_context.Clientes == null)
        //  {
        //      return NotFound();
        //  }
        //    var cliente = await _context.Clientes.FindAsync(id);

        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    return cliente;
        //}

        //// PUT: api/Clientes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        //{
        //    if (id != cliente.Dni)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(cliente).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ClienteExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Clientes
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<IActionResult<Cliente>> PostCliente(Cliente cliente)
        //{
        //  if (_context.Clientes == null)
        //  {
        //      return Problem("Entity set 'CamarasFriasContext.Clientes'  is null.");
        //  }
        //    _context.Clientes.Add(cliente);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ClienteExists(cliente.Dni))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetCliente", new { id = cliente.Dni }, cliente);
        //}

        //// DELETE: api/Clientes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCliente(int id)
        //{
        //    if (_context.Clientes == null)
        //    {
        //        return NotFound();
        //    }
        //    var cliente = await _context.Clientes.FindAsync(id);
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Clientes.Remove(cliente);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ClienteExists(int id)
        //{
        //    return (_context.Clientes?.Any(e => e.Dni == id)).GetValueOrDefault();
        //}
    }
}
