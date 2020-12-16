using Microsoft.Extensions.Configuration;
using System.IO;

namespace EVenda.Venda.Utils
{
    public static class ParametersUtils
    {
        public static string GetParameterByID(string key)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", true, true);

            var config = builder.Build();

            return config[$"Parameters:{key}"];
        }
    }
}
