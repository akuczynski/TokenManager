using System.Collections.Generic;
using System.ComponentModel.Composition;
using TokenManager.Core.ViewModel;

namespace TokenManager.Core.DomainServices
{
    public interface ITokenEditViewController
    {
        void AddToken(NewTokenViewModel newToken);

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
    }
}
