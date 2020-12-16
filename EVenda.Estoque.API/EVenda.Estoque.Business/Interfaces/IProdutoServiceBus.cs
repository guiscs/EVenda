using EVenda.Estoque.Data.Models;
using System.Threading.Tasks;

namespace EVenda.Estoque.Business.Interfaces
{
    public interface IProdutoServiceBus
    {
        Task AdicionarProduto(Produto produto);
        Task AtualizarProduto(Produto produto);
    }
}
