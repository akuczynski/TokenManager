
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
            this.TokenNameTbx = new System.Windows.Forms.TextBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.Layout = new System.Windows.Forms.TableLayoutPanel();
            this.CheckBoxPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Layout.SuspendLayout();
            this.CheckBoxPanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnvironmentCbx
            // 
            this.EnvironmentCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EnvironmentCbx.FormattingEnabled = true;
            this.EnvironmentCbx.Location = new System.Drawing.Point(93, 97);
            this.EnvironmentCbx.Margin = new System.Windows.Forms.Padding(8);
            this.EnvironmentCbx.Name = "EnvironmentCbx";
            this.EnvironmentCbx.Size = new System.Drawing.Size(638, 24);
            this.EnvironmentCbx.TabIndex = 27;
            // 
            // UserNameTbx
            // 
            this.UserNameTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.UserNameTbx.Location = new System.Drawing.Point(93, 214);
            this.UserNameTbx.Margin = new System.Windows.Forms.Padding(8);
            this.UserNameTbx.Name = "UserNameTbx";
            this.UserNameTbx.Size = new System.Drawing.Size(638, 22);
            this.UserNameTbx.TabIndex = 26;
            // 
            // DescriptionTbx
            // 
            this.DescriptionTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionTbx.Location = new System.Drawing.Point(93, 176);
            this.DescriptionTbx.Margin = new System.Windows.Forms.Padding(8);
            this.DescriptionTbx.Name = "DescriptionTbx";
            this.DescriptionTbx.Size = new System.Drawing.Size(638, 22);
            this.DescriptionTbx.TabIndex = 25;
            // 
            // ValueTbx
            // 
            this.ValueTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueTbx.Location = new System.Drawing.Point(93, 138);
            this.ValueTbx.Margin = new System.Windows.Forms.Padding(8);
            this.ValueTbx.Name = "ValueTbx";
            this.ValueTbx.Size = new System.Drawing.Size(638, 22);
            this.ValueTbx.TabIndex = 24;
            // 
            // GlobalTokenChk
            // 
            this.GlobalTokenChk.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.GlobalTokenChk.AutoSize = true;
            this.GlobalTokenChk.Checked = true;
            this.GlobalTokenChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GlobalTokenChk.Location = new System.Drawing.Point(3, 2);
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
            this.PasswordChk.Location = new System.Drawing.Point(124, 2);
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
            this.UserNameLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UserNameLbl.AutoSize = true;
            this.UserNameLbl.Location = new System.Drawing.Point(3, 216);
            this.UserNameLbl.Name = "UserNameLbl";
            this.UserNameLbl.Size = new System.Drawing.Size(79, 17);
            this.UserNameLbl.TabIndex = 21;
            this.UserNameLbl.Text = "User Name";
            // 
            // DescriptionLbl
            // 
            this.DescriptionLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DescriptionLbl.AutoSize = true;
            this.DescriptionLbl.Location = new System.Drawing.Point(3, 178);
            this.DescriptionLbl.Name = "DescriptionLbl";
            this.DescriptionLbl.Size = new System.Drawing.Size(79, 17);
            this.DescriptionLbl.TabIndex = 20;
            this.DescriptionLbl.Text = "Description";
            // 
            // ValueLbl
            // 
            this.ValueLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ValueLbl.AutoSize = true;
            this.ValueLbl.Location = new System.Drawing.Point(3, 140);
            this.ValueLbl.Name = "ValueLbl";
            this.ValueLbl.Size = new System.Drawing.Size(44, 17);
            this.ValueLbl.TabIndex = 19;
            this.ValueLbl.Text = "Value";
            // 
            // EnvironmentLbl
            // 
            this.EnvironmentLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EnvironmentLbl.AutoSize = true;
            this.EnvironmentLbl.Location = new System.Drawing.Point(4, 101);
            this.EnvironmentLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EnvironmentLbl.Name = "EnvironmentLbl";
            this.EnvironmentLbl.Size = new System.Drawing.Size(72, 17);
            this.EnvironmentLbl.TabIndex = 18;
            this.EnvironmentLbl.Text = "Defined in";
            // 
            // TokenNameLbl
            // 
            this.TokenNameLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TokenNameLbl.AutoSize = true;
            this.TokenNameLbl.Location = new System.Drawing.Point(3, 10);
            this.TokenNameLbl.Name = "TokenNameLbl";
            this.TokenNameLbl.Size = new System.Drawing.Size(48, 17);
            this.TokenNameLbl.TabIndex = 17;
            this.TokenNameLbl.Text = "Token";
            // 
            // TokenNameTbx
            // 
            this.TokenNameTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TokenNameTbx.Location = new System.Drawing.Point(93, 8);
            this.TokenNameTbx.Margin = new System.Windows.Forms.Padding(8);
            this.TokenNameTbx.Name = "TokenNameTbx";
            this.TokenNameTbx.Size = new System.Drawing.Size(638, 22);
            this.TokenNameTbx.TabIndex = 15;
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddBtn.Location = new System.Drawing.Point(511, 8);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(8);
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
            this.UpdateBtn.Location = new System.Drawing.Point(375, 8);
            this.UpdateBtn.Margin = new System.Windows.Forms.Padding(8);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(120, 36);
            this.UpdateBtn.TabIndex = 28;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // Layout
            // 
            this.Layout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Layout.ColumnCount = 2;
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 654F));
            this.Layout.Controls.Add(this.TokenNameLbl, 0, 0);
            this.Layout.Controls.Add(this.TokenNameTbx, 1, 0);
            this.Layout.Controls.Add(this.CheckBoxPanel, 1, 1);
            this.Layout.Controls.Add(this.EnvironmentLbl, 0, 2);
            this.Layout.Controls.Add(this.EnvironmentCbx, 1, 2);
            this.Layout.Controls.Add(this.ValueLbl, 0, 3);
            this.Layout.Controls.Add(this.ValueTbx, 1, 3);
            this.Layout.Controls.Add(this.DescriptionLbl, 0, 5);
            this.Layout.Controls.Add(this.DescriptionTbx, 1, 5);
            this.Layout.Controls.Add(this.UserNameLbl, 0, 4);
            this.Layout.Controls.Add(this.UserNameTbx, 1, 4);
            this.Layout.Controls.Add(this.ButtonPanel, 1, 6);
            this.Layout.Location = new System.Drawing.Point(12, 12);
            this.Layout.Name = "Layout";
            this.Layout.RowCount = 7;
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Layout.Size = new System.Drawing.Size(739, 308);
            this.Layout.TabIndex = 29;
            // 
            // CheckBoxPanel
            // 
            this.CheckBoxPanel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CheckBoxPanel.Controls.Add(this.GlobalTokenChk);
            this.CheckBoxPanel.Controls.Add(this.PasswordChk);
            this.CheckBoxPanel.Location = new System.Drawing.Point(93, 46);
            this.CheckBoxPanel.Margin = new System.Windows.Forms.Padding(8);
            this.CheckBoxPanel.Name = "CheckBoxPanel";
            this.CheckBoxPanel.Size = new System.Drawing.Size(534, 35);
            this.CheckBoxPanel.TabIndex = 30;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonPanel.Controls.Add(this.AddBtn);
            this.ButtonPanel.Controls.Add(this.UpdateBtn);
            this.ButtonPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.ButtonPanel.Location = new System.Drawing.Point(97, 252);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(639, 53);
            this.ButtonPanel.TabIndex = 30;
            // 
            // TokenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 332);
            this.Controls.Add(this.Layout);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(18, 358);
            this.Name = "TokenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Token";
            this.Layout.ResumeLayout(false);
            this.Layout.PerformLayout();
            this.CheckBoxPanel.ResumeLayout(false);
            this.CheckBoxPanel.PerformLayout();
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TextBox TokenNameTbx;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.TableLayoutPanel Layout;
        private System.Windows.Forms.FlowLayoutPanel CheckBoxPanel;
        private System.Windows.Forms.FlowLayoutPanel ButtonPanel;
    }
}
