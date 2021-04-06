using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using TokenManager.Core.Events;
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
        private readonly INotyficationService _notyficationService;

        private readonly ITokenManagementService _tokenManagementService;

        [ImportingConstructor]
        public TokensGridViewController(
            ITokenManagementService tokenManagementService,
            INotyficationService notyficationService)
        {
            _notyficationService = notyficationService;
            _tokenManagementService = tokenManagementService;

            _notyficationService.Subscribe(typeof(ProjectLoadedEvent), this);
        }

        public IEnumerable<TokenViewModel> GetTokenList(bool showTokens, bool showSubTokens, string tokenName)
        {
            var result = Enumerable.Empty<TokenViewModel>();

            if (showSubTokens && showTokens)
            {
                result = _tokenManagementService.Tokens.ToList();
            }
            else if (showTokens == false && showSubTokens == true)
            {
                result = _tokenManagementService.Tokens.Where(x => x.IsSubToken == true).ToList();
            }
            else if (showTokens == true && showSubTokens == false)
            {
                result = _tokenManagementService.Tokens.Where(x => x.IsSubToken == false).ToList();
            }

            if (!string.IsNullOrEmpty(tokenName))
            {
                result = result.Where(x => x.Token.ToLower().Contains(tokenName.ToLower())).ToList();
            }

            return result.OrderBy(token => token.IsSubToken).ToList(); 
        }

        public IEnumerable<EnvironentTokenViewModel> GetTokenValuesForAllEnvironments(string tokenName)
        {
            return _tokenManagementService.GetTokenValuesForAllEnvironments(tokenName);
        } 

        public void Handle(IEvent appEvent)
        {
            if (appEvent is ProjectLoadedEvent)
            {
                _tokenManagementService.Init();
            }
        }
    }
}
