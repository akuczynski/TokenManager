using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using TokenManager.Core.Events;
using TokenManager.Core.Model;
using TokenManager.Core.ViewModel;

namespace TokenManager.Core.DomainServices
{
    public interface ITokensGridViewController
    {
        IEnumerable<TokenViewModel> GetTokenList(bool showTokens, bool showSubTokens, string tokenName);

        IEnumerable<EnvironentTokenViewModel> GetTokenValuesForAllEnvironments(string tokenName);
    }

    [Export(typeof(ITokensGridViewController))]
    internal class TokensGridViewController : ITokensGridViewController, IEventHandler
    {
        // todo: add
        private HashSet<TokenViewModel> _tokens { get; set; }

        private readonly IPersistanceService _persistanceService;

        private readonly INotyficationService _notyficationService;

        [ImportingConstructor]
        public TokensGridViewController(
            IPersistanceService persistanceService,
            INotyficationService notyficationService)
        {
            _persistanceService = persistanceService;
            _notyficationService = notyficationService; 

            _notyficationService.Subscribe(typeof(ProjectLoadedEvent), this);
        }

        public IEnumerable<TokenViewModel> GetTokenList(bool showTokens, bool showSubTokens, string tokenName)
        {
            var result = Enumerable.Empty<TokenViewModel>();

            if (showSubTokens && showTokens)
            {
                result = _tokens.ToList();
            }
            else if (showTokens == false && showSubTokens == true)
            {
                result = _tokens.Where(x => x.IsSubToken == true).ToList();
            }
            else if (showTokens == true && showSubTokens == false)
            {
                result = _tokens.Where(x => x.IsSubToken == false).ToList();
            }

            if (!string.IsNullOrEmpty(tokenName))
            {
                result = result.Where(x => x.Token.ToLower().Contains(tokenName.ToLower())).ToList();
            }

            return result;
        }

        public IEnumerable<EnvironentTokenViewModel> GetTokenValuesForAllEnvironments(string tokenName)
        {
            throw new System.NotImplementedException();
        }


        private void Init()
        {
            _tokens = new HashSet<TokenViewModel>();
            var dataSource = _persistanceService.GetData();
            foreach(var item in dataSource.EnvironmentTokens)
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


        public void Handle(IEvent appEvent)
        {
            if (appEvent is ProjectLoadedEvent)
            {
                Init();
            }
        }
    }
}
