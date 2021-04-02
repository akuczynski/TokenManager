using System.ComponentModel.Composition;
using System.Windows.Forms;
using TokenManager.Core.DomainServices;

namespace TokenManager.UserControls
{
    public partial class TokensGrid : UserControl
    {
        [Import]
        public ITokensGridViewController TokensGridViewController { get; set; }
         
        public TokensGrid()
        {
            InitializeComponent();
        }

        public void ShowData(bool showTokens,bool showSubTokens)
        {
            this.MainGrid.DataSource = TokensGridViewController.GetTokenList(showTokens, showSubTokens, "");
        }

    }
}
