using API_Poliza.Modelos;
using Microsoft.EntityFrameworkCore;

namespace API_Poliza.Data
{
 
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Asegurado> Asegurados { get; set; }
		public DbSet<Poliza> Polizas { get; set; }
		public DbSet<TipoPoliza> TiposPoliza { get; set; }
		public DbSet<Cobertura> Coberturas { get; set; }
		public DbSet<EstadoPoliza> EstadosPoliza { get; set; }
		public DbSet<TipoPersona> TiposPersona { get; set; }

		public DbSet<Usuario> Usuario { get; set; }

	}

}
