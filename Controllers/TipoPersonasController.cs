using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Poliza.Data;
using API_Poliza.Modelos;

namespace API_Poliza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPersonasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoPersonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoPersonas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPersona>>> GetTiposPersona()
        {
            return await _context.TiposPersona.ToListAsync();
        }

        // GET: api/TipoPersonas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPersona>> GetTipoPersona(int id)
        {
            var tipoPersona = await _context.TiposPersona.FindAsync(id);

            if (tipoPersona == null)
            {
                return NotFound();
            }

            return tipoPersona;
        }

        // PUT: api/TipoPersonas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoPersona(int id, TipoPersona tipoPersona)
        {
            if (id != tipoPersona.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoPersona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPersonaExists(id))
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

        // POST: api/TipoPersonas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoPersona>> PostTipoPersona(TipoPersona tipoPersona)
        {
            _context.TiposPersona.Add(tipoPersona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoPersona", new { id = tipoPersona.Id }, tipoPersona);
        }

        // DELETE: api/TipoPersonas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoPersona(int id)
        {
            var tipoPersona = await _context.TiposPersona.FindAsync(id);
            if (tipoPersona == null)
            {
                return NotFound();
            }

            _context.TiposPersona.Remove(tipoPersona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoPersonaExists(int id)
        {
            return _context.TiposPersona.Any(e => e.Id == id);
        }
    }
}
