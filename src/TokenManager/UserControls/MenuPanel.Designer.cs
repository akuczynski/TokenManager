
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
            this.SubTokensCbx = new System.Windows.Forms.CheckBox();
            this.ValidateBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadBtn
            // 
            this.LoadBtn.Location = new System.Drawing.Point(3, 5);
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(75, 23);
            this.LoadBtn.TabIndex = 1;
            this.LoadBtn.Text = "Load";
            this.LoadBtn.UseVisualStyleBackColor = true;
            this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // FilterLbl
            // 
            this.FilterLbl.AutoSize = true;
            this.FilterLbl.Location = new System.Drawing.Point(184, 9);
            this.FilterLbl.Name = "FilterLbl";
            this.FilterLbl.Size = new System.Drawing.Size(32, 13);
            this.FilterLbl.TabIndex = 2;
            this.FilterLbl.Text = "Filter:";
            // 
            // FilterTxb
            // 
            this.FilterTxb.Enabled = false;
            this.FilterTxb.Location = new System.Drawing.Point(222, 7);
            this.FilterTxb.Name = "FilterTxb";
            this.FilterTxb.Size = new System.Drawing.Size(357, 20);
            this.FilterTxb.TabIndex = 3;
            // 
            // ShowLbl
            // 
            this.ShowLbl.AutoSize = true;
            this.ShowLbl.Location = new System.Drawing.Point(585, 9);
            this.ShowLbl.Name = "ShowLbl";
            this.ShowLbl.Size = new System.Drawing.Size(59, 13);
            this.ShowLbl.TabIndex = 4;
            this.ShowLbl.Text = "Show only:";
            // 
            // TokensCbx
            // 
            this.TokensCbx.AutoSize = true;
            this.TokensCbx.Enabled = false;
            this.TokensCbx.Location = new System.Drawing.Point(650, 9);
            this.TokensCbx.Name = "TokensCbx";
            this.TokensCbx.Size = new System.Drawing.Size(62, 17);
            this.TokensCbx.TabIndex = 5;
            this.TokensCbx.Text = "Tokens";
            this.TokensCbx.UseVisualStyleBackColor = true;
            // 
            // SubTokensCbx
            // 
            this.SubTokensCbx.AutoSize = true;
            this.SubTokensCbx.Enabled = false;
            this.SubTokensCbx.Location = new System.Drawing.Point(718, 9);
            this.SubTokensCbx.Name = "SubTokensCbx";
            this.SubTokensCbx.Size = new System.Drawing.Size(81, 17);
            this.SubTokensCbx.TabIndex = 6;
            this.SubTokensCbx.Text = "SubTokens";
            this.SubTokensCbx.UseVisualStyleBackColor = true;
            // 
            // ValidateBtn
            // 
            this.ValidateBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ValidateBtn.Enabled = false;
            this.ValidateBtn.Location = new System.Drawing.Point(857, 4);
            this.ValidateBtn.Name = "ValidateBtn";
            this.ValidateBtn.Size = new System.Drawing.Size(75, 23);
            this.ValidateBtn.TabIndex = 7;
            this.ValidateBtn.Text = "Validate";
            this.ValidateBtn.UseVisualStyleBackColor = true;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Enabled = false;
            this.SaveBtn.Location = new System.Drawing.Point(84, 4);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 8;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            // 
            // MenuPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.ValidateBtn);
            this.Controls.Add(this.SubTokensCbx);
            this.Controls.Add(this.TokensCbx);
            this.Controls.Add(this.ShowLbl);
            this.Controls.Add(this.FilterTxb);
            this.Controls.Add(this.FilterLbl);
            this.Controls.Add(this.LoadBtn);
            this.Name = "MenuPanel";
            this.Size = new System.Drawing.Size(939, 36);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LoadBtn;
        private System.Windows.Forms.Label FilterLbl;
        private System.Windows.Forms.TextBox FilterTxb;
        private System.Windows.Forms.Label ShowLbl;
        private System.Windows.Forms.CheckBox TokensCbx;
        private System.Windows.Forms.CheckBox SubTokensCbx;
        private System.Windows.Forms.Button ValidateBtn;
        private System.Windows.Forms.Button SaveBtn;
    }
}
