﻿
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
            this.TokenEditPanel = new TokenManager.UserControls.TokenEditPanel();
            this.TokensGrid = new TokenManager.UserControls.TokensGrid();
            this.MenuPanel = new TokenManager.UserControls.MenuPanel();
            this.SuspendLayout();
            // 
            // TokenEditPanel
            // 
            this.TokenEditPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TokenEditPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TokenEditPanel.Location = new System.Drawing.Point(0, 481);
            this.TokenEditPanel.MainForm = null;
            this.TokenEditPanel.Name = "TokenEditPanel";
            this.TokenEditPanel.Size = new System.Drawing.Size(1021, 252);
            this.TokenEditPanel.TabIndex = 3;
            // 
            // TokensGrid
            // 
            this.TokensGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TokensGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TokensGrid.Location = new System.Drawing.Point(0, 34);
            this.TokensGrid.MainForm = null;
            this.TokensGrid.Name = "TokensGrid";
            this.TokensGrid.Size = new System.Drawing.Size(1021, 699);
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
            this.MenuPanel.Size = new System.Drawing.Size(1021, 34);
            this.MenuPanel.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 733);
            this.Controls.Add(this.TokenEditPanel);
            this.Controls.Add(this.TokensGrid);
            this.Controls.Add(this.MenuPanel);
            this.Name = "MainForm";
            this.Text = "Token Manager";
            this.ResumeLayout(false);

        }

        #endregion
        private UserControls.TokenEditPanel TokenEditPanel;
        private UserControls.MenuPanel MenuPanel;
        private UserControls.TokensGrid TokensGrid;
    }
}

