using System.ComponentModel.Composition;
using System.Windows.Forms;
using TokenManager.Core.DomainServices;
using TokenManager.Properties;

namespace TokenManager.UserControls
{
    public partial class TokensGrid : UserControl
    {
        [Import]
        public ITokensGridViewController TokensGridViewController { get; set; }

        public IMainForm MainForm { get; set; }

        private int _selectedRowIndex = -1;
        
        public TokensGrid()
        {
            InitializeComponent();
        }

        public void ShowData(bool showTokens,bool showSubTokens, string tokenName)
        {
            this.MainGrid.DataSource = TokensGridViewController.GetTokenList(showTokens, showSubTokens, tokenName);
        }

        private void MainGrid_SelectionChanged(object sender, System.EventArgs e)
        {
            if (MainGrid.CurrentRow.Index != _selectedRowIndex)
            {
                string tokenName = (string)MainGrid.CurrentRow.Cells[0]?.Value;
                this.SubGrid.DataSource = TokensGridViewController.GetTokenValuesForAllEnvironments(tokenName);

                _selectedRowIndex = MainGrid.CurrentRow.Index;

                var text = string.Format(Messages.TokenSelectionChanged, tokenName);
                MainForm.UpdateMessageOnStatusBar(text);
            }
        }
    }
}
