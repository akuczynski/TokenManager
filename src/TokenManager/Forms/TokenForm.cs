using System.ComponentModel.Composition;
using System.Windows.Forms;
using TokenManager.Core.DomainServices;

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
        }
    }
}
