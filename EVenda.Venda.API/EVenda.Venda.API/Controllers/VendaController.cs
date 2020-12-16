using EVenda.Venda.Business.Interfaces;
using EVenda.Venda.Business.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVenda.Venda.API.Controllers
{
    [Route("api/venda")]
    public class VendaController : MainController
    {
        private readonly IVendaBusiness _vendaBusiness;

        public VendaController(INotificador notificador,
            IVendaBusiness vendaBusiness) : base(notificador)
        {
            _vendaBusiness = vendaBusiness;
        }

        [HttpGet]
        public async Task<List<ProdutoViewModel>> ObterTodosProdutos()
        {
            return await _vendaBusiness.ListarTodos();
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> ExecutarVenda(VendaViewModel venda)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _vendaBusiness.ExecutarVenda(venda);

            return CustomResponse(venda);
        }
    }
}
