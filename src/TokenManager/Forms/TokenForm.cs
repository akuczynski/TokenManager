﻿using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;
using TokenManager.Core.DomainServices;
using TokenManager.Core.ViewModel;
using TokenManager.Properties;

namespace TokenManager.Forms
{
    public partial class TokenForm : Form
    {
        [Import]
        public ITokenEditViewController TokenEditViewController { get; set; }        

        public IMainForm MainForm { get; set; }

        private bool _isSubtoken;

        public TokenForm()
        {
            InitializeComponent();
        }

        public void Init(bool isEdit, string title, bool isSubtoken, string token)
        {
            _isSubtoken = isSubtoken;
            this.Text = title;
            EnvironmentCbx.DataSource = TokenEditViewController.GetEnvironments();

            if (!string.IsNullOrEmpty(token))
            {
                var tokenViewModel = TokenEditViewController.GetToken(token);
                PopulateFields(tokenViewModel);
            }
            
            UserNameTbx.Enabled = PasswordChk.Checked;
            AddBtn.Visible = !isEdit;
            UpdateBtn.Visible = isEdit;
            EnvironmentCbx.Enabled = !GlobalTokenChk.Checked;            

            if (isEdit)
            {
                InitForEdit();
            }
        }

        private void PopulateFields(TokenViewModel tokenViewModel)
        {
            TokenNameTbx.Text = tokenViewModel.Token;
            GlobalTokenChk.Checked = tokenViewModel.Global;            
            PasswordChk.Checked = tokenViewModel.Password;
            ValueTbx.Text = tokenViewModel.Value;
            DescriptionTbx.Text = tokenViewModel.Description;
            UserNameTbx.Text = tokenViewModel.UserName;
        }

        private void InitForEdit()
        {
            TokenNameTbx.ReadOnly = true;
            GlobalTokenChk.Enabled = false;            
            PasswordChk.Enabled = false;
            EnvironmentCbx.Hide();
            EnvironmentLbl.Hide();
            if (!PasswordChk.Checked)
            {
                UserNameTbx.Hide();
                UserNameLbl.Hide();
            }            
        }

        private void PasswordChk_CheckedChanged(object sender, System.EventArgs e)
        {
            UserNameTbx.Enabled = PasswordChk.Checked;            
        }

        private void GlobalTokenChk_CheckedChanged(object sender, System.EventArgs e)
        {
            EnvironmentCbx.Enabled = !GlobalTokenChk.Checked;
        }

        private void AddBtn_Click(object sender, System.EventArgs e)
        {
            var model = new NewTokenViewModel
            {
                Token = string.Format("##{0}##", TokenNameTbx.Text),
                IsSubtoken = _isSubtoken, 
                IsPassword = PasswordChk.Checked, 
                IsGlobal = GlobalTokenChk.Checked,
                Environment = EnvironmentCbx.Text,
                Description = DescriptionTbx.Text, 
                Value = ValueTbx.Text,
                UserName = UserNameTbx.Text
            };

            var isValid = TokenEditViewController.IsTokenNameUnique(model.Token);
            if (isValid)
            {
                TokenEditViewController.AddToken(model);
                var message = string.Format(Messages.NewToken, model.Token);
                MainForm.UpdateMessageOnStatusBar(message);

                Close();
            }
            else
            {
                MainForm.UpdateMessageOnStatusBar(Messages.TokenNameIsNotUnique);
            }
        }

        private void UpdateBtn_Click(object sender, System.EventArgs e)
        {
            var model = new UpdateTokenViewModel
            {
                Token = TokenNameTbx.Text,
                Description = DescriptionTbx.Text,
                Value = ValueTbx.Text,
                UserName = UserNameTbx.Text
            };

            TokenEditViewController.UpdateToken(model);
            var message = string.Format(Messages.UpdateToken, model.Token);
            MainForm.UpdateMessageOnStatusBar(message);

            Close();
        }
    }
}
