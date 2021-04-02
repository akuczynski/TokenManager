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

        void SaveData();

        IEnumerable<TokenViewModel> Filter(string tokenKey);

        IEnumerable<TokenViewModel> ShowData(bool showTokens, bool showSubTokens);
    }

    [Export(typeof(IMainViewController))]
    internal class MainViewController : IMainViewController
    {
        private ILogger _logger { get;  set; }
        private IConfiguration _configuration { get;  set; }
        private INotyficationService _notyficationService { get; set; }
        private IPersistanceController _persistanceController { get; set; }

        [ImportingConstructor]
        public MainViewController(
            ILogger logger,
            IConfiguration configuration,
            INotyficationService notyficationService,
            IPersistanceController persistanceController)
        {
            _logger = logger;
            _configuration = configuration;
            _notyficationService = notyficationService;
            _persistanceController = persistanceController;
        }

        public IEnumerable<TokenViewModel> Filter(string tokenKey)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TokenViewModel> ShowData(bool showTokens, bool showSubTokens)
        {
            _logger.Info("Display Tokens");

            return _persistanceController.ViewData(showTokens, showSubTokens);
        }

        public void LoadData()
        {
            _logger.Info("Load Tokens");

            var rootFolderPath = _configuration.Get("RootFolder");
            _persistanceController.LoadData(rootFolderPath, true);
            _notyficationService.Publish(new ProjectLoadedEvent());
        }

        public void SaveData()
        {
            var rootFolderPath = _configuration.Get("MainFolderPath");
            _persistanceController.SaveData(rootFolderPath);
        }
    }
}
