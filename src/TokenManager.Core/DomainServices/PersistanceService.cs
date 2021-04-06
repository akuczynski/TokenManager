using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using TokenManager.Core.Model;

namespace TokenManager.Core.DomainServices
{
    public interface IPersistanceService
    {
        void LoadData(string rootFolderPath);

        DataSource DataSource { get; }

        void SaveData(string rootFolderPath);
         
    }

    [Export(typeof(IPersistanceService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    internal class PersistanceService : IPersistanceService
    {
        private IDataSourceLoader _dataSourceLoader { get; set; }

        public DataSource DataSource { get; private set; }

        [ImportingConstructor]
        public PersistanceService(IDataSourceLoader dataSourceLoader)
        {
            _dataSourceLoader = dataSourceLoader;
        }

        public void LoadData(string rootFolderPath)
        {
            DataSource = new DataSource();

            var tokenXml = Path.Combine(rootFolderPath, "tokens.xml");
            AddTokens(tokenXml, "Root", true);

            var directories = Directory.EnumerateDirectories(rootFolderPath);
            foreach(var directoryPath in directories)
            {
                var envName = directoryPath.Split('\\').Last();
                tokenXml = Path.Combine(directoryPath, "tokens.xml");
                AddTokens(tokenXml, envName, false);
            }
        }
        
        public void SaveData(string rootFolderPath)
        {
            throw new System.NotImplementedException();
        } 

        private void AddTokens(string tokenXml, string environmentName, bool isRoot)
        {
            var environment = new Environment
            {
                IsRoot = isRoot,
                Source = tokenXml,
                Name = environmentName
            };

            var tokens = _dataSourceLoader.ReadTokens(tokenXml);
            DataSource.Add(environment, tokens);
        }
    }
}
