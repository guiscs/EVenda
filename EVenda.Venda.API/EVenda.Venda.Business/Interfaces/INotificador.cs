using EVenda.Venda.Business.Notificacoes;
using System.Collections.Generic;

namespace EVenda.Venda.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
