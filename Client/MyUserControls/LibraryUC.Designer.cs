﻿namespace HonorsClient.UserControls
{
    partial class LibraryUC
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
            label1 = new Label();
            podcastPanel = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(330, 0);
            label1.Name = "label1";
            label1.Size = new Size(109, 37);
            label1.TabIndex = 0;
            label1.Text = "Library";
            // 
            // podcastPanel
            // 
            podcastPanel.AutoScroll = true;
            podcastPanel.Location = new Point(3, 46);
            podcastPanel.Name = "podcastPanel";
            podcastPanel.Size = new Size(902, 512);
            podcastPanel.TabIndex = 1;
            // 
            // LibraryUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(podcastPanel);
            Controls.Add(label1);
            Name = "LibraryUC";
            Size = new Size(908, 561);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel podcastPanel;
    }
}
