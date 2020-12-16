using Evenda.Venda.Data.Interfaces;
using EVenda.Venda.Data.Context;
using EVenda.Venda.Data.Repository;
using EVenda.Venda.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EVenda.Venda.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(VendaContext context) : base(context) { }

        public async Task<Produto> ObterPorSKU(string SKU)
        {
            return await _ctxDB.Produtos.SingleOrDefaultAsync(p => p.Sku == SKU);
        }
    }
}