using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenManager.Core.DomainServices
{
    public interface ITokenManagementService
    {
        void AddToken();

        void UpdateToken();
    }

    [Export(typeof(ITokenManagementService))]
    internal class TokenManagementService : ITokenManagementService
    {
        public void AddToken()
        {
            throw new NotImplementedException();
        }

        public void UpdateToken()
        {
            throw new NotImplementedException();
        }
    }
}
