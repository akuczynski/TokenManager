using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using TokenManager.Core.Model;
using TokenManager.Core.Services;
using TokenManager.Core.ViewModel;
using System.Linq; 

namespace TokenManager.Core.Controllers
{
    public interface IPersistanceController
    {
        void LoadData(string folderPath, bool isRoot);

        IEnumerable<TokenViewModel> ViewData(bool showTokens, bool showSubTokens);

        void SaveData(string rootFolderPath);
         
    }

    [Export(typeof(IPersistanceController))]
    internal class PersistanceController : IPersistanceController
    {
        private IDataSourceLoader _dataSourceLoader { get; set; }

        // keep in Sync with DataSource
        private HashSet<TokenViewModel> DataViewModel { get; set; }

        private DataSource DataSource { get; set; }

        [ImportingConstructor]
        public PersistanceController(IDataSourceLoader dataSourceLoader)
        {
            _dataSourceLoader = dataSourceLoader;
            DataSource = new DataSource();
            DataViewModel = new HashSet<TokenViewModel>();
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
            AddToTokens(tokens);
        }

        public IEnumerable<TokenViewModel> ViewData(bool showTokens, bool showSubTokens)
        {
            if (showSubTokens && showTokens)
            {
                return DataViewModel.ToList();
            }
            else if (showTokens == false && showSubTokens == true)
            {
                return DataViewModel.Where(x => x.IsSubToken == true).ToList();
            }
            else if (showTokens == true && showSubTokens == false)
            {
                return DataViewModel.Where(x => x.IsSubToken == false).ToList();
            }

            return Enumerable.Empty<TokenViewModel>();
        }

        public void SaveData(string rootFolderPath)
        {
            throw new System.NotImplementedException();
        } 

        private void AddToTokens(IList<Token> tokens)
        {
            foreach(var token in tokens)
            {
                var tokenViewModel = new TokenViewModel();
                tokenViewModel.Token = token.Key;
                tokenViewModel.Value = token.Value;
                tokenViewModel.IsSubToken = token.IsSubToken;

                DataViewModel.Add(tokenViewModel);
            }
        }
    }
}
