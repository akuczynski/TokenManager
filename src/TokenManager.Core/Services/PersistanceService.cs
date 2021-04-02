using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using TokenManager.Core.Model;
using TokenManager.Core.Services;
using TokenManager.Core.ViewModel;
using System.Linq; 

namespace TokenManager.Core.Controllers
{
    public interface IPersistanceService
    {
        void LoadData(string folderPath, bool isRoot);

        DataSource GetData();

        void SaveData(string rootFolderPath);
         
    }

    [Export(typeof(IPersistanceService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    internal class PersistanceService : IPersistanceService
    {
        private IDataSourceLoader _dataSourceLoader { get; set; }

        private DataSource DataSource { get; set; }

        [ImportingConstructor]
        public PersistanceService(IDataSourceLoader dataSourceLoader)
        {
            _dataSourceLoader = dataSourceLoader;
            DataSource = new DataSource();
        }

        public void LoadData(string folderPath, bool isRoot)
        {
            var tokenXml = Path.Combine(folderPath, "tokens.xml");

            var environment = new Environment
            {
                IsRoot = isRoot, 
                Source = tokenXml,
                Name = "Main"   // todo: change this 
            }; 

            var tokens = _dataSourceLoader.ReadTokens(tokenXml, isRoot);
            DataSource.Add(environment, tokens);
        }
        
        public void SaveData(string rootFolderPath)
        {
            throw new System.NotImplementedException();
        }

        public DataSource GetData()
        {
            return DataSource;
        } 
    }
}
