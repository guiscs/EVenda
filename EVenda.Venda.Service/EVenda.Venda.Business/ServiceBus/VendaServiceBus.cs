using EVenda.Venda.Business.Interfaces;
using EVenda.Venda.Data.Models;
using EVenda.Venda.Utils;
using Microsoft.Azure.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace EVenda.Venda.Business.ServiceBus
{
    public class VendaServiceBus : IVendaServiceBus
    {
        private readonly IProdutoBusiness _produtoBusiness;
        private readonly string _connectionStringServiceBus;

        public VendaServiceBus(IProdutoBusiness produtoBusiness)
        {
            _produtoBusiness = produtoBusiness;
            _connectionStringServiceBus = ParametersUtils.GetParameterByID("ConnectionStringServiceBus");
        }

        public void ListenProdutoAlterado()
        {
            var serviceBusClient = SubscriptionClientFactory("TopicAlterarProduto", "SubcriptionVenda");
            serviceBusClient.RegisterMessageHandler(ProcessMessageProductUpdatedAsync, GetMessageHandlerOptions());
        }

        private async Task ProcessMessageProductUpdatedAsync(Message message, CancellationToken arg2)
        {
            var produto = message.Body.ParseJson<Produto>();
            await _produtoBusiness.AtualizarProduto(produto);
        }

        public void ListenProdutoCriado()
        {
            var serviceBusClient = SubscriptionClientFactory("TopicAdicionarProduto", "SubcriptionVenda");
            serviceBusClient.RegisterMessageHandler(ProcessMessageProductCreateddAsync, GetMessageHandlerOptions());
        }

        private async Task ProcessMessageProductCreateddAsync(Message message, CancellationToken arg2)
        {
            var produto = message.Body.ParseJson<Produto>();
            await _produtoBusiness.AdicionarProduto(produto);
        }

        private MessageHandlerOptions GetMessageHandlerOptions()
        {
            return new MessageHandlerOptions(ExceptionReceiveHandler)
            {
                MaxConcurrentCalls = int.Parse(ParametersUtils.GetParameterByID("MaxConcurrentCalls").ToString()),
                AutoComplete = bool.Parse(ParametersUtils.GetParameterByID("AutoComplete").ToString()),
            };
        }

        private SubscriptionClient SubscriptionClientFactory(string topicPath, string subscriptionName)
        {
            return new SubscriptionClient(
                        _connectionStringServiceBus,
                        ParametersUtils.GetParameterByID(topicPath),
                        ParametersUtils.GetParameterByID(subscriptionName));
        }
        
        private Task ExceptionReceiveHandler(ExceptionReceivedEventArgs arg)
        {
            //TODO: Implementar Tratativa de exception
            return Task.CompletedTask;
        }
    }
}
