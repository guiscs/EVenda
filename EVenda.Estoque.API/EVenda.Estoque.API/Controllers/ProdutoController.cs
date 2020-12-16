using AutoMapper;
using EVenda.Estoque.Business.Interfaces;
using EVenda.Estoque.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVenda.Estoque.API.Controllers
{
    [Route("api/produto")]
    public class ProdutoController : MainController
    {
        private readonly IProdutoBusiness _produtoBusiness;
        private readonly IMapper _mapper;

        public ProdutoController(INotificador notificador,
            IMapper mapper,
            IProdutoBusiness produtoBusiness) : base(notificador)
        {
            _produtoBusiness = produtoBusiness;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            return await _produtoBusiness.ListarTodos();
        }

        [HttpGet("{SKU}")]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(string SKU)
        {
            var produto = await _produtoBusiness.BuscarProdutoPorSKU(SKU);

            if (produto == null) return NotFound();

            return _mapper.Map<ProdutoViewModel>(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _produtoBusiness.Adicionar(produtoViewModel);

            return CustomResponse(produtoViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(ProdutoViewModel produto)
        {
            var produtoAtualizacao = await _produtoBusiness.BuscarProdutoPorSKU(produto.Sku);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (produtoAtualizacao == null) return NotFound();

            produtoAtualizacao.QtdEstoque = produto.QtdEstoque;
            produtoAtualizacao.Nome = produto.Nome;
            produtoAtualizacao.Valor = produto.Valor;

            await _produtoBusiness.Atualizar(produtoAtualizacao);

            return CustomResponse(produto);
        }
    }
}
