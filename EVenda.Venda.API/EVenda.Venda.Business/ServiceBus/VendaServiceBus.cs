using EVenda.Venda.Business.Interfaces;
using EVenda.Venda.Business.ViewModels;
using EVenda.Venda.Utils;
using Microsoft.Azure.ServiceBus;
using System.Threading.Tasks;

namespace EVenda.Venda.Business.ServiceBus
{
    public class VendaServiceBus : IVendaServiceBus
    {
        private readonly string _connectionStringServiceBus;

        public VendaServiceBus()
        {
            _connectionStringServiceBus = ParametersUtils.GetParameterByID("ConnectionStringServiceBus");
        }

        public async Task ProdutoVendido(VendaViewModel venda)
        {
            var topicClient = TopicClientFactory(ParametersUtils.GetParameterByID("EntityProdutoVendido"));
            var message = new Message(venda.ToJsonBytes());
            message.ContentType = "application/json";
            message.UserProperties.Add("CorrelationId", venda.Id.ToString());
            await topicClient.SendAsync(message);
        }

        private TopicClient TopicClientFactory(string entityPath)
        {
            return new TopicClient(_connectionStringServiceBus, entityPath);
        }
    }
}
