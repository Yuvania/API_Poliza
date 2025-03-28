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
    public class EstadoPolizasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstadoPolizasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EstadoPolizas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoPoliza>>> GetEstadosPoliza()
        {
            return await _context.EstadosPoliza.ToListAsync();
        }

        // GET: api/EstadoPolizas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoPoliza>> GetEstadoPoliza(int id)
        {
            var estadoPoliza = await _context.EstadosPoliza.FindAsync(id);

            if (estadoPoliza == null)
            {
                return NotFound();
            }

            return estadoPoliza;
        }

        // PUT: api/EstadoPolizas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoPoliza(int id, EstadoPoliza estadoPoliza)
        {
            if (id != estadoPoliza.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoPoliza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoPolizaExists(id))
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

        // POST: api/EstadoPolizas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoPoliza>> PostEstadoPoliza(EstadoPoliza estadoPoliza)
        {
            _context.EstadosPoliza.Add(estadoPoliza);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoPoliza", new { id = estadoPoliza.Id }, estadoPoliza);
        }

        // DELETE: api/EstadoPolizas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoPoliza(int id)
        {
            var estadoPoliza = await _context.EstadosPoliza.FindAsync(id);
            if (estadoPoliza == null)
            {
                return NotFound();
            }

            _context.EstadosPoliza.Remove(estadoPoliza);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoPolizaExists(int id)
        {
            return _context.EstadosPoliza.Any(e => e.Id == id);
        }
    }
}
