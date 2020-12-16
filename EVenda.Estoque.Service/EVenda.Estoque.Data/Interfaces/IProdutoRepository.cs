using EVenda.Estoque.Data.Models;
using System.Threading.Tasks;

namespace Evenda.Estoque.Data.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> ObterPorSKU(string SKU);
    }
}
