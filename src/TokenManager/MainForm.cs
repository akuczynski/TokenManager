using System.ComponentModel.Composition;
using System.Windows.Forms;
using TokenManager.Core.DomainServices;
using TokenManager.Core.Events;

namespace TokenManager
{
    public partial class MainForm : Form, IEventHandler, IMainForm
    {
        [Import]
        public INotyficationService NotyficationService { get; set; }

        public MainForm()
        {
            InitializeComponent();

            Shell.CompositionContainer.ComposeParts(this);
            Shell.CompositionContainer.ComposeParts(this.MenuPanel);
            Shell.CompositionContainer.ComposeParts(this.TokensGrid);
            Shell.CompositionContainer.ComposeParts(this.TokenEditPanel);

            this.MenuPanel.MainForm = this;
            this.TokensGrid.MainForm = this;
            this.TokenEditPanel.MainForm = this;

            NotyficationService.Subscribe(typeof(ModelHasChangedEvent), this);
            NotyficationService.Subscribe(typeof(ProjectLoadedEvent), this);
        }          

        void IEventHandler.Handle(IEvent appEvent)
        {
            if (appEvent is ProjectLoadedEvent)
            {
                MenuPanel.Init();

                TokensGrid.ShowData(true, true, null);
            }
        }

        public void FilterTokenGrid(bool showTokens, bool showSubTokens, string tokenName)
        {
            TokensGrid.ShowData(showTokens, showSubTokens, tokenName);
        }
    }
} 