using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DevIO.Data.Context
{
	public class MeuDbContext : DbContext
	{
		public MeuDbContext(DbContextOptions options) : base(options) {
		}

		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Endereco> Enderecos { get; set; }
		public DbSet<Fornecedor> Fornecedores { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {

			/*Caso não for mapeado alguma propriedade, aqui é setado como default o tipo dela*/
			foreach(var property in modelBuilder.Model.GetEntityTypes()
											.SelectMany(e => e.GetProperties()
											.Where(p => p.ClrType == typeof(string)))) {
				property.SetColumnType("varchar(100)");
			}

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

			//Aqui estou retirando o delete cascade das entidades
			foreach(var  item in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) {
				item.DeleteBehavior = DeleteBehavior.ClientSetNull;
			}
			
			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.EnableSensitiveDataLogging();
			
			base.OnConfiguring(optionsBuilder);
		}

	}
}