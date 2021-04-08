using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using TokenManager.Core.DomainServices;
using TokenManager.Core.Events;
using TokenManager.Properties;

namespace TokenManager.UserControls
{
    public partial class MenuPanel : UserControl , IEventHandler
    {
        [Import]
        public IMainViewController MainViewController { get; set; }

        [Import]
        INotificationService NotificationService { get; set; }

        public IMainForm MainForm { get; set; }

        public MenuPanel()
        {
            InitializeComponent();
        }
        
        public void Init()
        {
            TokensCbx.Checked = true;
            TokensCbx.Enabled = true;
            SubTokensCbx.Checked = true;
            SubTokensCbx.Enabled = true;
            PasswordCbx.Enabled = true;
            GlobalCbx.Enabled = true;
            FilterTxb.Text = "";
            FilterTxb.Enabled = true;
            ValidateBtn.Enabled = true;
            SaveBtn.Enabled = false;

            this.FilterTxb.TextChanged += new System.EventHandler(FilterTokenGrid);
            this.TokensCbx.CheckedChanged += new System.EventHandler(FilterTokenGrid);
            this.SubTokensCbx.CheckedChanged += new System.EventHandler(FilterTokenGrid);
            this.PasswordCbx.CheckedChanged += new System.EventHandler(FilterTokenGrid);
            this.GlobalCbx.CheckedChanged += new System.EventHandler(FilterTokenGrid);            

            NotificationService.Subscribe(typeof(ModelHasChangedEvent), this);
            NotificationService.Subscribe(typeof(TokenValueAssignChangedEvent), this);
            NotificationService.Subscribe(typeof(ProjectSavedEvent), this);
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            MainViewController.LoadData();
        } 

        public void ReloadTokenGrid()
        {
            FilterTokenGrid(null, null);
        }

        private void FilterTokenGrid(object sender, EventArgs e)
        {
            var showTokens = TokensCbx.Checked;
            var showSubTokens = SubTokensCbx.Checked;
            var onlyPasswords = PasswordCbx.Checked;
            var onlyGlobal = GlobalCbx.Checked;
            var tokenName = FilterTxb.Text.Trim();

            MainForm.FilterTokenGrid(showTokens, showSubTokens, onlyPasswords, onlyGlobal, tokenName);
        }

        void IEventHandler.Handle(IEvent appEvent)
        {
            if (appEvent is ModelHasChangedEvent || appEvent is TokenValueAssignChangedEvent)
            {
                SaveBtn.Enabled = true;
            }
            else if (appEvent is ProjectSavedEvent)
            {
                SaveBtn.Enabled = false;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            MainViewController.SaveData();
        }

        private void ValidateBtn_Click(object sender, EventArgs e)
        {
            var result = MainViewController.Validate();
            if (result.IsValid)
            {
                MainForm.UpdateMessageOnStatusBar(Messages.ProjectIsValid);
                MessageBox.Show(Messages.ValidationSucceded, Messages.ValidationResults, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MainForm.UpdateMessageOnStatusBar(Messages.ProjectIsInvalid);
                MessageBox.Show(result.Message, Messages.ValidationResults,  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
