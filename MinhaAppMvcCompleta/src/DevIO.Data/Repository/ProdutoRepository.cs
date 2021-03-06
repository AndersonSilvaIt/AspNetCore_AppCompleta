﻿using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
	public class ProdutoRepository: Repository<Produto>, IProdutoRepository
	{
		public ProdutoRepository(MeuDbContext contexto) : base(contexto) {

		}

		public async Task<Produto> ObterProdutoFornecedor(Guid id) {
			//o include traz o fornecedor do produto
			//Chaves estrangeiras / Fazer um inner Join
			return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
				.AsNoTracking()
				.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task<IEnumerable<Produto>> ObterProdutosFornecedores() {

			//Traz todos os Fornecedores que liga esse produto
			return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
					.OrderBy(p => p.Nome).AsNoTracking().ToListAsync();
		}

		public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId) {

			return await Buscar(p => p.FornecedorId == fornecedorId);
		}
	}
}
