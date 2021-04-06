using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace TokenManager.Core.DomainServices
{
    public interface ITokenEditViewController
    {
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

        public IEnumerable<string> GetEnvironments()
        {
            return _tokenManagementService.Environments;
        }
    }
}
