using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAPI_Clientes.Data;
using WebAPI_Clientes.Models;
using WebAPI_Clientes.Services;

namespace WebAPI_Clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly WebAPI_ClientesContext _context;

        public ClientesController(WebAPI_ClientesContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<List<Clientes>> GetAll()
        {
            using (var connection = new SqlConnection("server=DESKTOP-JERKDL2\\SQLEXPRESS; database=produtosdb; user=sa; password=123456; persist security info=False; initial catalog=WebAPI"))
            {
                var clientes = connection.QueryAsync<Clientes>("TodosClientes").Result.ToList();
                return clientes;
            }
        }

        // GET: api/Clientes/5
        [HttpGet("{email}")]
        public async Task<List<Clientes>> GetClientes(string email)
        {
            using (var connection = new SqlConnection("server=DESKTOP-JERKDL2\\SQLEXPRESS; database=produtosdb; user=sa; password=123456; persist security info=False; initial catalog=WebAPI"))
            {
                var param = new { email };
                var cliente = connection.QueryAsync<Clientes>("ClientesIndividuais @email", param).Result.ToList();
                return cliente;
            }
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{email}")]
        public async Task<IActionResult> PutClientes(string email, Clientes clientes)
        {
            if (email != clientes.Email)
            {
                return BadRequest();
            }

            _context.Entry(clientes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesExists(email))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clientes>> PostClientes(Clientes clientes)
        {            
            try
            {
                new ClientesServices().PostClient(clientes);
            }
            catch (DbUpdateException)
            {
                if (ClientesExists(clientes.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClientes", new { id = clientes.Email }, clientes);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{email}")]
        public async Task<List<Clientes>> DeleteClientes(string email)
        {
            using (var connection = new SqlConnection("server=DESKTOP-JERKDL2\\SQLEXPRESS; database=produtosdb; user=sa; password=123456; persist security info=False; initial catalog=WebAPI"))
            {
                var param = new { email };
                var cliente = connection.QueryAsync<Clientes>("DeletarClientes @email", param).Result.ToList();
                return cliente;
            }
        }

        private bool ClientesExists(string id)
        {
            return _context.Clientes.Any(e => e.Email == id);
        }
    }
}
