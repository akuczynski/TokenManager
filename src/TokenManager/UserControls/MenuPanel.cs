using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using TokenManager.Core.DomainServices;

namespace TokenManager.UserControls
{
    public partial class MenuPanel : UserControl 
    {
        [Import]
        public IMainViewController MainViewController { get; set; }

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
            FilterTxb.Text = "";
            FilterTxb.Enabled = true;
            ValidateBtn.Enabled = true;

            this.FilterTxb.TextChanged += new System.EventHandler(FilterTokenGrid);
            this.TokensCbx.CheckedChanged += new System.EventHandler(FilterTokenGrid);
            this.SubTokensCbx.CheckedChanged += new System.EventHandler(FilterTokenGrid);
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            MainViewController.LoadData();
        } 

        private void FilterTokenGrid(object sender, EventArgs e)
        {
            var showTokens = TokensCbx.Checked;
            var showSubTokens = SubTokensCbx.Checked;
            var tokenName = FilterTxb.Text.Trim();

            MainForm.FilterTokenGrid(showTokens, showSubTokens, tokenName);
        }

    }
}
