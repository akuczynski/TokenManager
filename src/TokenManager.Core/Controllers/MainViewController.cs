using System;
using System.ComponentModel.Composition;
using TokenManager.Core.Events;
using TokenManager.Core.Validation;

namespace TokenManager.Core.DomainServices
{
    public interface IMainViewController
    {
        void LoadData();

        ValidationResult Validate();

        void SaveData();

        bool HasUnsavedChanges();
    }

    [Export(typeof(IMainViewController))]
    internal class MainViewController : IMainViewController
    {
        private ILogger _logger { get;  set; }
        private IConfiguration _configuration { get;  set; }
        private INotificationService _notyficationService { get; set; }
        private IPersistanceService _persistanceService { get; set; }

        private IValidationService _validationService;

        [ImportingConstructor]
        public MainViewController(
            ILogger logger,
            IConfiguration configuration,
            INotificationService notyficationService,
            IPersistanceService persistanceService,
            IValidationService validationService)
        {
            _logger = logger;
            _configuration = configuration;
            _notyficationService = notyficationService;
            _persistanceService = persistanceService;
            _validationService = validationService;
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
            _logger.Info("save data");

            var validationResult = Validate();
            if (validationResult.IsValid)
            {
                var rootFolderPath = _configuration.Get("RootFolder");
                _persistanceService.SaveData(rootFolderPath);

                _notyficationService.Publish(new ProjectSavedEvent());
            }
            else
            {
                _notyficationService.Publish(new ProjectIsInvalidEvent());
            }
        }

        public ValidationResult Validate()
        {
            _logger.Info("validate");

            return _validationService.Validate(_persistanceService.DataSource);
        }

        public bool HasUnsavedChanges()
        {
            if (_persistanceService.DataSource == null)
            {
                return false;
            }

            return (_persistanceService.DataSource.IsDirty);
        }
    }
}
