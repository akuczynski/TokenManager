using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using TokenManager.Core.Model;
using TokenManager.Core.ViewModel;

namespace TokenManager.Core.Controllers
{
    public interface ITokensGridViewController
    {
        IEnumerable<TokenViewModel> GetTokenList(bool showTokens, bool showSubTokens, string tokenName);

        // todo: add env token list 
    }

    [Export(typeof(ITokensGridViewController))]
    internal class TokensGridViewController : ITokensGridViewController
    {
        // todo: add
        private HashSet<TokenViewModel> _tokens { get; set; }

        private IPersistanceService _persistanceService { get; set; }

        [ImportingConstructor]
        public TokensGridViewController(IPersistanceService persistanceService)
        {
            _persistanceService = persistanceService;
            _tokens = new HashSet<TokenViewModel>();
        }

        private void FillTokensSet()
        {
            var dataSource = _persistanceService.GetData();
            foreach(var item in dataSource.EnvironmentTokens)
            {
                AddToTokensSet(item.Value);
            }           
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

        public IEnumerable<TokenViewModel> GetTokenList(bool showTokens, bool showSubTokens, string tokenName)
        {
            if (_tokens.Count == 0)
                FillTokensSet();

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
    }
}
