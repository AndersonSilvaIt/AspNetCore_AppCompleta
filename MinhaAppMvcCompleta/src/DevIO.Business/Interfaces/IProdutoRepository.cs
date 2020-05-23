using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
	public interface IProdutoRepository : IRepository<Produto>
	{
		Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId); //Retorna uma lista de produtos por fornecedor
		Task<IEnumerable<Produto>> ObterProdutosFornecedores(); // Retorna lista de produtos com as listas de fornecedores de cada
		Task<Produto> ObterProdutoFornecedor(Guid id); //Retorna o Produto e o fornecedor dele
	}
}
