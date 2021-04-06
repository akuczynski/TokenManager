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

        IEnumerable<string> Environments { get; }
    }

    [Export(typeof(ITokenManagementService))]
    internal class TokenManagementService : ITokenManagementService
    {
        //todo: add subscribe events 
        private HashSet<TokenViewModel> _tokens;

        private IList<string> _environments;

        private IPersistanceService _persistanceService { get; set; }

        public IEnumerable<TokenViewModel> Tokens
        {
            get
            {
                return _tokens.ToList();
            }
        }

        public IEnumerable<string> Environments
        {
            get
            {
                return _environments;
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

            foreach (var environemnt in dataSource.GetAllEnvironments())
            {
                if (environemnt.IsRoot)
                {
                    // skip value for root environment 
                    continue;
                }

                var name = environemnt.Name;
                var token = dataSource.GetTokenOrDefault(tokenName, environemnt);

                var envViewModel = new EnvironentTokenViewModel
                {
                    Environment = name,
                    Value = token.Value,
                    UserName = token.UserName
                };

                result.Add(envViewModel);
            }

            return result;
        }

        public void Init()
        {
            _tokens = new HashSet<TokenViewModel>(new TokenViewModelComparer());
            _environments = new List<string>();
            var dataSource = _persistanceService.GetData();

            var globalTokens = dataSource.GetTokens(dataSource.RootEnvironment);
            AddToTokensSet(globalTokens, true);

            foreach (var environment in dataSource.GetAllEnvironments())
            {
                if (environment.Equals(dataSource.RootEnvironment))
                {
                    continue;
                }

                var tokens = dataSource.GetTokens(environment);
                AddToTokensSet(tokens, false);
                _environments.Add(environment.Name);
            }

            // subscribe
            // todo: remember about unsubscribe !!! 
        }

        private void AddToTokensSet(IEnumerable<Token> tokens, bool isGlobal)
        {
            foreach (var token in tokens)
            {
                var tokenViewModel = new TokenViewModel();
                tokenViewModel.Token = token.Key;
                tokenViewModel.Value = (isGlobal)? token.Value : "";
                tokenViewModel.Description = (isGlobal) ? token.Description : "";
                tokenViewModel.IsSubToken = token.IsSubToken;
                tokenViewModel.Password = token.IsPassword; 
                tokenViewModel.Global = isGlobal;

                _tokens.Add(tokenViewModel);
            }
        }

        public void UpdateToken()
        {
            // throw new NotImplementedException();
        }
    }
}
