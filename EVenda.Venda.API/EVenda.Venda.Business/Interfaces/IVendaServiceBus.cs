using EVenda.Venda.Business.ViewModels;
using System.Threading.Tasks;

namespace EVenda.Venda.Business.Interfaces
{
    public interface IVendaServiceBus
    {
        Task ProdutoVendido(VendaViewModel venda);
    }
}
