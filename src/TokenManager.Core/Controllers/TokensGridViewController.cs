using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using TokenManager.Core.Events;
using TokenManager.Core.Model;
using TokenManager.Core.DomainServices;
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

            _tokens = new HashSet<TokenViewModel>();

            _notyficationService.Subscribe(typeof(ProjectLoadedEvent), this);
        }

        public IEnumerable<TokenViewModel> GetTokenList(bool showTokens, bool showSubTokens, string tokenName)
        {
            if (showSubTokens && showTokens)
            {
                return _tokens.ToList();
            }
            else if (showTokens == false && showSubTokens == true)
            {
                return _tokens.Where(x => x.IsSubToken == true).ToList();
            }
            else if (showTokens == true && showSubTokens == false)
            {
                return _tokens.Where(x => x.IsSubToken == false).ToList();
            }

            return Enumerable.Empty<TokenViewModel>();
        }

        public IEnumerable<EnvironentTokenViewModel> GetTokenValuesForAllEnvironments(string tokenName)
        {
            throw new System.NotImplementedException();
        }


        private void Init()
        {
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
