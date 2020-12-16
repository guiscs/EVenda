using EVenda.Venda.Business.ViewModels;
using FluentValidation;

namespace EVenda.Venda.Business.Validations
{
    public class VendaValidation : AbstractValidator<VendaViewModel>
    {
        public VendaValidation()
        {
            RuleFor(c => c.Sku)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Quantidade)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}
