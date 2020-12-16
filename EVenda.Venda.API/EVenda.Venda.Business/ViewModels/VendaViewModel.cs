using EVenda.Venda.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace EVenda.Venda.Business.ViewModels
{
    public class VendaViewModel : Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Sku { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Quantidade { get; set; }
    }
}
