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
    public class AseguradosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AseguradosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Asegurados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asegurado>>> GetAsegurados()
        {
            return await _context.Asegurados.ToListAsync();
        }

        // GET: api/Asegurados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asegurado>> GetAsegurado(string id)
        {
            var asegurado = await _context.Asegurados.FindAsync(id);

            if (asegurado == null)
            {
                return NotFound();
            }

            return asegurado;
        }

        // PUT: api/Asegurados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsegurado(string id, Asegurado asegurado)
        {
            if (id != asegurado.CedulaAsegurado)
            {
                return BadRequest();
            }

            _context.Entry(asegurado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AseguradoExists(id))
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

        // POST: api/Asegurados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Asegurado>> PostAsegurado(Asegurado asegurado)
        {
            _context.Asegurados.Add(asegurado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AseguradoExists(asegurado.CedulaAsegurado))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAsegurado", new { id = asegurado.CedulaAsegurado }, asegurado);
        }

        // DELETE: api/Asegurados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsegurado(string id)
        {
            var asegurado = await _context.Asegurados.FindAsync(id);
            if (asegurado == null)
            {
                return NotFound();
            }

            _context.Asegurados.Remove(asegurado);

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                // Si hay una violación de restricción de clave foránea
                if (ex.InnerException?.Message.Contains("FK_Poliza_Asegurado") == true)
                {
                    return BadRequest(new { mensaje = "No se puede eliminar el asegurado porque tiene pólizas asociadas." });
                }

                // Otro error
                return StatusCode(500, new { mensaje = "Error inesperado al eliminar el asegurado." });
            }
        }


        private bool AseguradoExists(string id)
        {
            return _context.Asegurados.Any(e => e.CedulaAsegurado == id);
        }
    }
}
