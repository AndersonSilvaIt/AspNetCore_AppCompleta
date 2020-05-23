using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
	public class FornecedorMapping: IEntityTypeConfiguration<Fornecedor>
	{
		public void Configure(EntityTypeBuilder<Fornecedor> builder) {

			builder.HasKey(p => p.Id);
			builder.Property(x => x.Nome)
				.IsRequired()
				.HasColumnType("varchar(200)");

			builder.Property(x => x.Documento)
				.IsRequired()
				.HasColumnType("varchar(14)");

			/*Configuracao 1 > 1 => Fornecedor : Endereco
			 * Fornecedor tem um endereço
			 * e Endereço tem um fornecedor (WithOne)*/
			builder.HasOne(f => f.Endereco)
				.WithOne(e => e.Fornecedor);

			/*Configuracao 1 > N => Fornecedor : Produtos
			 * Fornecedor tem varios produtos
			 * e Produto tem um fornecedor (WithOne)*/
			builder.HasMany(f => f.Produtos)
				.WithOne(p => p.Fornecedor)
				.HasForeignKey(p => p.FornecedorId); // Qual a chave estrangeira entre produto e fornecedor

			builder.ToTable("Fornecedores");
		}
	}

}
