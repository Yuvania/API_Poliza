using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Poliza.Data;
using API_Poliza.Modelos;

namespace API_Poliza.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PolizaController : Controller
    {
		private readonly ApplicationDbContext _context;

		public PolizaController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: api/poliza
		[HttpGet]
		public async Task<ActionResult<IEnumerable<PolizaDto>>> GetPolizas()
		{
			var polizas = await _context.Polizas
				.Include(p => p.TipoPoliza)
				.Include(p => p.Asegurado)
				.Include(p => p.Cobertura)
				.Include(p => p.EstadoPoliza)
				.ToListAsync();

			var dtoList = polizas.Select(p => new PolizaDto
			{
				NumeroPoliza = p.NumeroPoliza,
				TipoPolizaId = p.TipoPolizaId,
				TipoPolizaNombre = p.TipoPoliza?.Nombre,
				CedulaAsegurado = p.CedulaAsegurado,
				NombreAsegurado = p.Asegurado?.Nombre,
				PrimerApellidoAsegurado = p.Asegurado?.PrimerApellido,
				SegundoApellidoAsegurado = p.Asegurado?.SegundoApellido,
				MontoAsegurado = p.MontoAsegurado,
				FechaVencimiento = p.FechaVencimiento,
				FechaEmision = p.FechaEmision,
				CoberturaId = p.CoberturaId,
				CoberturaNombre = p.Cobertura?.Nombre,
				EstadoPolizaId = p.EstadoPolizaId,
				EstadoPolizaNombre = p.EstadoPoliza?.Nombre,
				Prima = p.Prima,
				Periodo = p.Periodo.ToString("yyyy-MM-dd"),
				FechaInclusion = p.FechaInclusion,
				Aseguradora = p.Aseguradora
			}).ToList();

			return Ok(dtoList);
		}
		 

		// POST: api/poliza
		[HttpPost]
		public async Task<IActionResult> PostPoliza([FromBody] PolizaCreateDto dto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var poliza = new Poliza
			{
				NumeroPoliza = dto.NumeroPoliza,
				TipoPolizaId = dto.TipoPolizaId,
				CedulaAsegurado = dto.CedulaAsegurado,
				MontoAsegurado = dto.MontoAsegurado,
				FechaVencimiento = dto.FechaVencimiento,
				FechaEmision = dto.FechaEmision,
				CoberturaId = dto.CoberturaId,
				EstadoPolizaId = dto.EstadoPolizaId,
				Prima = dto.Prima,
				Periodo = dto.Periodo,
				FechaInclusion = dto.FechaInclusion,
				Aseguradora = dto.Aseguradora
			};

			_context.Polizas.Add(poliza);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetPolizaByNumero), new { numeroPoliza = poliza.NumeroPoliza }, poliza);
		}


		[HttpGet("{numeroPoliza}")]
		public async Task<ActionResult<PolizaDto>> GetPolizaByNumero(string numeroPoliza)
		{
			var poliza = await _context.Polizas
				.Include(p => p.TipoPoliza)
				.Include(p => p.Asegurado)
				.Include(p => p.Cobertura)
				.Include(p => p.EstadoPoliza)
				.FirstOrDefaultAsync(p => p.NumeroPoliza == numeroPoliza);

			if (poliza == null)
				return NotFound();

			var dto = new PolizaDto
			{
				NumeroPoliza = poliza.NumeroPoliza,
				TipoPolizaId = poliza.TipoPolizaId,
				TipoPolizaNombre = poliza.TipoPoliza?.Nombre,
				CedulaAsegurado = poliza.CedulaAsegurado,
				NombreAsegurado = poliza.Asegurado?.Nombre,
				PrimerApellidoAsegurado = poliza.Asegurado?.PrimerApellido,
				SegundoApellidoAsegurado = poliza.Asegurado?.SegundoApellido,
				MontoAsegurado = poliza.MontoAsegurado,
				FechaVencimiento = poliza.FechaVencimiento,
				FechaEmision = poliza.FechaEmision,
				CoberturaId = poliza.CoberturaId,
				CoberturaNombre = poliza.Cobertura?.Nombre,
				EstadoPolizaId = poliza.EstadoPolizaId,
				EstadoPolizaNombre = poliza.EstadoPoliza?.Nombre,
				Prima = poliza.Prima,
				Periodo = poliza.Periodo.ToString("yyyy-MM-dd"),
				FechaInclusion = poliza.FechaInclusion,
				Aseguradora = poliza.Aseguradora
			};

			return Ok(dto);
		}


		[HttpPut("{numeroPoliza}")]
		public async Task<IActionResult> PutPoliza(string numeroPoliza, [FromBody] PolizaUpdateDto dto)
		{
			var poliza = await _context.Polizas.FindAsync(numeroPoliza);

			if (poliza == null)
				return NotFound();

			poliza.TipoPolizaId = dto.TipoPolizaId;
			poliza.CedulaAsegurado = dto.CedulaAsegurado;
			poliza.MontoAsegurado = dto.MontoAsegurado;
			poliza.FechaVencimiento = dto.FechaVencimiento;
			poliza.FechaEmision = dto.FechaEmision;
			poliza.CoberturaId = dto.CoberturaId;
			poliza.EstadoPolizaId = dto.EstadoPolizaId;
			poliza.Prima = dto.Prima;
			poliza.Periodo = dto.Periodo;
			poliza.FechaInclusion = dto.FechaInclusion;
			poliza.Aseguradora = dto.Aseguradora;

			_context.Polizas.Update(poliza);
			await _context.SaveChangesAsync();

			return NoContent();
		}


		// DELETE: api/poliza/ABC123
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(string id)
		{
			var poliza = await _context.Polizas.FindAsync(id);
			if (poliza == null)
				return NotFound();

			_context.Polizas.Remove(poliza);
			await _context.SaveChangesAsync();
			return NoContent();
		}


		[HttpPost("buscar")]
		public async Task<ActionResult<IEnumerable<Poliza>>> Buscar([FromBody] PolizaBusquedaRequest filtro)
		{
			try
			{
				var query = _context.Polizas
					.Include(p => p.Asegurado)
					.Include(p => p.TipoPoliza)
					.Include(p => p.Cobertura)
					.Include(p => p.EstadoPoliza)
					.AsQueryable();

				if (!string.IsNullOrWhiteSpace(filtro.NumeroPoliza) && filtro.NumeroPoliza != "string")
				{
					query = query.Where(p => p.NumeroPoliza.Contains(filtro.NumeroPoliza));
				}

				if (filtro.TipoPolizaId.HasValue && filtro.TipoPolizaId.Value != 0)
				{
					query = query.Where(p => p.TipoPolizaId == filtro.TipoPolizaId.Value);
				}

				if (filtro.FechaVencimiento.HasValue && filtro.FechaVencimiento.Value.Year > 2000)
				{
					var fecha = filtro.FechaVencimiento.Value.Date;
					query = query.Where(p =>
						p.FechaVencimiento.Year == fecha.Year &&
						p.FechaVencimiento.Month == fecha.Month &&
						p.FechaVencimiento.Day == fecha.Day);
				}

				if (!string.IsNullOrWhiteSpace(filtro.CedulaAsegurado) && filtro.CedulaAsegurado != "string")
				{
					query = query.Where(p => p.CedulaAsegurado.Contains(filtro.CedulaAsegurado));
				}

				if (!string.IsNullOrWhiteSpace(filtro.NombreAsegurado) && filtro.NombreAsegurado != "string")
				{
					var nombre = filtro.NombreAsegurado.ToLower();
					query = query.Where(p =>
						p.Asegurado != null &&
						(
							p.Asegurado.Nombre.ToLower().Contains(nombre) ||
							p.Asegurado.PrimerApellido.ToLower().Contains(nombre) ||
							p.Asegurado.SegundoApellido.ToLower().Contains(nombre)
						));
				}


				var resultado = await query.ToListAsync();
				return Ok(resultado);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error en la búsqueda: {ex.Message}");
			}
		}



	}
}
