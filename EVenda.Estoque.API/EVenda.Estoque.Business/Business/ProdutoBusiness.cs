using AutoMapper;
using EVenda.Estoque.Business.Interfaces;
using EVenda.Estoque.Business.Models;
using EVenda.Estoque.Business.Validations;
using EVenda.Estoque.Data.Interfaces;
using EVenda.Estoque.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVenda.Estoque.Business.Business
{
    public class ProdutoBusiness : BaseBusiness, IProdutoBusiness
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly IProdutoServiceBus _produtoServiceBus;

        public ProdutoBusiness(IProdutoRepository produtoRepository,
                              INotificador notificador,
                              IMapper mapper,
                                IProdutoServiceBus produtoServiceBus) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _produtoServiceBus = produtoServiceBus;
        }

        public async Task Adicionar(ProdutoViewModel produto)
        {
            var produtoModel = _mapper.Map<Produto>(produto);
            if (!ExecutarValidacao(new ProdutoValidation(), produtoModel)) return;

            if (!ValidateNameExists(produtoModel.Nome, produtoModel.Id))
            {
                Notificar("Este nome já pertence a outro produto!");
                return;
            }

            if (!ValidateSKUExists(produtoModel.Sku))
            {
                Notificar("Este código de produto já está cadastrado!");
                return;
            }

            await _produtoRepository.Adicionar(produtoModel);
            await _produtoServiceBus.AdicionarProduto(produtoModel);
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            if (!ValidateNameExists(produto.Nome, produto.Id))
            {
                Notificar("Este nome já pertence a outro produto!");
                return;
            }

            await _produtoRepository.Atualizar(produto);
            await _produtoServiceBus.AtualizarProduto(produto);
        }

        public async Task<Produto> BuscarProdutoPorSKU(string sku)
        {
            return await _produtoRepository.ObterPorSKU(sku);
        }

        public async Task<List<ProdutoViewModel>> ListarTodos()
        {
            return _mapper.Map<List<ProdutoViewModel>>(await _produtoRepository.ObterTodos());
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

        private bool ValidateNameExists(string nome, Guid Id)
        {
            return _produtoRepository.ObterPorNomeOutroID(nome, Id).Result == null;
        }
        private bool ValidateSKUExists(string sku)
        {
            return _produtoRepository.ObterPorSKU(sku).Result == null;
        }
    }
}
