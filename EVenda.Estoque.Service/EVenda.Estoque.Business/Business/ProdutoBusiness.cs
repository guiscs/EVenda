using Evenda.Estoque.Data.Interfaces;
using EVenda.Estoque.Data.Models;
using EVenda.Venda.Business.Interfaces;
using System;
using System.Threading.Tasks;

namespace EVenda.Estoque.Business.Business
{
    public class ProdutoBusiness : IProdutoBusiness
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoBusiness(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task AtualizarProduto(VendaModel venda)
        {
            var produtoAtualizacao = await _produtoRepository.ObterPorSKU(venda.Sku);

            if (produtoAtualizacao == null)
            {
                // Tratar exceção de produto não existente
                return;
            }

            produtoAtualizacao.QtdEstoque -= venda.Quantidade;
            await _produtoRepository.Atualizar(produtoAtualizacao);
        }

        public async Task<Produto> BuscarProdutoPorSKU(string sku)
        {
            return await _produtoRepository.ObterPorSKU(sku);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
