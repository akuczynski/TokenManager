﻿
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
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.DescriptionLbl = new System.Windows.Forms.Label();
            this.DescriptionTbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // EnvironmentLbl
            // 
            this.EnvironmentLbl.AutoSize = true;
            this.EnvironmentLbl.Location = new System.Drawing.Point(6, 23);
            this.EnvironmentLbl.Name = "EnvironmentLbl";
            this.EnvironmentLbl.Size = new System.Drawing.Size(66, 13);
            this.EnvironmentLbl.TabIndex = 0;
            this.EnvironmentLbl.Text = "Environment";
            // 
            // EnvironmentCbx
            // 
            this.EnvironmentCbx.FormattingEnabled = true;
            this.EnvironmentCbx.Location = new System.Drawing.Point(95, 20);
            this.EnvironmentCbx.Name = "EnvironmentCbx";
            this.EnvironmentCbx.Size = new System.Drawing.Size(128, 21);
            this.EnvironmentCbx.TabIndex = 1;
            // 
            // ValueLbl
            // 
            this.ValueLbl.AutoSize = true;
            this.ValueLbl.Location = new System.Drawing.Point(6, 49);
            this.ValueLbl.Name = "ValueLbl";
            this.ValueLbl.Size = new System.Drawing.Size(34, 13);
            this.ValueLbl.TabIndex = 2;
            this.ValueLbl.Text = "Value";
            // 
            // ValueTbx
            // 
            this.ValueTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueTbx.Location = new System.Drawing.Point(96, 46);
            this.ValueTbx.Name = "ValueTbx";
            this.ValueTbx.Size = new System.Drawing.Size(230, 20);
            this.ValueTbx.TabIndex = 3;
            // 
            // UserNameLbl
            // 
            this.UserNameLbl.AutoSize = true;
            this.UserNameLbl.Location = new System.Drawing.Point(6, 73);
            this.UserNameLbl.Name = "UserNameLbl";
            this.UserNameLbl.Size = new System.Drawing.Size(60, 13);
            this.UserNameLbl.TabIndex = 4;
            this.UserNameLbl.Text = "User Name";
            // 
            // UserNameTbx
            // 
            this.UserNameTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserNameTbx.Location = new System.Drawing.Point(96, 71);
            this.UserNameTbx.Name = "UserNameTbx";
            this.UserNameTbx.Size = new System.Drawing.Size(230, 20);
            this.UserNameTbx.TabIndex = 5;
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitBtn.Location = new System.Drawing.Point(250, 119);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(75, 23);
            this.SubmitBtn.TabIndex = 6;
            this.SubmitBtn.Text = "Assign";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            // 
            // DescriptionLbl
            // 
            this.DescriptionLbl.AutoSize = true;
            this.DescriptionLbl.Location = new System.Drawing.Point(6, 97);
            this.DescriptionLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DescriptionLbl.Name = "DescriptionLbl";
            this.DescriptionLbl.Size = new System.Drawing.Size(60, 13);
            this.DescriptionLbl.TabIndex = 7;
            this.DescriptionLbl.Text = "Description";
            // 
            // DescriptionTbx
            // 
            this.DescriptionTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionTbx.Location = new System.Drawing.Point(96, 94);
            this.DescriptionTbx.Margin = new System.Windows.Forms.Padding(2);
            this.DescriptionTbx.Name = "DescriptionTbx";
            this.DescriptionTbx.Size = new System.Drawing.Size(230, 20);
            this.DescriptionTbx.TabIndex = 8;
            // 
            // EnvironmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 153);
            this.Controls.Add(this.DescriptionTbx);
            this.Controls.Add(this.DescriptionLbl);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.UserNameTbx);
            this.Controls.Add(this.UserNameLbl);
            this.Controls.Add(this.ValueTbx);
            this.Controls.Add(this.ValueLbl);
            this.Controls.Add(this.EnvironmentCbx);
            this.Controls.Add(this.EnvironmentLbl);
            this.Name = "EnvironmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assing value";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EnvironmentLbl;
        private System.Windows.Forms.ComboBox EnvironmentCbx;
        private System.Windows.Forms.Label ValueLbl;
        private System.Windows.Forms.TextBox ValueTbx;
        private System.Windows.Forms.Label UserNameLbl;
        private System.Windows.Forms.TextBox UserNameTbx;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Label DescriptionLbl;
        private System.Windows.Forms.TextBox DescriptionTbx;
    }
}