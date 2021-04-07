using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using TokenManager.Core.Events;
using TokenManager.Core.Model;
using TokenManager.Core.ViewModel;

namespace TokenManager.Core.DomainServices
{
    public interface ITokenManagementService
    {
        void AddToken(NewTokenViewModel newToken);

        void UpdateToken(UpdateTokenViewModel updateToken);

        void RemoveToken(string tokenName);

        //TODO: maybe move this to different class ?! 
        IEnumerable<EnvironentTokenViewModel> GetTokenValuesForAllEnvironments(string tokenName);
        void Init();

        IEnumerable<TokenViewModel> Tokens { get; }

        IEnumerable<string> Environments { get; }

        bool IsTokenNameUnique(string tokenName);
        TokenViewModel GetToken(string tokenName);
    }

    [Export(typeof(ITokenManagementService))]
    internal class TokenManagementService : ITokenManagementService, System.IDisposable
    {
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

        public TokenViewModel GetToken(string tokenName)
        {
            return Tokens.First(token => token.Token.Equals(tokenName));
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

            var dataSource = _persistanceService.DataSource;
            var environemt = (newToken.IsGlobal) ? dataSource.RootEnvironment : dataSource.GetEnvironment(newToken.Environment);

            dataSource.AddToken(token, environemt);
        }

        public void UpdateToken(UpdateTokenViewModel updateToken)
        {
            var dataSource = _persistanceService.DataSource;
            var token = dataSource.GetToken(updateToken.Token, dataSource.RootEnvironment);
            token.Value = updateToken.Value;
            token.Description = updateToken.Description;
            token.UserName = updateToken.UserName;
           
            dataSource.UpdateToken(token);
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
        } 

        public void RemoveToken(string tokenName)
        {
            _persistanceService.DataSource.RemoveToken(tokenName);
        }

        public void Dispose()
        {
            _persistanceService.DataSource.ModelChanged -= OnModelChanged;
        }

        private void OnModelChanged(Token token, Action action, bool isGlobal)
        {
            if (action == Action.Delete)
            {
                var tokenViewModel = _tokens.SingleOrDefault(x => x.Token.Equals(token.Key));
                if (tokenViewModel != null)
                {
                    _tokens.Remove(tokenViewModel);
                    _notificationService.Publish(new ModelHasChangedEvent());
                }
            }
            else if (action == Action.Insert)
            {
                AddToTokensSet(new[] { token }, isGlobal);
                _notificationService.Publish(new ModelHasChangedEvent());
                _notificationService.Publish(new SelectTokenEvent() { Token = token.Key });
            }
            else if (action == Action.Update)
            {
                var tokenViewModel = _tokens.SingleOrDefault(x => x.Token.Equals(token.Key));
                if (tokenViewModel != null)
                {
                    tokenViewModel.Value = token.Value;
                    tokenViewModel.Description = token.Description;
                    tokenViewModel.UserName = token.UserName; 

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
                tokenViewModel.UserName = (isGlobal) ? token.UserName : "";
                tokenViewModel.IsSubToken = token.IsSubToken;
                tokenViewModel.Password = token.IsPassword; 
                tokenViewModel.Global = isGlobal;

                _tokens.Add(tokenViewModel);
            }
        }

        public bool IsTokenNameUnique(string tokenName)
        {
            return !_tokens.Where(x => x.Token.Equals(tokenName)).Any();
        }      
    }
}
