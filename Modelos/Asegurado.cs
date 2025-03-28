using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Poliza.Modelos
{
	[Table("tblAsegurado")]
	public class Asegurado
	{
		[Key]
		[StringLength(20)]
		public string CedulaAsegurado { get; set; }

		[Required]
		[StringLength(50)]
		public string Nombre { get; set; }

		[Required]
		[StringLength(50)]
		public string PrimerApellido { get; set; }

		[StringLength(50)]
		public string SegundoApellido { get; set; }

		[Required]
		public int TipoPersonaId { get; set; }

		[Required]
		public DateTime FechaNacimiento { get; set; }

 
	}
}
