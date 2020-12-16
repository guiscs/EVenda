using EVenda.Estoque.Business.Models;
using EVenda.Estoque.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVenda.Estoque.Business.Interfaces
{
    public interface IProdutoBusiness : IDisposable
    {
        Task Adicionar(ProdutoViewModel produto);
        Task Atualizar(Produto produto);
        Task<List<ProdutoViewModel>> ListarTodos();
        Task<Produto> BuscarProdutoPorSKU(string sku);
    }
}
