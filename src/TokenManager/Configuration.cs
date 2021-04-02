using System.ComponentModel.Composition;
using System.Configuration;

namespace TokenManager
{
    [Export(typeof(Core.Services.IConfiguration))]
    public class Configuration : Core.Services.IConfiguration
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
