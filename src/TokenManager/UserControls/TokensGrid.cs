using System;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TokenManager.Core.DomainServices;
using TokenManager.Core.ViewModel;
using TokenManager.Miscellaneous;
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

        public void ShowData(bool showTokens, bool showSubtokens, bool onlyPasswords, bool onlyGlobal, string tokenName)
        {
            this.MainGrid.DataSource = new SortableBindingList<TokenViewModel>(
                TokensGridViewController.GetTokenList(showTokens, showSubtokens, onlyPasswords, onlyGlobal, tokenName).ToList());

            this.MainGrid.Columns["Global"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.MainGrid.Columns["Password"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.MainGrid.Columns["IsSubtoken"].Visible = false;

            this.MainGrid.Columns["Global"].SortMode = DataGridViewColumnSortMode.Automatic;
            this.MainGrid.Columns["Password"].SortMode = DataGridViewColumnSortMode.Automatic;
            UpdateRowsBackgroundColors();

            this.SubGrid.Columns["Environment"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public void ReloadSubGrid() {
            SelectDataGridRow(MainGrid.SelectedRows[0]);
        }

        private void MainGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add("Add Token", ShowAddTokenForm);
                m.MenuItems.Add("Add Subtoken", ShowAddSubtokenForm);

                if (IsAnyRowSelected(this.MainGrid))
                {
                    m.MenuItems.Add("Edit", ShowEditTokenForm);
                    m.MenuItems.Add("Remove", RemoveToken);
                    m.MenuItems.Add("-");
                    m.MenuItems.Add("Copy name", CopyTokenNameToClipboard);
                    m.MenuItems.Add("Copy xml", CopyTokenXml);
                }                

                m.Show(this.MainGrid, new Point(e.X, e.Y));
            }
        }        

        public void Select(string token)
        {
            try
            {
                MainGrid.Rows
                     .OfType<DataGridViewRow>()
                     .Where(x => (string)x.Cells[0].Value == token)
                     .ToArray()[0]
                     .Selected = true;

                SelectDataGridRow(MainGrid.SelectedRows[0]);
            }
            catch(Exception)
            {
                // it can happen when row is hidden
            }
        }

        private void SubGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();                           
                m.MenuItems.Add("Manage", ShowEnvironmentForm);
                if (IsAnyRowSelected(this.SubGrid))
                {
                    m.MenuItems.Add("Remove", RemoveEnvironmentToken); 
                }

                m.Show(this.SubGrid, new Point(e.X, e.Y));
            }
        }

        private void RemoveEnvironmentToken(object sender, EventArgs e)
        {
            var environment = GetSelectedEnvironment();
            var tokenName = GetSelectedToken();

            TokensGridViewController.RemoveTokenAssigment(tokenName, environment);
        }

        private void MainGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (MainGrid.CurrentRow == null)
                return;
            
            if (MainGrid.CurrentRow.Index != _selectedRowIndex)
            {
                SelectDataGridRow(MainGrid.CurrentRow); 
            }
        }

        private void SelectDataGridRow(DataGridViewRow row)
        {
            string tokenName = (string) row.Cells[0].Value;  
            bool isPassword = (bool)row.Cells["Password"].Value;

            this.SubGrid.DataSource = TokensGridViewController.GetTokenValuesForAllEnvironments(tokenName);
            this.SubGrid.Columns["UserName"].Visible = isPassword;
            this.SubGrid.Columns["IsPassword"].Visible = false;

            _selectedRowIndex = row.Index;

            var text = string.Format(Messages.TokenSelectionChanged, tokenName);
            MainForm.UpdateMessageOnStatusBar(text);
        }

        private void RemoveToken(object sender, EventArgs e)
        {
            var tokenName = GetSelectedToken();
            TokensGridViewController.RemoveToken(tokenName);

            var message = string.Format(Messages.TokenRemoved, tokenName);
            MainForm.UpdateMessageOnStatusBar(message);
        }

        private void ShowAddTokenForm(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            MainForm.ShowTokenModalWindow(false, menuItem.Text, false);
        }

        private void ShowAddSubtokenForm(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            MainForm.ShowTokenModalWindow(false, menuItem.Text, true);
        }

        private void ShowEditTokenForm(object sender, EventArgs e)
        {
            var tokenName = GetSelectedToken();
            var menuItem = sender as MenuItem;

            MainForm.ShowTokenModalWindow(true, menuItem.Text, token: tokenName);
        }

        private void CopyTokenNameToClipboard(object sender, EventArgs e)
        {
            Clipboard.SetText(GetSelectedToken());
        }

        private void CopyTokenXml(object sender, EventArgs e)
        {
            var xml = TokensGridViewController.GetTokenXml(GetSelectedToken());
            Clipboard.SetText(xml.ToString());
        }

        private void ShowEnvironmentForm(object sender, EventArgs e)
        {
            var token = GetSelectedToken();
            var environment = GetSelectedEnvironment();

            MainForm.ShowEnvironmentModalWindow(token, environment);
        }        

        private string GetSelectedToken()
        {
            return (string)MainGrid.SelectedRows[0].Cells[0].Value; 
        }

        private string GetSelectedEnvironment()
        {
            if (SubGrid.SelectedRows.Count == 0)
            {
                return null;
            }

            return (string)SubGrid.SelectedRows[0].Cells[0].Value;
        }

        private void UpdateRowsBackgroundColors()
        {
            foreach (DataGridViewRow row in this.MainGrid.Rows)
            {
                if ((bool)(row.Cells["IsSubtoken"].Value ?? false))
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }

        private bool IsAnyRowSelected(DataGridView grid)
        {
            return grid.SelectedRows.Count > 0;
        }
    }
}
