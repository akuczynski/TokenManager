
namespace TokenManager.Forms
{
    partial class TokenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EnvironmentCbx = new System.Windows.Forms.ComboBox();
            this.UserNameTbx = new System.Windows.Forms.TextBox();
            this.descriptionTbx = new System.Windows.Forms.TextBox();
            this.valueTbx = new System.Windows.Forms.TextBox();
            this.GlobalTokenChk = new System.Windows.Forms.CheckBox();
            this.PasswordChk = new System.Windows.Forms.CheckBox();
            this.userNameLbl = new System.Windows.Forms.Label();
            this.descriptionLbl = new System.Windows.Forms.Label();
            this.ValueLbl = new System.Windows.Forms.Label();
            this.EnvironmentLbl = new System.Windows.Forms.Label();
            this.TokenNameLbl = new System.Windows.Forms.Label();
            this.subTokenChk = new System.Windows.Forms.CheckBox();
            this.TokenNameTbx = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EnvironmentCbx
            // 
            this.EnvironmentCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EnvironmentCbx.FormattingEnabled = true;
            this.EnvironmentCbx.Location = new System.Drawing.Point(137, 80);
            this.EnvironmentCbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EnvironmentCbx.Name = "EnvironmentCbx";
            this.EnvironmentCbx.Size = new System.Drawing.Size(330, 24);
            this.EnvironmentCbx.TabIndex = 27;
            // 
            // userNameTbx
            // 
            this.UserNameTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserNameTbx.Location = new System.Drawing.Point(137, 210);
            this.UserNameTbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserNameTbx.Name = "userNameTbx";
            this.UserNameTbx.Size = new System.Drawing.Size(521, 22);
            this.UserNameTbx.TabIndex = 26;
            // 
            // descriptionTbx
            // 
            this.descriptionTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTbx.Location = new System.Drawing.Point(137, 167);
            this.descriptionTbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.descriptionTbx.Name = "descriptionTbx";
            this.descriptionTbx.Size = new System.Drawing.Size(521, 22);
            this.descriptionTbx.TabIndex = 25;
            // 
            // valueTbx
            // 
            this.valueTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valueTbx.Location = new System.Drawing.Point(137, 124);
            this.valueTbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.valueTbx.Name = "valueTbx";
            this.valueTbx.Size = new System.Drawing.Size(521, 22);
            this.valueTbx.TabIndex = 24;
            // 
            // globalTokenChk
            // 
            this.GlobalTokenChk.AutoSize = true;
            this.GlobalTokenChk.Checked = true;
            this.GlobalTokenChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GlobalTokenChk.Location = new System.Drawing.Point(137, 43);
            this.GlobalTokenChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GlobalTokenChk.Name = "globalTokenChk";
            this.GlobalTokenChk.Size = new System.Drawing.Size(115, 21);
            this.GlobalTokenChk.TabIndex = 23;
            this.GlobalTokenChk.Text = "Global Token";
            this.GlobalTokenChk.UseVisualStyleBackColor = true;
            this.GlobalTokenChk.CheckedChanged += new System.EventHandler(this.GlobalTokenChk_CheckedChanged);
            // 
            // passwordChk
            // 
            this.PasswordChk.AutoSize = true;
            this.PasswordChk.Location = new System.Drawing.Point(409, 43);
            this.PasswordChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PasswordChk.Name = "passwordChk";
            this.PasswordChk.Size = new System.Drawing.Size(91, 21);
            this.PasswordChk.TabIndex = 22;
            this.PasswordChk.Text = "Password";
            this.PasswordChk.UseVisualStyleBackColor = true;
            this.PasswordChk.CheckedChanged += new System.EventHandler(this.PasswordChk_CheckedChanged);
            // 
            // userNameLbl
            // 
            this.userNameLbl.AutoSize = true;
            this.userNameLbl.Location = new System.Drawing.Point(8, 209);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(75, 17);
            this.userNameLbl.TabIndex = 21;
            this.userNameLbl.Text = "UserName";
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Location = new System.Drawing.Point(8, 166);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(79, 17);
            this.descriptionLbl.TabIndex = 20;
            this.descriptionLbl.Text = "Description";
            // 
            // ValueLbl
            // 
            this.ValueLbl.AutoSize = true;
            this.ValueLbl.Location = new System.Drawing.Point(8, 123);
            this.ValueLbl.Name = "ValueLbl";
            this.ValueLbl.Size = new System.Drawing.Size(44, 17);
            this.ValueLbl.TabIndex = 19;
            this.ValueLbl.Text = "Value";
            // 
            // DefinedInLbl
            // 
            this.EnvironmentLbl.AutoSize = true;
            this.EnvironmentLbl.Location = new System.Drawing.Point(8, 80);
            this.EnvironmentLbl.Name = "DefinedInLbl";
            this.EnvironmentLbl.Size = new System.Drawing.Size(72, 17);
            this.EnvironmentLbl.TabIndex = 18;
            this.EnvironmentLbl.Text = "Defined in";
            // 
            // TokenNameLbl
            // 
            this.TokenNameLbl.AutoSize = true;
            this.TokenNameLbl.Location = new System.Drawing.Point(8, 14);
            this.TokenNameLbl.Name = "TokenNameLbl";
            this.TokenNameLbl.Size = new System.Drawing.Size(85, 17);
            this.TokenNameLbl.TabIndex = 17;
            this.TokenNameLbl.Text = "TokenName";
            // 
            // subTokenChk
            // 
            this.subTokenChk.AutoSize = true;
            this.subTokenChk.Location = new System.Drawing.Point(283, 43);
            this.subTokenChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.subTokenChk.Name = "subTokenChk";
            this.subTokenChk.Size = new System.Drawing.Size(95, 21);
            this.subTokenChk.TabIndex = 16;
            this.subTokenChk.Text = "SubToken";
            this.subTokenChk.UseVisualStyleBackColor = true;
            // 
            // tokenNameTbx
            // 
            this.TokenNameTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TokenNameTbx.Location = new System.Drawing.Point(137, 14);
            this.TokenNameTbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TokenNameTbx.Name = "tokenNameTbx";
            this.TokenNameTbx.Size = new System.Drawing.Size(521, 22);
            this.TokenNameTbx.TabIndex = 15;
            // 
            // submitButton
            // 
            this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submitButton.Location = new System.Drawing.Point(538, 267);
            this.submitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(120, 36);
            this.submitButton.TabIndex = 14;
            this.submitButton.Text = "Add";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // TokenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 314);
            this.Controls.Add(this.EnvironmentCbx);
            this.Controls.Add(this.UserNameTbx);
            this.Controls.Add(this.descriptionTbx);
            this.Controls.Add(this.valueTbx);
            this.Controls.Add(this.GlobalTokenChk);
            this.Controls.Add(this.PasswordChk);
            this.Controls.Add(this.userNameLbl);
            this.Controls.Add(this.descriptionLbl);
            this.Controls.Add(this.ValueLbl);
            this.Controls.Add(this.EnvironmentLbl);
            this.Controls.Add(this.TokenNameLbl);
            this.Controls.Add(this.subTokenChk);
            this.Controls.Add(this.TokenNameTbx);
            this.Controls.Add(this.submitButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TokenForm";
            this.Text = "Add new Token";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox EnvironmentCbx;
        private System.Windows.Forms.TextBox UserNameTbx;
        private System.Windows.Forms.TextBox descriptionTbx;
        private System.Windows.Forms.TextBox valueTbx;
        private System.Windows.Forms.CheckBox GlobalTokenChk;
        private System.Windows.Forms.CheckBox PasswordChk;
        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.Label descriptionLbl;
        private System.Windows.Forms.Label ValueLbl;
        private System.Windows.Forms.Label EnvironmentLbl;
        private System.Windows.Forms.Label TokenNameLbl;
        private System.Windows.Forms.CheckBox subTokenChk;
        private System.Windows.Forms.TextBox TokenNameTbx;
        private System.Windows.Forms.Button submitButton;
    }
}