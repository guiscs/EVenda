using EVenda.Venda.Business.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EVenda.Venda.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IVendaServiceBus _vendaServiceBus;
        private const int timer = 10000;
        public Worker(ILogger<Worker> logger, IVendaServiceBus vendaServiceBus)
        {
            _logger = logger;
            _vendaServiceBus = vendaServiceBus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _vendaServiceBus.ListenProdutoCriado();
            _vendaServiceBus.ListenProdutoAlterado();

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(timer, stoppingToken);
            }
        }
    }
}
