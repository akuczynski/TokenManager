using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TokenManager.Core.DomainServices;
using TokenManager.Core.Events;
using TokenManager.Core.DomainServices;

namespace TokenManager
{
    public partial class MainForm : Form, IEventHandler
    {
        [Import]
        public IMainViewController MainViewController { get; set; }

        [Import]
        public INotyficationService NotyficationService { get; set; }

        public MainForm()
        {
            InitializeComponent();
            Shell.CompositionContainer.ComposeParts(this);

            NotyficationService.Subscribe(typeof(ModelHasChangedEvent), this);
            NotyficationService.Subscribe(typeof(ProjectLoadedEvent), this);
        }
         

        void IEventHandler.Handle(IEvent appEvent)
        {
            if (appEvent is ProjectLoadedEvent)
            {
                TokensGrid.ShowData(true, true);
            }
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            MainViewController.LoadData();
        }
    }
} 