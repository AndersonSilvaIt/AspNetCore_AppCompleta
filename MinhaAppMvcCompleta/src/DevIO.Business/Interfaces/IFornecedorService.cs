using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
	interface IFornecedorService
	{
		Task Adicionar(Fornecedor fornecedor);
		Task Atualizar(Fornecedor fornecedor);
		Task Remover(Guid id);
		Task AtualizarEndereco(Endereco endereco);
	}
}
