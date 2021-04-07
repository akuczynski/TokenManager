﻿using System.ComponentModel.Composition;
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
            TokenNameTbx.Text = token ?? string.Empty;
            TokenNameTbx.Enabled = !isEdit;
            UserNameTbx.Enabled = PasswordChk.Checked;
            EnvironmentCbx.Enabled = GlobalTokenChk.Checked;
        }

        private void PasswordChk_CheckedChanged(object sender, System.EventArgs e)
        {
            UserNameTbx.Enabled = PasswordChk.Checked;            
        }

        private void GlobalTokenChk_CheckedChanged(object sender, System.EventArgs e)
        {
            EnvironmentCbx.Enabled = GlobalTokenChk.Checked;
        }
    }
}