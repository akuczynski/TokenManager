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

        private HashSet<TokenViewModel> Tokens { get; set; }

        private HashSet<EnvironentTokenViewModel> EnvironmentTokens { get; set; }


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
            throw new NotImplementedException();
        }

        public void LoadData()
        {
            _logger.Info("Load Data");
            _notyficationService.Publish(new ModelHasChangedEvent());

            var rootFolderPath = _configuration.Get("MainFolderPath");
            _persistanceController.LoadData(rootFolderPath);
        }

        public void SaveData()
        {
            var rootFolderPath = _configuration.Get("MainFolderPath");
            _persistanceController.SaveData(rootFolderPath);
        }
    }
}
