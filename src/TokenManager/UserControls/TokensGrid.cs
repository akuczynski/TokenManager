using System;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;
using TokenManager.Core.DomainServices;
using TokenManager.Core.ViewModel;
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
            this.MainGrid.Columns[nameof(TokenViewModel.IsSubToken)].Visible = false;
            this.MainGrid.Columns[nameof(TokenViewModel.Description)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;            
            MakeSubtokensGray();

            this.SubGrid.Columns[nameof(EnvironentTokenViewModel.Environment)].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void MainGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Edit"));
                m.MenuItems.Add(new MenuItem("Remove"));
                m.MenuItems.Add(new MenuItem("Create"));                

                m.Show(this.MainGrid, new Point(e.X, e.Y));

            }
        }

        private void MainGrid_SelectionChanged(object sender, EventArgs e)
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

        private void MakeSubtokensGray()
        {
            foreach (DataGridViewRow row in this.MainGrid.Rows)
            {
                if ((bool)row.Cells[nameof(TokenViewModel.IsSubToken)].Value)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }
    }
}
