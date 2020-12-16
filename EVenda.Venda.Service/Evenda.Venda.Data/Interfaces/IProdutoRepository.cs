using EVenda.Venda.Data.Models;
using System.Threading.Tasks;

namespace Evenda.Venda.Data.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> ObterPorSKU(string SKU);
    }
}
