using EVenda.Venda.Business.ViewModels;
using EVenda.Venda.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVenda.Venda.Business.Interfaces
{
    public interface IVendaBusiness : IDisposable
    {
        Task<List<ProdutoViewModel>> ListarTodos();
        Task<Produto> BuscarProdutoPorSKU(string sku);
        Task ExecutarVenda(VendaViewModel venda);
    }
}
