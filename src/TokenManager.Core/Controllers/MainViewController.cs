using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using TokenManager.Core.Events;
using TokenManager.Core.Services;
using TokenManager.Core.ViewModel;

namespace TokenManager.Core.Controllers
{
    public interface IMainViewController
    {
        void LoadData();

        bool Validate();

        void SaveData();
    }

    [Export(typeof(IMainViewController))]
    internal class MainViewController : IMainViewController
    {
        private ILogger _logger { get;  set; }
        private IConfiguration _configuration { get;  set; }
        private INotyficationService _notyficationService { get; set; }
        private IPersistanceService _persistanceService { get; set; }

        [ImportingConstructor]
        public MainViewController(
            ILogger logger,
            IConfiguration configuration,
            INotyficationService notyficationService,
            IPersistanceService persistanceController)
        {
            _logger = logger;
            _configuration = configuration;
            _notyficationService = notyficationService;
            _persistanceService = persistanceController;
        } 

        public void LoadData()
        {
            _logger.Info("Load Tokens");

            var rootFolderPath = _configuration.Get("RootFolder");
            _persistanceService.LoadData(rootFolderPath, true);
            _notyficationService.Publish(new ProjectLoadedEvent());
        }

        public void SaveData()
        {
            var rootFolderPath = _configuration.Get("MainFolderPath");
            _persistanceService.SaveData(rootFolderPath);
        }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
