using System.ComponentModel.Composition;
using System.Windows.Forms;
using TokenManager.Core.DomainServices;
using TokenManager.Core.ViewModel;

namespace TokenManager.Forms
{
    public partial class TokenForm : Form
    {
        [Import]
        public ITokenEditViewController TokenEditViewController { get; set; }

        public IMainForm MainForm { get; set; }

        public TokenForm()
        {
            InitializeComponent();
        }

        public void Init(bool isEdit, string token)
        {
            EnvironmentCbx.DataSource = TokenEditViewController.GetEnvironments();
            TokenNameTbx.Text = token ?? string.Empty;
            TokenNameTbx.Enabled = !isEdit;
            UserNameTbx.Enabled = PasswordChk.Checked;
            EnvironmentCbx.Enabled = GlobalTokenChk.Checked;

            AddBtn.Visible = !isEdit;
            UpdateBtn.Visible = isEdit;
        }

        private void PasswordChk_CheckedChanged(object sender, System.EventArgs e)
        {
            UserNameTbx.Enabled = PasswordChk.Checked;            
        }

        private void GlobalTokenChk_CheckedChanged(object sender, System.EventArgs e)
        {
            EnvironmentCbx.Enabled = GlobalTokenChk.Checked;
        }

        private void AddBtn_Click(object sender, System.EventArgs e)
        {
            var model = new NewTokenViewModel
            {
                Token = TokenNameTbx.Text,
                IsSubToken = SubTokenChk.Checked, 
                IsPassword = PasswordChk.Checked, 
                IsGlobal = GlobalTokenChk.Checked,
                Environment = EnvironmentCbx.Text,
                Description = DescriptionTbx.Text, 
                Value = ValueTbx.Text,
                UserName = UserNameTbx.Text
            };

            TokenEditViewController.AddToken(model); 
        }

        private void UpdateBtn_Click(object sender, System.EventArgs e)
        {

        }
    }
}
