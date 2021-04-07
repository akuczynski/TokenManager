
using System.Windows.Forms;

namespace TokenManager.UserControls
{
    partial class TokensGrid
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MainGrid = new System.Windows.Forms.DataGridView();
            this.SubGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MainGrid);
            this.splitContainer1.Panel1MinSize = 60;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.SubGrid);
            this.splitContainer1.Size = new System.Drawing.Size(604, 466);
            this.splitContainer1.SplitterDistance = 325;
            this.splitContainer1.TabIndex = 2;
            // 
            // MainGrid
            // 
            this.MainGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;            
            this.MainGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.MainGrid.Location = new System.Drawing.Point(0, 0);
            this.MainGrid.MultiSelect = false;
            this.MainGrid.Name = "MainGrid";
            this.MainGrid.ReadOnly = true;
            this.MainGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainGrid.Size = new System.Drawing.Size(604, 325);
            this.MainGrid.TabIndex = 1;
            this.MainGrid.SelectionChanged += new System.EventHandler(this.MainGrid_SelectionChanged);
            this.MainGrid.MouseClick += new MouseEventHandler(this.MainGrid_MouseClick);
            // 
            // SubGrid
            // 
            this.SubGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;            
            this.SubGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SubGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubGrid.Location = new System.Drawing.Point(0, 0);
            this.SubGrid.Name = "SubGrid";
            this.SubGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SubGrid.Size = new System.Drawing.Size(604, 137);
            this.SubGrid.TabIndex = 2;
            this.SubGrid.MouseClick += new MouseEventHandler(this.SubGrid_MouseClick);
            // 
            // TokensGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TokensGrid";
            this.Size = new System.Drawing.Size(604, 466);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView MainGrid;
        private System.Windows.Forms.DataGridView SubGrid;
    }
}
