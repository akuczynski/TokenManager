
namespace TokenManager.Forms
{
    partial class EnvironmentForm
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
            this.EnvironmentLbl = new System.Windows.Forms.Label();
            this.EnvironmentCbx = new System.Windows.Forms.ComboBox();
            this.ValueLbl = new System.Windows.Forms.Label();
            this.ValueTbx = new System.Windows.Forms.TextBox();
            this.UserNameLbl = new System.Windows.Forms.Label();
            this.UserNameTbx = new System.Windows.Forms.TextBox();
            this.AssignBtn = new System.Windows.Forms.Button();
            this.DescriptionLbl = new System.Windows.Forms.Label();
            this.DescriptionTbx = new System.Windows.Forms.TextBox();
            this.Layout = new System.Windows.Forms.TableLayoutPanel();
            this.Layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnvironmentLbl
            // 
            this.EnvironmentLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EnvironmentLbl.AutoSize = true;
            this.EnvironmentLbl.Location = new System.Drawing.Point(4, 11);
            this.EnvironmentLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EnvironmentLbl.Name = "EnvironmentLbl";
            this.EnvironmentLbl.Size = new System.Drawing.Size(87, 17);
            this.EnvironmentLbl.TabIndex = 0;
            this.EnvironmentLbl.Text = "Environment";
            // 
            // EnvironmentCbx
            // 
            this.EnvironmentCbx.FormattingEnabled = true;
            this.EnvironmentCbx.Location = new System.Drawing.Point(103, 8);
            this.EnvironmentCbx.Margin = new System.Windows.Forms.Padding(8);
            this.EnvironmentCbx.Name = "EnvironmentCbx";
            this.EnvironmentCbx.Size = new System.Drawing.Size(169, 24);
            this.EnvironmentCbx.TabIndex = 1;
            // 
            // ValueLbl
            // 
            this.ValueLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ValueLbl.AutoSize = true;
            this.ValueLbl.Location = new System.Drawing.Point(4, 50);
            this.ValueLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ValueLbl.Name = "ValueLbl";
            this.ValueLbl.Size = new System.Drawing.Size(44, 17);
            this.ValueLbl.TabIndex = 2;
            this.ValueLbl.Text = "Value";
            // 
            // ValueTbx
            // 
            this.ValueTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueTbx.Location = new System.Drawing.Point(103, 48);
            this.ValueTbx.Margin = new System.Windows.Forms.Padding(8);
            this.ValueTbx.Name = "ValueTbx";
            this.ValueTbx.Size = new System.Drawing.Size(356, 22);
            this.ValueTbx.TabIndex = 3;
            // 
            // UserNameLbl
            // 
            this.UserNameLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UserNameLbl.AutoSize = true;
            this.UserNameLbl.Location = new System.Drawing.Point(4, 88);
            this.UserNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UserNameLbl.Name = "UserNameLbl";
            this.UserNameLbl.Size = new System.Drawing.Size(79, 17);
            this.UserNameLbl.TabIndex = 4;
            this.UserNameLbl.Text = "User Name";
            // 
            // UserNameTbx
            // 
            this.UserNameTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserNameTbx.Location = new System.Drawing.Point(103, 86);
            this.UserNameTbx.Margin = new System.Windows.Forms.Padding(8);
            this.UserNameTbx.Name = "UserNameTbx";
            this.UserNameTbx.Size = new System.Drawing.Size(356, 22);
            this.UserNameTbx.TabIndex = 5;
            // 
            // AssignBtn
            // 
            this.AssignBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AssignBtn.Location = new System.Drawing.Point(363, 158);
            this.AssignBtn.Margin = new System.Windows.Forms.Padding(4);
            this.AssignBtn.Name = "AssignBtn";
            this.AssignBtn.Size = new System.Drawing.Size(100, 28);
            this.AssignBtn.TabIndex = 6;
            this.AssignBtn.Text = "Assign";
            this.AssignBtn.UseVisualStyleBackColor = true;
            this.AssignBtn.Click += new System.EventHandler(this.AssignBtn_Click);
            // 
            // DescriptionLbl
            // 
            this.DescriptionLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DescriptionLbl.AutoSize = true;
            this.DescriptionLbl.Location = new System.Drawing.Point(3, 126);
            this.DescriptionLbl.Name = "DescriptionLbl";
            this.DescriptionLbl.Size = new System.Drawing.Size(79, 17);
            this.DescriptionLbl.TabIndex = 7;
            this.DescriptionLbl.Text = "Description";
            // 
            // DescriptionTbx
            // 
            this.DescriptionTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionTbx.Location = new System.Drawing.Point(103, 124);
            this.DescriptionTbx.Margin = new System.Windows.Forms.Padding(8);
            this.DescriptionTbx.Name = "DescriptionTbx";
            this.DescriptionTbx.Size = new System.Drawing.Size(356, 22);
            this.DescriptionTbx.TabIndex = 8;
            // 
            // Layout
            // 
            this.Layout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Layout.ColumnCount = 2;
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 372F));
            this.Layout.Controls.Add(this.EnvironmentLbl, 0, 0);
            this.Layout.Controls.Add(this.EnvironmentCbx, 1, 0);
            this.Layout.Controls.Add(this.ValueLbl, 0, 1);
            this.Layout.Controls.Add(this.ValueTbx, 1, 1);
            this.Layout.Controls.Add(this.UserNameLbl, 0, 2);
            this.Layout.Controls.Add(this.UserNameTbx, 1, 2);
            this.Layout.Controls.Add(this.DescriptionLbl, 0, 3);
            this.Layout.Controls.Add(this.DescriptionTbx, 1, 3);
            this.Layout.Controls.Add(this.AssignBtn, 1, 4);
            this.Layout.Location = new System.Drawing.Point(12, 12);
            this.Layout.Name = "Layout";
            this.Layout.RowCount = 5;
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Layout.Size = new System.Drawing.Size(467, 190);
            this.Layout.TabIndex = 9;
            // 
            // EnvironmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 214);
            this.Controls.Add(this.Layout);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(509, 261);
            this.Name = "EnvironmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assing value";
            this.Layout.ResumeLayout(false);
            this.Layout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label EnvironmentLbl;
        private System.Windows.Forms.ComboBox EnvironmentCbx;
        private System.Windows.Forms.Label ValueLbl;
        private System.Windows.Forms.TextBox ValueTbx;
        private System.Windows.Forms.Label UserNameLbl;
        private System.Windows.Forms.TextBox UserNameTbx;
        private System.Windows.Forms.Button AssignBtn;
        private System.Windows.Forms.Label DescriptionLbl;
        private System.Windows.Forms.TextBox DescriptionTbx;
        private System.Windows.Forms.TableLayoutPanel Layout;
    }
}