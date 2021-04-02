using System.ComponentModel.Composition;
using System.Windows.Forms;
using TokenManager.Core.Controllers;

namespace TokenManager.UserControls
{
    public partial class TokensGrid : UserControl
    {
        [Import]
        public ITokensGridViewController TokensGridViewController { get; set; }
         
        public TokensGrid()
        {
            InitializeComponent();
            Shell.CompositionContainer.ComposeParts(this);
        }

        public void ShowData(bool showTokens,bool showSubTokens)
        {
            this.MainGrid.DataSource = TokensGridViewController.GetTokenList(showTokens, showSubTokens, "");
        }

    }
}
