
using TokenManager.Properties;

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
            this.DescriptionTbx = new System.Windows.Forms.TextBox();
            this.ValueTbx = new System.Windows.Forms.TextBox();
            this.GlobalTokenChk = new System.Windows.Forms.CheckBox();
            this.PasswordChk = new System.Windows.Forms.CheckBox();
            this.UserNameLbl = new System.Windows.Forms.Label();
            this.DescriptionLbl = new System.Windows.Forms.Label();
            this.ValueLbl = new System.Windows.Forms.Label();
            this.EnvironmentLbl = new System.Windows.Forms.Label();
            this.TokenNameLbl = new System.Windows.Forms.Label();
            this.SubTokenChk = new System.Windows.Forms.CheckBox();
            this.TokenNameTbx = new System.Windows.Forms.TextBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
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
            this.EnvironmentCbx.Size = new System.Drawing.Size(329, 24);
            this.EnvironmentCbx.TabIndex = 27;
            // 
            // UserNameTbx
            // 
            this.UserNameTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserNameTbx.Location = new System.Drawing.Point(137, 210);
            this.UserNameTbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserNameTbx.Name = "UserNameTbx";
            this.UserNameTbx.Size = new System.Drawing.Size(521, 22);
            this.UserNameTbx.TabIndex = 26;
            // 
            // DescriptionTbx
            // 
            this.DescriptionTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionTbx.Location = new System.Drawing.Point(137, 167);
            this.DescriptionTbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DescriptionTbx.Name = "DescriptionTbx";
            this.DescriptionTbx.Size = new System.Drawing.Size(521, 22);
            this.DescriptionTbx.TabIndex = 25;
            // 
            // ValueTbx
            // 
            this.ValueTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueTbx.Location = new System.Drawing.Point(137, 124);
            this.ValueTbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ValueTbx.Name = "ValueTbx";
            this.ValueTbx.Size = new System.Drawing.Size(521, 22);
            this.ValueTbx.TabIndex = 24;
            // 
            // GlobalTokenChk
            // 
            this.GlobalTokenChk.AutoSize = true;
            this.GlobalTokenChk.Checked = true;
            this.GlobalTokenChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GlobalTokenChk.Location = new System.Drawing.Point(137, 43);
            this.GlobalTokenChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GlobalTokenChk.Name = "GlobalTokenChk";
            this.GlobalTokenChk.Size = new System.Drawing.Size(115, 21);
            this.GlobalTokenChk.TabIndex = 23;
            this.GlobalTokenChk.Text = "Global Token";
            this.GlobalTokenChk.UseVisualStyleBackColor = true;
            this.GlobalTokenChk.CheckedChanged += new System.EventHandler(this.GlobalTokenChk_CheckedChanged);
            // 
            // PasswordChk
            // 
            this.PasswordChk.AutoSize = true;
            this.PasswordChk.Location = new System.Drawing.Point(361, 43);
            this.PasswordChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PasswordChk.Name = "PasswordChk";
            this.PasswordChk.Size = new System.Drawing.Size(91, 21);
            this.PasswordChk.TabIndex = 22;
            this.PasswordChk.Text = "Password";
            this.PasswordChk.UseVisualStyleBackColor = true;
            this.PasswordChk.CheckedChanged += new System.EventHandler(this.PasswordChk_CheckedChanged);
            // 
            // UserNameLbl
            // 
            this.UserNameLbl.AutoSize = true;
            this.UserNameLbl.Location = new System.Drawing.Point(8, 209);
            this.UserNameLbl.Name = "UserNameLbl";
            this.UserNameLbl.Size = new System.Drawing.Size(75, 17);
            this.UserNameLbl.TabIndex = 21;
            this.UserNameLbl.Text = "UserName";
            // 
            // DescriptionLbl
            // 
            this.DescriptionLbl.AutoSize = true;
            this.DescriptionLbl.Location = new System.Drawing.Point(8, 166);
            this.DescriptionLbl.Name = "DescriptionLbl";
            this.DescriptionLbl.Size = new System.Drawing.Size(79, 17);
            this.DescriptionLbl.TabIndex = 20;
            this.DescriptionLbl.Text = "Description";
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
            // EnvironmentLbl
            // 
            this.EnvironmentLbl.AutoSize = true;
            this.EnvironmentLbl.Location = new System.Drawing.Point(11, 98);
            this.EnvironmentLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EnvironmentLbl.Name = "EnvironmentLbl";
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
            // SubTokenChk
            // 
            this.SubTokenChk.AutoSize = true;
            this.SubTokenChk.Location = new System.Drawing.Point(259, 43);
            this.SubTokenChk.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.SubTokenChk.Name = "SubTokenChk";
            this.SubTokenChk.Size = new System.Drawing.Size(95, 21);
            this.SubTokenChk.TabIndex = 16;
            this.SubTokenChk.Text = "SubToken";
            this.SubTokenChk.UseVisualStyleBackColor = true;
            // 
            // TokenNameTbx
            // 
            this.TokenNameTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TokenNameTbx.Location = new System.Drawing.Point(137, 14);
            this.TokenNameTbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TokenNameTbx.Name = "TokenNameTbx";
            this.TokenNameTbx.Size = new System.Drawing.Size(521, 22);
            this.TokenNameTbx.TabIndex = 15;
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddBtn.Location = new System.Drawing.Point(539, 267);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(120, 36);
            this.AddBtn.TabIndex = 14;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateBtn.Location = new System.Drawing.Point(539, 267);
            this.UpdateBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(120, 36);
            this.UpdateBtn.TabIndex = 28;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // TokenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 314);
            this.Controls.Add(this.EnvironmentCbx);
            this.Controls.Add(this.UserNameTbx);
            this.Controls.Add(this.DescriptionTbx);
            this.Controls.Add(this.ValueTbx);
            this.Controls.Add(this.GlobalTokenChk);
            this.Controls.Add(this.PasswordChk);
            this.Controls.Add(this.UserNameLbl);
            this.Controls.Add(this.DescriptionLbl);
            this.Controls.Add(this.ValueLbl);
            this.Controls.Add(this.EnvironmentLbl);
            this.Controls.Add(this.TokenNameLbl);
            this.Controls.Add(this.SubTokenChk);
            this.Controls.Add(this.TokenNameTbx);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "TokenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add new Token";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox EnvironmentCbx;
        private System.Windows.Forms.TextBox UserNameTbx;
        private System.Windows.Forms.TextBox DescriptionTbx;
        private System.Windows.Forms.TextBox ValueTbx;
        private System.Windows.Forms.CheckBox GlobalTokenChk;
        private System.Windows.Forms.CheckBox PasswordChk;
        private System.Windows.Forms.Label UserNameLbl;
        private System.Windows.Forms.Label DescriptionLbl;
        private System.Windows.Forms.Label ValueLbl;
        private System.Windows.Forms.Label EnvironmentLbl;
        private System.Windows.Forms.Label TokenNameLbl;
        private System.Windows.Forms.CheckBox SubTokenChk;
        private System.Windows.Forms.TextBox TokenNameTbx;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button UpdateBtn;
    }
}
