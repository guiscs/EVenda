using EVenda.Venda.Business.Interfaces;
using EVenda.Venda.Business.Notificacoes;
using EVenda.Venda.Data.Models;
using FluentValidation;
using FluentValidation.Results;

namespace EVenda.Venda.Business.Business
{
    public abstract class BaseBusiness
    {
        private readonly INotificador _notificador;

        protected BaseBusiness(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}