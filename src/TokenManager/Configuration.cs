using System.ComponentModel.Composition;
using System.Configuration;

namespace TokenManager
{
    [Export(typeof(Core.DomainServices.IConfiguration))]
    public class Configuration : Core.DomainServices.IConfiguration
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
