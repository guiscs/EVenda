using System.ComponentModel.DataAnnotations.Schema;

namespace EVenda.Venda.Data.Models
{
    public class Produto : Entity
    {
        public string Sku { get; set; }
        public string Nome { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }
        public int QtdEstoque { get; set; }
    }
}
