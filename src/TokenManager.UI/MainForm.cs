using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using TokenManager.Core.Controllers;
using TokenManager.Core.Events;
using TokenManager.Core.Services;

namespace TokenManager
{
    public partial class MainForm : Form, TokenManager.Core.Events.IEventHandler
    {
        [Import(RequiredCreationPolicy = CreationPolicy.Shared)]
        public IMainViewController MainViewController { get; set; }

        [Import(RequiredCreationPolicy = CreationPolicy.Shared)]
        public INotyficationService NotyficationService { get; set; }

        public MainForm()
        {
            InitializeComponent();

            Shell.CompositionContainer.ComposeParts(this);

            NotyficationService.Subscribe(typeof(ModelHasChangedEvent), this);
            MainViewController.LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
         
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        void IEventHandler.Handle(IEvent @event)
        {
            if (@event is ModelHasChangedEvent)
            {
                Console.Out.Write("It works");
            }
        }
    }
}
