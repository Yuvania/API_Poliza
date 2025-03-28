 
namespace API_Poliza.Modelos
{
	public class PolizaBusquedaRequest
	{
		public string? NumeroPoliza { get; set; }
		public int? TipoPolizaId { get; set; }
		 
		public DateTime? FechaVencimiento { get; set; }
		public string? CedulaAsegurado { get; set; }
		public string? NombreAsegurado { get; set; }  // incluye nombre o apellidos
	}
}
