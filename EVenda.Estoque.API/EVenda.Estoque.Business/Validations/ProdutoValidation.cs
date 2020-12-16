using EVenda.Estoque.Data.Models;
using FluentValidation;

namespace EVenda.Estoque.Business.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Sku)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.QtdEstoque)
                .GreaterThan(-1).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.Valor)
            .GreaterThan(-1).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}
