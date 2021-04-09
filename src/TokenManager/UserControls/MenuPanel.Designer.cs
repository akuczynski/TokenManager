
namespace TokenManager.UserControls
{
    partial class MenuPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadBtn = new System.Windows.Forms.Button();
            this.FilterLbl = new System.Windows.Forms.Label();
            this.FilterTxb = new System.Windows.Forms.TextBox();
            this.ShowLbl = new System.Windows.Forms.Label();
            this.TokensCbx = new System.Windows.Forms.CheckBox();
            this.SubtokensCbx = new System.Windows.Forms.CheckBox();
            this.ValidateBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.PasswordCbx = new System.Windows.Forms.CheckBox();
            this.GlobalCbx = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LoadBtn
            // 
            this.LoadBtn.Location = new System.Drawing.Point(4, 5);
            this.LoadBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(100, 28);
            this.LoadBtn.TabIndex = 1;
            this.LoadBtn.Text = "Load";
            this.LoadBtn.UseVisualStyleBackColor = true;
            this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // FilterLbl
            // 
            this.FilterLbl.AutoSize = true;
            this.FilterLbl.Location = new System.Drawing.Point(245, 11);
            this.FilterLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FilterLbl.Name = "FilterLbl";
            this.FilterLbl.Size = new System.Drawing.Size(43, 17);
            this.FilterLbl.TabIndex = 2;
            this.FilterLbl.Text = "Filter:";
            // 
            // FilterTxb
            // 
            this.FilterTxb.Enabled = false;
            this.FilterTxb.Location = new System.Drawing.Point(296, 6);
            this.FilterTxb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FilterTxb.Name = "FilterTxb";
            this.FilterTxb.Size = new System.Drawing.Size(475, 22);
            this.FilterTxb.TabIndex = 3;
            // 
            // ShowLbl
            // 
            this.ShowLbl.AutoSize = true;
            this.ShowLbl.Location = new System.Drawing.Point(780, 11);
            this.ShowLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ShowLbl.Name = "ShowLbl";
            this.ShowLbl.Size = new System.Drawing.Size(76, 17);
            this.ShowLbl.TabIndex = 4;
            this.ShowLbl.Text = "Show only:";
            // 
            // TokensCbx
            // 
            this.TokensCbx.AutoSize = true;
            this.TokensCbx.Enabled = false;
            this.TokensCbx.Location = new System.Drawing.Point(867, 11);
            this.TokensCbx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TokensCbx.Name = "TokensCbx";
            this.TokensCbx.Size = new System.Drawing.Size(77, 21);
            this.TokensCbx.TabIndex = 5;
            this.TokensCbx.Text = "Tokens";
            this.TokensCbx.UseVisualStyleBackColor = true;
            // 
            // SubTokensCbx
            // 
            this.SubtokensCbx.AutoSize = true;
            this.SubtokensCbx.Enabled = false;
            this.SubtokensCbx.Location = new System.Drawing.Point(957, 11);
            this.SubtokensCbx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SubtokensCbx.Name = "SubTokensCbx";
            this.SubtokensCbx.Size = new System.Drawing.Size(121, 26);
            this.SubtokensCbx.TabIndex = 6;
            this.SubtokensCbx.Text = "Subtokens";
            this.SubtokensCbx.UseVisualStyleBackColor = true;
            // 
            // ValidateBtn
            // 
            this.ValidateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ValidateBtn.Enabled = false;
            this.ValidateBtn.Location = new System.Drawing.Point(1328, 5);
            this.ValidateBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ValidateBtn.Name = "ValidateBtn";
            this.ValidateBtn.Size = new System.Drawing.Size(100, 28);
            this.ValidateBtn.TabIndex = 7;
            this.ValidateBtn.Text = "Validate";
            this.ValidateBtn.UseVisualStyleBackColor = true;
            this.ValidateBtn.Click += new System.EventHandler(this.ValidateBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Enabled = false;
            this.SaveBtn.Location = new System.Drawing.Point(112, 5);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(100, 28);
            this.SaveBtn.TabIndex = 8;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // PasswordCbx
            // 
            this.PasswordCbx.AutoSize = true;
            this.PasswordCbx.Enabled = false;
            this.PasswordCbx.Location = new System.Drawing.Point(1075, 11);
            this.PasswordCbx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PasswordCbx.Name = "PasswordCbx";
            this.PasswordCbx.Size = new System.Drawing.Size(91, 21);
            this.PasswordCbx.TabIndex = 9;
            this.PasswordCbx.Text = "Password";
            this.PasswordCbx.UseVisualStyleBackColor = true;
            // 
            // GlobalCbx
            // 
            this.GlobalCbx.AutoSize = true;
            this.GlobalCbx.Enabled = false;
            this.GlobalCbx.Location = new System.Drawing.Point(1173, 11);
            this.GlobalCbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GlobalCbx.Name = "GlobalCbx";
            this.GlobalCbx.Size = new System.Drawing.Size(71, 21);
            this.GlobalCbx.TabIndex = 11;
            this.GlobalCbx.Text = "Global";
            this.GlobalCbx.UseVisualStyleBackColor = true;
            // 
            // MenuPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GlobalCbx);
            this.Controls.Add(this.PasswordCbx);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.ValidateBtn);
            this.Controls.Add(this.SubtokensCbx);
            this.Controls.Add(this.TokensCbx);
            this.Controls.Add(this.ShowLbl);
            this.Controls.Add(this.FilterTxb);
            this.Controls.Add(this.FilterLbl);
            this.Controls.Add(this.LoadBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MenuPanel";
            this.Size = new System.Drawing.Size(1437, 39);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LoadBtn;
        private System.Windows.Forms.Label FilterLbl;
        private System.Windows.Forms.TextBox FilterTxb;
        private System.Windows.Forms.Label ShowLbl;
        private System.Windows.Forms.CheckBox TokensCbx;
        private System.Windows.Forms.CheckBox SubtokensCbx;
        private System.Windows.Forms.Button ValidateBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.CheckBox PasswordCbx;
        private System.Windows.Forms.CheckBox GlobalCbx;
    }
}
