using System.Collections.Generic;
using System.ComponentModel.Composition;
using TokenManager.Core.ViewModel;

namespace TokenManager.Core.DomainServices
{
    public interface ITokenEditViewController
    {
        bool IsTokenNameUnique(string tokenName);

        void AddToken(NewTokenViewModel newToken);

        void UpdateToken(UpdateTokenViewModel updateToken);

        IEnumerable<string> GetEnvironments();
    }

    [Export(typeof(ITokenEditViewController))]
    internal class TokenEditViewController : ITokenEditViewController
    {
        private ITokenManagementService _tokenManagementService;

        [ImportingConstructor]
        public TokenEditViewController(ITokenManagementService tokenManagementService)
        {
            _tokenManagementService = tokenManagementService;
        }

        public void AddToken(NewTokenViewModel newToken)
        {
            _tokenManagementService.AddToken(newToken);
        }

        public IEnumerable<string> GetEnvironments()
        {
            return _tokenManagementService.Environments;
        }

        public bool IsTokenNameUnique(string tokenName)
        {
            var name = tokenName.Trim();
            return _tokenManagementService.IsTokenNameUnique(name);
        }

        public void UpdateToken(UpdateTokenViewModel updateToken)
        {
            _tokenManagementService.UpdateToken(updateToken);
        }
    }
}
