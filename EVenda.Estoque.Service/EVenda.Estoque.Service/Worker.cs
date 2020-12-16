using EVenda.Venda.Business.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EVenda.Estoque.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEstoqueServiceBus _estoqueServiceBus;
        private const int timer = 10000;

        public Worker(ILogger<Worker> logger, IEstoqueServiceBus estoqueServiceBus)
        {
            _logger = logger;
            _estoqueServiceBus = estoqueServiceBus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _estoqueServiceBus.ListenProdutoVendido();
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(timer, stoppingToken);
            }
        }
    }
}
