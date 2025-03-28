using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Poliza.Modelos
{
	[Table("tblEstadoPoliza")]
	public class EstadoPoliza
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Nombre { get; set; }
		 
	}
}
