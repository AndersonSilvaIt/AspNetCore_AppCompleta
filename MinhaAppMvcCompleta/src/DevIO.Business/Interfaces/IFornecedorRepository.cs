using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
	public interface IFornecedorRepository : IRepository<Fornecedor>
	{
		Task<Fornecedor> ObterFornecedorEndereco(Guid id); //Obter o endereco do fornecedor
		Task<Fornecedor> ObterFornecedorProdutoEndereco(Guid id); //Retorna o fornecedor e a lista de produto deste fornecedor
	}
}
