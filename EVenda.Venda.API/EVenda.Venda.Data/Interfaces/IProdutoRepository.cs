using EVenda.Venda.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVenda.Venda.Data.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> ObterPorSKU(string SKU);
        Task<List<Produto>> ObterTodosComEstoque();
    }
}
