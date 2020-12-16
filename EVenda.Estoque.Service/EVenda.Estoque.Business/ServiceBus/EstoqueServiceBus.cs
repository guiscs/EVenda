using EVenda.Estoque.Data.Models;
using EVenda.Estoque.Utils;
using EVenda.Venda.Business.Interfaces;
using Microsoft.Azure.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace EVenda.Estoque.Business.ServiceBus
{
    public class EstoqueServiceBus : IEstoqueServiceBus
    {
        private readonly IProdutoBusiness _produtoBusiness;
        private readonly string _connectionStringServiceBus;

        public EstoqueServiceBus(IProdutoBusiness produtoBusiness)
        {
            _produtoBusiness = produtoBusiness;
            _connectionStringServiceBus = ParametersUtils.GetParameterByID("ConnectionStringServiceBus");
        }

        public void ListenProdutoVendido()
        {
            var serviceBusClient = SubscriptionClientFactory("TopicVendaProduto", "SubcriptionEstoque");
            serviceBusClient.RegisterMessageHandler(ProcessMessageProductUpdatedAsync, GetMessageHandlerOptions());
        }

        private async Task ProcessMessageProductUpdatedAsync(Message message, CancellationToken arg2)
        {
            var venda = message.Body.ParseJson<VendaModel>();
            await _produtoBusiness.AtualizarProduto(venda);
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
