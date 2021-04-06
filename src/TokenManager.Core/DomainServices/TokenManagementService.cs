using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenManager.Core.Model;
using TokenManager.Core.ViewModel;

namespace TokenManager.Core.DomainServices
{
    public interface ITokenManagementService
    {
        void AddToken();

        void UpdateToken();

        IEnumerable<EnvironentTokenViewModel> GetTokenValuesForAllEnvironments(string tokenName);
        void Init();

        IEnumerable<TokenViewModel> Tokens { get; }
    }

    [Export(typeof(ITokenManagementService))]
    internal class TokenManagementService : ITokenManagementService
    {
        //todo: add subscribe events 
        private HashSet<TokenViewModel> _tokens { get; set; }

        private IPersistanceService _persistanceService { get; set; }

        public IEnumerable<TokenViewModel> Tokens
        {
            get
            {
                return _tokens.ToList();
            }
        }

        [ImportingConstructor]
        public TokenManagementService(IPersistanceService persistanceService)
        {
            _persistanceService = persistanceService;
        }

        public void AddToken()
        {
            //throw new NotImplementedException();
        }

        public IEnumerable<EnvironentTokenViewModel> GetTokenValuesForAllEnvironments(string tokenName)
        {
            var result = new List<EnvironentTokenViewModel>();
            var dataSource = _persistanceService.GetData();

            foreach (var environemnt in dataSource.EnvironmentTokens)
            {
                var name = environemnt.Key.Name;
                var envViewModel = new EnvironentTokenViewModel
                {
                    Environment = name
                };

                result.Add(envViewModel);
            } 

            return result;
        }

        public void Init()
        {
            _tokens = new HashSet<TokenViewModel>(new TokenViewModelComparer());
            var dataSource = _persistanceService.GetData();
            foreach (var item in dataSource.EnvironmentTokens)
            {
                AddToTokensSet(item.Value);
            }

            // subscribe
            // todo: remember about unsubscribe !!! 
        }

        private void AddToTokensSet(IList<Token> tokens)
        {
            foreach (var token in tokens)
            {
                var tokenViewModel = new TokenViewModel();
                tokenViewModel.Token = token.Key;
                tokenViewModel.Value = token.Value;
                tokenViewModel.IsSubToken = token.IsSubToken;

                _tokens.Add(tokenViewModel);
            }
        }

        public void UpdateToken()
        {
            // throw new NotImplementedException();
        }
    }
}
