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

        public MenuPanel()
        {
            InitializeComponent();
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            MainViewController.LoadData();
        }
    }
}
