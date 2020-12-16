using EVenda.Estoque.Data.Context;
using EVenda.Estoque.Data.Interfaces;
using EVenda.Estoque.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EVenda.Estoque.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(EstoqueContext context) : base(context) { }

        public async Task<Produto> ObterPorNomeOutroID(string Nome, Guid id)
        {
            return await _ctxDB.Produtos.SingleOrDefaultAsync(p => p.Nome == Nome && p.Id != id);
        }

        public async Task<Produto> ObterPorSKU(string SKU)
        {
            return await _ctxDB.Produtos.SingleOrDefaultAsync(p => p.Sku == SKU);
        }
    }
}