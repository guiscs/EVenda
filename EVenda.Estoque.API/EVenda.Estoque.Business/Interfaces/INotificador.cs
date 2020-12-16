using EVenda.Estoque.Business.Notificacoes;
using System.Collections.Generic;

namespace EVenda.Estoque.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
