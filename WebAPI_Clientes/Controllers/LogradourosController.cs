using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Clientes.Data;
using WebAPI_Clientes.Models;

namespace WebAPI_Clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogradourosController : ControllerBase
    {
        private readonly WebAPI_ClientesContext _context;

        public LogradourosController(WebAPI_ClientesContext context)
        {
            _context = context;
        }

        // GET: api/Logradouros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Logradouro>>> GetLogradouro()
        {
            return await _context.Logradouro.ToListAsync();
        }

        // GET: api/Logradouros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Logradouro>> GetLogradouro(int id)
        {
            var logradouro = await _context.Logradouro.FindAsync(id);

            if (logradouro == null)
            {
                return NotFound();
            }

            return logradouro;
        }

        // PUT: api/Logradouros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogradouro(int id, Logradouro logradouro)
        {
            if (id != logradouro._idLogradouro)
            {
                return BadRequest();
            }

            _context.Entry(logradouro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogradouroExists(id))
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

        // POST: api/Logradouros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Logradouro>> PostLogradouro(Logradouro logradouro)
        {
            _context.Logradouro.Add(logradouro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogradouro", new { id = logradouro._idLogradouro }, logradouro);
        }

        // DELETE: api/Logradouros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogradouro(int id)
        {
            var logradouro = await _context.Logradouro.FindAsync(id);
            if (logradouro == null)
            {
                return NotFound();
            }

            _context.Logradouro.Remove(logradouro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogradouroExists(int id)
        {
            return _context.Logradouro.Any(e => e._idLogradouro == id);
        }
    }
}
