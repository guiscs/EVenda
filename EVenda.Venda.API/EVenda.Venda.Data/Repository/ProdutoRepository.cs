using EVenda.Venda.Data.Context;
using EVenda.Venda.Data.Interfaces;
using EVenda.Venda.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVenda.Venda.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(VendaContext vendaContext) : base(vendaContext)
        {
        }

        public async Task<Produto> ObterPorSKU(string SKU)
        {
            return await _ctxDB.Produtos.SingleOrDefaultAsync(p => p.Sku == SKU);
        }

        public async Task<List<Produto>> ObterTodosComEstoque()
        {
            return await _ctxDB.Produtos.Where(p => p.QtdEstoque > 0).ToListAsync();
        }
    }
}
