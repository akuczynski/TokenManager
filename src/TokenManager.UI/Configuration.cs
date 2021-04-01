using Microsoft.Extensions.Configuration;
using System.ComponentModel.Composition;

namespace TokenManager.UI
{
    [Export(typeof(TokenManager.Core.Services.IConfiguration))]
    public class Configuration : TokenManager.Core.Services.IConfiguration
    {
        public string Get(string key)
        {
            return Config.Configuration[key];
        }

        internal static class Config
        {
            public static IConfigurationRoot Configuration { get; private set; }

            static Config()
            {
                var builder = new ConfigurationBuilder()
                    .AddJsonFile($"appsettings.json", true, true);

                Configuration = builder.Build();
            }
        }

    }
}
