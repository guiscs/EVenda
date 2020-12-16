using Evenda.Venda.Data.Interfaces;
using EVenda.Venda.Business.Interfaces;
using EVenda.Venda.Data.Models;
using System;
using System.Threading.Tasks;

namespace EVenda.Venda.Business.Business
{
    public class ProdutoBusiness : IProdutoBusiness
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoBusiness(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task AdicionarProduto(Produto produto)
        {
            try
            {
                if (ValidateSKUExists(produto.Sku))
                {
                    // Tratar exceção de produto já existente
                    return;
                }

                await _produtoRepository.Adicionar(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AtualizarProduto(Produto produto)
        {
            var produtoAtualizacao = await _produtoRepository.ObterPorSKU(produto.Sku);

            if (produtoAtualizacao == null)
            {
                // Tratar exceção de produto não existente
                return;
            }

            produtoAtualizacao.QtdEstoque = produto.QtdEstoque;
            produtoAtualizacao.Nome = produto.Nome;
            produtoAtualizacao.Valor = produto.Valor;

            await _produtoRepository.Atualizar(produtoAtualizacao);
        }

        public async Task<Produto> BuscarProdutoPorSKU(string sku)
        {
            return await _produtoRepository.ObterPorSKU(sku);
        }

        private bool ValidateSKUExists(string sku)
        {
            return _produtoRepository.ObterPorSKU(sku).Result != null;
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
