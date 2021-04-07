
namespace TokenManager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatubBarLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.TokensGrid = new TokenManager.UserControls.TokensGrid();
            this.MenuPanel = new TokenManager.UserControls.MenuPanel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatubBarLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 714);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1040, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatubBarLbl
            // 
            this.StatubBarLbl.Name = "StatubBarLbl";
            this.StatubBarLbl.Size = new System.Drawing.Size(0, 17);
            // 
            // TokensGrid
            // 
            this.TokensGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TokensGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TokensGrid.Location = new System.Drawing.Point(0, 34);
            this.TokensGrid.MainForm = null;
            this.TokensGrid.Name = "TokensGrid";
            this.TokensGrid.Size = new System.Drawing.Size(1040, 702);
            this.TokensGrid.TabIndex = 2;
            this.TokensGrid.TokensGridViewController = null;
            // 
            // MenuPanel
            // 
            this.MenuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.MainForm = null;
            this.MenuPanel.MainViewController = null;
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(1040, 34);
            this.MenuPanel.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 736);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TokensGrid);
            this.Controls.Add(this.MenuPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1040, 733);
            this.Name = "MainForm";
            this.Text = "Token Manager";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private UserControls.MenuPanel MenuPanel;
        private UserControls.TokensGrid TokensGrid;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatubBarLbl;
    }
}

