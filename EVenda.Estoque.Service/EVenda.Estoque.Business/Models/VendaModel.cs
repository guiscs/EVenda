using EVenda.Estoque.Data.Models;

namespace EVenda.Estoque.Business
{
    public class VendaModel : Entity
    {
        public string Sku { get; set; }
        public int Quantidade { get; set; }
    }
}
