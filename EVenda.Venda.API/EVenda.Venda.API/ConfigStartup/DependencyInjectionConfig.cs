using EVenda.Venda.Business.Business;
using EVenda.Venda.Business.Interfaces;
using EVenda.Venda.Business.Notificacoes;
using EVenda.Venda.Business.ServiceBus;
using EVenda.Venda.Data.Context;
using EVenda.Venda.Data.Interfaces;
using EVenda.Venda.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EVenda.Venda.API.ConfigStartup
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<VendaContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IVendaBusiness, VendaBusiness>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddScoped<IVendaServiceBus, VendaServiceBus>();
            return services;
        }
    }
}
