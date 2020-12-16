using EVenda.Venda.Data.Models;
using System;
using System.Threading.Tasks;

namespace EVenda.Venda.Business.Interfaces
{
    public interface IProdutoBusiness : IDisposable
    {
        Task AdicionarProduto(Produto produto);
        Task AtualizarProduto(Produto produto);
        Task<Produto> BuscarProdutoPorSKU(string sku);
    }
}
