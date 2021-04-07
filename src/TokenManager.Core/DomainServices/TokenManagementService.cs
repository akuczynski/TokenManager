using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenManager.Core.Events;
using TokenManager.Core.Model;
using TokenManager.Core.ViewModel;

namespace TokenManager.Core.DomainServices
{
    public interface ITokenManagementService
    {
        void AddToken(NewTokenViewModel newToken);

        void UpdateToken();

        void RemoveToken(string tokenName);

        //TODO: maybe move this to different class ?! 
        IEnumerable<EnvironentTokenViewModel> GetTokenValuesForAllEnvironments(string tokenName);
        void Init();

        IEnumerable<TokenViewModel> Tokens { get; }

        IEnumerable<string> Environments { get; }
    }

    [Export(typeof(ITokenManagementService))]
    internal class TokenManagementService : ITokenManagementService, System.IDisposable
    {
        //todo: add subscribe events 
        private HashSet<TokenViewModel> _tokens;

        private IList<string> _environments;

        private INotificationService _notificationService;

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
        public TokenManagementService(
            IPersistanceService persistanceService,
            INotificationService notificationService)
        {
            _persistanceService = persistanceService;
            _notificationService = notificationService;
        }

        public void AddToken(NewTokenViewModel newToken)
        {
            var token = new Token();
            token.Key = newToken.Token;
            token.Value = newToken.Value;
            token.Description = newToken.Description;
            token.IsSubToken = newToken.IsSubToken;
            token.IsPassword = newToken.IsPassword;
            token.UserName = newToken.UserName;

            //            var environment = newToken.Environment; 
            _persistanceService.DataSource.AddToken(token, newToken.Environment);
        }

        public IEnumerable<EnvironentTokenViewModel> GetTokenValuesForAllEnvironments(string tokenName)
        {
            var result = new List<EnvironentTokenViewModel>();
            var dataSource = _persistanceService.DataSource;

            foreach (var environemnt in dataSource.GetAllEnvironments())
            {
                if (environemnt.IsRoot)
                {
                    // skip value for root environment 
                    continue;
                }

                var name = environemnt.Name;
                var token = dataSource.GetToken(tokenName, environemnt);

                if (token is EmptyToken)
                {
                    continue;
                }

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
            var dataSource = _persistanceService.DataSource;

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

            dataSource.ModelChanged += OnModelChanged;
            // todo: remember about unsubscribe !!! 
        }

        public void UpdateToken()
        {
            // throw new NotImplementedException();
        }

        public void RemoveToken(string tokenName)
        {
            _persistanceService.DataSource.RemoveToken(tokenName);
        }

        public void Dispose()
        {
            _persistanceService.DataSource.ModelChanged -= OnModelChanged;
        }

        private void OnModelChanged(string tokenName, Action action)
        {
            if (action == Action.Delete)
            {
                var token = _tokens.SingleOrDefault(x => x.Token.Equals(tokenName));
                if (token != null)
                {
                    _tokens.Remove(token);
                    _notificationService.Publish(new ModelHasChangedEvent());
                }
            }
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

    }
}
