using System.ComponentModel.Composition;

namespace TokenManager.Core.Controllers
{
    public interface IEnvironmentEditViewController
    {

    }

    [Export(typeof(IEnvironmentEditViewController))]
    class EnvironmentEditViewController
    {
       

    }
}
