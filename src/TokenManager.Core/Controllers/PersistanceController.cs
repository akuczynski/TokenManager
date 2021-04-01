using System.Collections.Generic;
using System.ComponentModel.Composition;
using TokenManager.Core.Model;
using TokenManager.Core.ViewModel;

namespace TokenManager.Core.Controllers
{
    public interface IPersistanceController
    {
        void LoadData(string rootFolderPath);

        void SaveData(string rootFolderPath);
         
    }

    [Export(typeof(IPersistanceController))]
    internal class PersistanceController : IPersistanceController
    {
          private DataSource DataSource { get; set; }
         

        public void LoadData(string rootFolderPath)
        {

          //  throw new System.NotImplementedException();
        }

        public void SaveData(string rootFolderPath)
        {
            throw new System.NotImplementedException();
        } 
    }
}
