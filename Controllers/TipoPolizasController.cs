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
    public class TipoPolizasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoPolizasController(ApplicationDbContext context)
        {
            _context = context; 
        }

        // GET: api/TipoPolizas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPoliza>>> GetTiposPoliza()
        {
            return await _context.TiposPoliza.ToListAsync();
        }

        // GET: api/TipoPolizas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPoliza>> GetTipoPoliza(int id)
        {
            var tipoPoliza = await _context.TiposPoliza.FindAsync(id);

            if (tipoPoliza == null)
            {
                return NotFound();
            }

            return tipoPoliza;
        }

        // PUT: api/TipoPolizas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoPoliza(int id, TipoPoliza tipoPoliza)
        {
            if (id != tipoPoliza.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoPoliza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPolizaExists(id))
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

        // POST: api/TipoPolizas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoPoliza>> PostTipoPoliza(TipoPoliza tipoPoliza)
        {
            _context.TiposPoliza.Add(tipoPoliza);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoPoliza", new { id = tipoPoliza.Id }, tipoPoliza);
        }

        // DELETE: api/TipoPolizas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoPoliza(int id)
        {
            var tipoPoliza = await _context.TiposPoliza.FindAsync(id);
            if (tipoPoliza == null)
            {
                return NotFound();
            }

            _context.TiposPoliza.Remove(tipoPoliza);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoPolizaExists(int id)
        {
            return _context.TiposPoliza.Any(e => e.Id == id);
        }
    }
}
