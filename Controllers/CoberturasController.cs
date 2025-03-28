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
    public class CoberturasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoberturasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Coberturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cobertura>>> GetCoberturas()
        {
            return await _context.Coberturas.ToListAsync();
        }

        // GET: api/Coberturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cobertura>> GetCobertura(int id)
        {
            var cobertura = await _context.Coberturas.FindAsync(id);

            if (cobertura == null)
            {
                return NotFound();
            }

            return cobertura;
        }

        // PUT: api/Coberturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCobertura(int id, Cobertura cobertura)
        {
            if (id != cobertura.Id)
            {
                return BadRequest();
            }

            _context.Entry(cobertura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoberturaExists(id))
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

        // POST: api/Coberturas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cobertura>> PostCobertura(Cobertura cobertura)
        {
            _context.Coberturas.Add(cobertura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCobertura", new { id = cobertura.Id }, cobertura);
        }

        // DELETE: api/Coberturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCobertura(int id)
        {
            var cobertura = await _context.Coberturas.FindAsync(id);
            if (cobertura == null)
            {
                return NotFound();
            }

            _context.Coberturas.Remove(cobertura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoberturaExists(int id)
        {
            return _context.Coberturas.Any(e => e.Id == id);
        }
    }
}
