using AutoMapper;
using EVenda.Venda.Business.Interfaces;
using EVenda.Venda.Business.Validations;
using EVenda.Venda.Business.ViewModels;
using EVenda.Venda.Data.Interfaces;
using EVenda.Venda.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVenda.Venda.Business.Business
{
    public class VendaBusiness : BaseBusiness, IVendaBusiness
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly IVendaServiceBus _vendaServiceBus;

        public VendaBusiness(IProdutoRepository produtoRepository,
                              INotificador notificador,
                              IMapper mapper,
                                IVendaServiceBus vendaServiceBus) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _vendaServiceBus = vendaServiceBus;
        }

        public async Task ExecutarVenda(VendaViewModel venda)
        {
            if (!ExecutarValidacao(new VendaValidation(), venda)) return;

            var produtoModel = _mapper.Map<Produto>(await BuscarProdutoPorSKU(venda.Sku));
            if (produtoModel == null)
            {
                Notificar("Produto não encontrado.");
                return;
            }

            if (venda.Quantidade > produtoModel.QtdEstoque)
            {
                Notificar("Quantidade maior do que o disponivel no estoque.");
                return;
            }

            produtoModel.QtdEstoque -= venda.Quantidade;
            await _produtoRepository.Atualizar(produtoModel);
            venda.Id = produtoModel.Id;
            await _vendaServiceBus.ProdutoVendido(venda);
        }

        public async Task<Produto> BuscarProdutoPorSKU(string sku)
        {
            return await _produtoRepository.ObterPorSKU(sku);
        }

        public async Task<List<ProdutoViewModel>> ListarTodos()
        {
            return _mapper.Map<List<ProdutoViewModel>>(await _produtoRepository.ObterTodosComEstoque());
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

    }
}
