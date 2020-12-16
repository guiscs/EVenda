
using Evenda.Estoque.Data.Interfaces;
using EVenda.Estoque.Business.Business;
using EVenda.Estoque.Business.ServiceBus;
using EVenda.Estoque.Data.Context;
using EVenda.Estoque.Data.Repository;
using EVenda.Venda.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EVenda.Estoque.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<EstoqueContext>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IEstoqueServiceBus, EstoqueServiceBus>();
            services.AddTransient<IProdutoBusiness, ProdutoBusiness>();

            return services;
        }
    }
}
