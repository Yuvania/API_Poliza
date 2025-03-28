using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Poliza.Modelos
{
	[Table("tblPoliza")]
	public class Poliza
	{
		[Key]
		[Required]
		public string NumeroPoliza { get; set; }

		[Required]
		public int TipoPolizaId { get; set; }

		[Required]
		public string CedulaAsegurado { get; set; }

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal MontoAsegurado { get; set; }

		[Required]
		public DateTime FechaVencimiento { get; set; }

		[Required]
		public DateTime FechaEmision { get; set; }

		[Required]
		public int CoberturaId { get; set; }

		[Required]
		public int EstadoPolizaId { get; set; }

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Prima { get; set; }

		[Required]
		public DateTime Periodo { get; set; }

		[Required]
		public DateTime FechaInclusion { get; set; }

		[Required]
		[StringLength(100)]
		public string Aseguradora { get; set; }

		// Relaciones de navegación
		public TipoPoliza TipoPoliza { get; set; }

		[ForeignKey("CedulaAsegurado")]
		public Asegurado Asegurado { get; set; }
		public Cobertura Cobertura { get; set; }
		public EstadoPoliza EstadoPoliza { get; set; }
	}

}
