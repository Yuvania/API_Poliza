namespace API_Poliza.Modelos
{
	public class PolizaDto
	{
		public string NumeroPoliza { get; set; }
		public int TipoPolizaId { get; set; }
		public string TipoPolizaNombre { get; set; }

		public string CedulaAsegurado { get; set; }
		public string NombreAsegurado { get; set; }
		public string PrimerApellidoAsegurado { get; set; }
		public string SegundoApellidoAsegurado { get; set; }

		public decimal MontoAsegurado { get; set; }
		public DateTime FechaVencimiento { get; set; }
		public DateTime FechaEmision { get; set; }

		public int CoberturaId { get; set; }
		public string CoberturaNombre { get; set; }

		public int EstadoPolizaId { get; set; }
		public string EstadoPolizaNombre { get; set; }

		public decimal Prima { get; set; }
		public string Periodo { get; set; }
		public DateTime FechaInclusion { get; set; }

		public string Aseguradora { get; set; }
	}

}
