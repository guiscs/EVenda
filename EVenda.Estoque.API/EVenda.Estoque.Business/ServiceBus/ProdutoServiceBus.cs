using EVenda.Estoque.Business.Interfaces;
using EVenda.Estoque.Data.Models;
using EVenda.Estoque.Utils;
using Microsoft.Azure.ServiceBus;
using System.Threading.Tasks;

namespace EVenda.Estoque.Business.ServiceBus
{
    public class ProdutoServiceBus : IProdutoServiceBus
    {
        private readonly string _connectionStringServiceBus;

        public ProdutoServiceBus()
        {
            _connectionStringServiceBus = ParametersUtils.GetParameterByID("ConnectionStringServiceBus");
        }

        public async Task AdicionarProduto(Produto produto)
        {
            var topicClient = TopicClientFactory(ParametersUtils.GetParameterByID("EntityAdicionarProduto"));
            var message = new Message(produto.ToJsonBytes());
            message.ContentType = "application/json";
            message.UserProperties.Add("CorrelationId", produto.Id.ToString());
            await topicClient.SendAsync(message);
        }

        public async Task AtualizarProduto(Produto produto)
        {
            var topicClient = TopicClientFactory(ParametersUtils.GetParameterByID("EntityAtualizarProduto"));
            var message = new Message(produto.ToJsonBytes());
            message.ContentType = "application/json";
            message.UserProperties.Add("CorrelationId", produto.Id.ToString());
            await topicClient.SendAsync(message);
        }

        private TopicClient TopicClientFactory(string entityPath)
        {
            return new TopicClient(_connectionStringServiceBus, entityPath);
        }
    }
}
