using System.ComponentModel.DataAnnotations;

namespace API_Poliza.Modelos
{
	public class LoginRequest
	{
		[Required]
		public string NombreUsuario { get; set; }

		[Required]
		public string Contrasena { get; set; }
	}
}
