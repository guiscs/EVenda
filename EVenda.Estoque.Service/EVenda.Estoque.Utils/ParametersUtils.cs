using Microsoft.Extensions.Configuration;
using System;

namespace EVenda.Estoque.Utils
{
    public static class ParametersUtils
    {
        static ConfigurationBuilder _builder;
        static IConfigurationRoot _configurationBuilder;

        public static string GetParameterByID(string key)
        {
            GerarConfiguration();
            return _configurationBuilder[$"Parameters:{key}"];
        }

        public static string GetConnectionString(string key)
        {
            try
            {
                return GetConfiguration($"ConnectionStrings:{key}");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static string GetConfiguration(string key)
        {

            GerarConfiguration();

            return _configurationBuilder[key];
        }

        private static void GerarConfiguration()
        {
            try
            {
                if (_builder == null)
                {
                    _builder = new ConfigurationBuilder();

                    _builder.SetBasePath(AppContext.BaseDirectory)
                                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                    _configurationBuilder = _builder.Build();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
