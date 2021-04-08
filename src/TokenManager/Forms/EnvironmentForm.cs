using System.ComponentModel.Composition;
using System.Windows.Forms;
using TokenManager.Core.DomainServices;
using TokenManager.Core.ViewModel;

namespace TokenManager.Forms
{
    public partial class EnvironmentForm : Form
    {
        [Import]
        public ITokenEditViewController TokenEditViewController { get; set; }

        public IMainForm MainForm { get; set; }

        public EnvironmentForm()
        {
            InitializeComponent();
        }

        public void Init(string token, string environment)
        {
            EnvironmentCbx.DataSource = TokenEditViewController.GetEnvironments();            

            
        }

        private void PopulateField(EnvironentTokenViewModel model)
        {
            EnvironmentCbx.SelectedItem = model.Environment;
            ValueTbx.Text = model.Value;
            UserNameTbx.Text = model.UserName;
            DescriptionTbx.Text = model.Description;
        }
    }
}
