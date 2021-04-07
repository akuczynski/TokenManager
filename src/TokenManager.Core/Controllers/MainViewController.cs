using System;
using System.ComponentModel.Composition;
using TokenManager.Core.Events;

namespace TokenManager.Core.DomainServices
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
        private INotificationService _notyficationService { get; set; }
        private IPersistanceService _persistanceService { get; set; }

        [ImportingConstructor]
        public MainViewController(
            ILogger logger,
            IConfiguration configuration,
            INotificationService notyficationService,
            IPersistanceService persistanceController)
        {
            _logger = logger;
            _configuration = configuration;
            _notyficationService = notyficationService;
            _persistanceService = persistanceController;
        } 

        public void LoadData()
        {
            _logger.Info("load data");

            var rootFolderPath = _configuration.Get("RootFolder");
            _persistanceService.LoadData(rootFolderPath);

            _notyficationService.Publish(new ProjectLoadedEvent());
        }

        public void SaveData()
        {
            // TODO: call validation ?

            _logger.Info("save data");

            var rootFolderPath = _configuration.Get("RootFolder");
            _persistanceService.SaveData(rootFolderPath);

            _notyficationService.Publish(new ProjectSavedEvent());
        }

        public bool Validate()
        {
            _logger.Info("validate");

            throw new NotImplementedException();
        }
    }
}
