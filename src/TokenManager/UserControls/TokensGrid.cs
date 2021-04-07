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

        public void ShowData(bool showTokens, bool showSubTokens, bool onlyPasswords, string tokenName)
        {
            this.MainGrid.DataSource = TokensGridViewController.GetTokenList(showTokens, showSubTokens, onlyPasswords, tokenName);
            this.MainGrid.Columns[nameof(TokenViewModel.Global)].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.MainGrid.Columns[nameof(TokenViewModel.Password)].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.MainGrid.Columns[nameof(TokenViewModel.IsSubToken)].Visible = false;
            UpdateRowsBackgroundColors();

            this.SubGrid.Columns[nameof(EnvironentTokenViewModel.Environment)].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void MainGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add("Add", ShowModalWindow);
                m.MenuItems.Add("Edit", ShowModalWindow);
                m.MenuItems.Add("Remove", RemoveToken);

                m.Show(this.MainGrid, new Point(e.X, e.Y));
            }
        }

        private void RemoveToken(object sender, EventArgs e)
        {
            var tokenName = GetSelectedToken();
            TokensGridViewController.RemoveToken(tokenName);

            var message = string.Format(Messages.TokenRemoved, tokenName);
            MainForm.UpdateMessageOnStatusBar(message);
        }

        private void ShowModalWindow(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var tokenName = GetSelectedToken();
            if ("Add".Equals(menuItem?.Text))
            {
                MainForm.ShowTokenModalWindow(false);
            }
            else
            {
                MainForm.ShowTokenModalWindow(true, tokenName);
            }

        }

        private void MainGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (MainGrid.CurrentRow.Index != _selectedRowIndex)
            {
                string tokenName = GetSelectedToken();
                bool isPassword = (bool)MainGrid.CurrentRow.Cells[nameof(TokenViewModel.Password)].Value;

                this.SubGrid.DataSource = TokensGridViewController.GetTokenValuesForAllEnvironments(tokenName);
                this.SubGrid.Columns[nameof(EnvironentTokenViewModel.UserName)].Visible = isPassword;

                _selectedRowIndex = MainGrid.CurrentRow.Index;

                var text = string.Format(Messages.TokenSelectionChanged, tokenName);
                MainForm.UpdateMessageOnStatusBar(text);
            }
        }

        private string GetSelectedToken()
        {
            return (string)MainGrid.CurrentRow.Cells[0]?.Value;
        }

        private void UpdateRowsBackgroundColors()
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
