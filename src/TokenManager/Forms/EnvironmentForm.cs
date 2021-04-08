using System.ComponentModel.Composition;
using System.Windows.Forms;
using TokenManager.Core.Controllers;
using TokenManager.Core.ViewModel;

namespace TokenManager.Forms
{
    public partial class EnvironmentForm : Form
    {
        [Import]
        public IEnvironmentEditViewController EnvironmentEditViewController { get; set; }

        public IMainForm MainForm { get; set; }

        private string _token;

        public EnvironmentForm()
        {
            InitializeComponent();
        }

        public void Init(string token, string environment)
        {
            _token = token;

            EnvironmentCbx.DataSource = EnvironmentEditViewController.GetEnvironments();            
            if (!string.IsNullOrEmpty(environment))
            {
                int index = EnvironmentCbx.FindString(environment);
                EnvironmentCbx.SelectedIndex = index; 
            }

            EnvironmentCbx_SelectionChanged(null, null);
            EnvironmentCbx.SelectedIndexChanged += EnvironmentCbx_SelectionChanged;
        }

        private void EnvironmentCbx_SelectionChanged(object sender, System.EventArgs e)
        {
            var selectedEnvironment = GetSelectedEnvironment();
            var model = EnvironmentEditViewController.GetData(_token, selectedEnvironment);
            PopulateField(model);
        }

        private void PopulateField(EnvironmentTokenViewModel model)
        {
            if (model == null)
            {
                return;
            }

            ValueTbx.Text = model.Value;
            if (!model.IsPassword)
            {
                UserNameLbl.Visible = false;
                UserNameTbx.Visible = false;
            }
            else
            {
                UserNameTbx.Text = model.UserName;
            }
            
            DescriptionTbx.Text = model.Description;
        }

        private void AssignBtn_Click(object sender, System.EventArgs e)
        {
            var model = new EnvironmentTokenViewModel
            {
                Value = ValueTbx.Text,
                Environment = GetSelectedEnvironment(),
                UserName = UserNameTbx.Text, 
                Description = DescriptionTbx.Text
            };

            EnvironmentEditViewController.AssingValue(_token, model);
            Close();
        }

        private string GetSelectedEnvironment()
        {
            return (string)EnvironmentCbx.SelectedValue;
        }
    }
}
