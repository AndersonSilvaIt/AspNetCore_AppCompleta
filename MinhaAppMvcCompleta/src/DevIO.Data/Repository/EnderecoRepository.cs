using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
	public class EnderecoRepository: Repository<Endereco>, IEnderecoRepository
	{
		public EnderecoRepository(MeuDbContext contexto) : base(contexto) {
		}
		public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId) {

			//Obtem o endereco por fornecedor
			return await Db.Enderecos.AsNoTracking()
					.FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
		}
	}
}
