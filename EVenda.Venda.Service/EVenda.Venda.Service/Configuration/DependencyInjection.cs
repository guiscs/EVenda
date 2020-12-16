using Evenda.Venda.Data.Interfaces;
using EVenda.Venda.Data.Context;
using EVenda.Venda.Business.Business;
using EVenda.Venda.Business.Interfaces;
using EVenda.Venda.Business.ServiceBus;
using EVenda.Venda.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace EVenda.Venda.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<VendaContext>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IVendaServiceBus, VendaServiceBus>();
            services.AddTransient<IProdutoBusiness, ProdutoBusiness>();

            return services;
        }
    }
}
