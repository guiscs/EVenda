using EVenda.Estoque.Data.Models;
using System;
using System.Threading.Tasks;

namespace EVenda.Estoque.Data.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> ObterPorSKU(string SKU);
        Task<Produto> ObterPorNomeOutroID(string Nome, Guid id);
    }
}
