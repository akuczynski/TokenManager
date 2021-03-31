using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace TokenManager.Core.Controllers
{
    public interface IMainViewController
    {
        void ShowList();
    }

    [Export(typeof(IMainViewController))]
    internal class MainViewController : IMainViewController
    {
        public void ShowList()
        { 
            throw new NotImplementedException();
        }
    }
}
