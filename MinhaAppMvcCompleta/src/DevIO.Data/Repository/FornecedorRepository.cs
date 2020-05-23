using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
	public class FornecedorRepository: Repository<Fornecedor>, IFornecedorRepository
	{
		public FornecedorRepository(MeuDbContext contexto) : base(contexto) {
		}

		public async Task<Fornecedor> ObterFornecedorEndereco(Guid id) {

			// Obter o fornecedor junto com seu endereco
			return await Db.Fornecedores.AsNoTracking()
						.Include(c => c.Endereco)
						.FirstOrDefaultAsync(c => c.Id == id);

		}

		public async Task<Fornecedor> ObterFornecedorProdutoEndereco(Guid id) {
			//Retorna o fornecedor com os produtos e o fornecedor
			
			return await Db.Fornecedores.AsNoTracking()
						.Include(c => c.Produtos)
						.Include(c => c.Endereco)
						.FirstOrDefaultAsync(c => c.Id == id);
		}
	}
}
