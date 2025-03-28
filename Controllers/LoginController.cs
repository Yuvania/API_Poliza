using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Poliza.Data;
using API_Poliza.Modelos;

namespace API_Poliza.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class LoginController : Controller
    {
		private readonly ApplicationDbContext _context;

		public LoginController(ApplicationDbContext context)
		{
			_context = context;
		}

		// POST: api/login
		[HttpPost]
		public async Task<IActionResult> Login([FromBody] LoginRequest login)
		{
			if (!ModelState.IsValid)
				return BadRequest("Datos incompletos");

			var usuario = await _context.Usuario
				.FirstOrDefaultAsync(u =>
					u.NombreUsuario == login.NombreUsuario &&
					u.Contrasena == login.Contrasena &&
					u.EstaActivo);

			if (usuario == null)
				return Unauthorized("Credenciales inválidas");

			// Devolver solo la información necesaria
			return Ok(new
			{
				usuario.Id,
				usuario.NombreUsuario,
				usuario.Rol
			});
		}
	}
}
