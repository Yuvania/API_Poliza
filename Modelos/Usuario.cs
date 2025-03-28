using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Poliza.Modelos
{
	[Table("tblUsuario")]
	public class Usuario
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string NombreUsuario { get; set; }

		[Required]
		public string Contrasena { get; set; }

		public string Rol { get; set; }

		public bool EstaActivo { get; set; }
	}
}
