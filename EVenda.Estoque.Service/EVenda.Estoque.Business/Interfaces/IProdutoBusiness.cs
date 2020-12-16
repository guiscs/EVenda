using EVenda.Estoque.Business;
using EVenda.Estoque.Data.Models;
using System;
using System.Threading.Tasks;

namespace EVenda.Venda.Business.Interfaces
{
    public interface IProdutoBusiness : IDisposable
    {
        Task AtualizarProduto(VendaModel venda);
        Task<Produto> BuscarProdutoPorSKU(string sku);
    }
}
