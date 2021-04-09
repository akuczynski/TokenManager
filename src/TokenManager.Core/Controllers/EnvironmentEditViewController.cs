using System.Collections.Generic;
using System.ComponentModel.Composition;
using TokenManager.Core.DomainServices;
using TokenManager.Core.ViewModel;

namespace TokenManager.Core.Controllers
{
    public interface IEnvironmentEditViewController
    {
        IEnumerable<string> GetEnvironments();

        EnvironmentTokenViewModel GetData(string token, string environment);

        void AssingValue(string token, EnvironmentTokenViewModel model);

        void RemoveAssignedValue(string token, string environment);
    }

    [Export(typeof(IEnvironmentEditViewController))]
    internal class EnvironmentEditViewController : IEnvironmentEditViewController
    {
        private ITokenManagementService _tokenManagementService;

        [ImportingConstructor]
        public EnvironmentEditViewController(ITokenManagementService tokenManagementService)
        {
            _tokenManagementService = tokenManagementService;
        }

        public void AssingValue(string token, EnvironmentTokenViewModel model)
        {
            _tokenManagementService.AssignValue(token, model);
        }

        public EnvironmentTokenViewModel GetData(string token, string environment)
        {
            return _tokenManagementService.GetTokenEnvironementValue(token, environment);
        }

        public IEnumerable<string> GetEnvironments()
        {
            return _tokenManagementService.Environments;
        }

        public void RemoveAssignedValue(string token, string environment)
        {
            throw new System.NotImplementedException();
        }
    }
}
