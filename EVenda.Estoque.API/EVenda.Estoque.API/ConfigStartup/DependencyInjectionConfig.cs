using EVenda.Estoque.Business.Business;
using EVenda.Estoque.Business.Interfaces;
using EVenda.Estoque.Business.Notificacoes;
using EVenda.Estoque.Business.ServiceBus;
using EVenda.Estoque.Data.Context;
using EVenda.Estoque.Data.Interfaces;
using EVenda.Estoque.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EVenda.Estoque.API.ConfigStartup
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<EstoqueContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IProdutoBusiness, ProdutoBusiness>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            //services.AddTransient<IMapper, Mapper>();
            services.AddScoped<IProdutoServiceBus, ProdutoServiceBus>();
            return services;
        }
    }
}
