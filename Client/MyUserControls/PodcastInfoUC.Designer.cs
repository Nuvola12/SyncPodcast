namespace HonorsClient.MenueUserControls
{
    partial class PodcastInfoUC
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
            episodePanel = new Panel();
            TitleLbl = new Label();
            AuthorLbl = new Label();
            DescriptionLbl = new Label();
            DownloadBtn = new Button();
            SuspendLayout();
            // 
            // episodePanel
            // 
            episodePanel.AutoScroll = true;
            episodePanel.Location = new Point(3, 151);
            episodePanel.Name = "episodePanel";
            episodePanel.Size = new Size(896, 305);
            episodePanel.TabIndex = 0;
            // 
            // TitleLbl
            // 
            TitleLbl.AutoSize = true;
            TitleLbl.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            TitleLbl.Location = new Point(16, 13);
            TitleLbl.Name = "TitleLbl";
            TitleLbl.Size = new Size(75, 37);
            TitleLbl.TabIndex = 1;
            TitleLbl.Text = "Title";
            // 
            // AuthorLbl
            // 
            AuthorLbl.AutoSize = true;
            AuthorLbl.Location = new Point(26, 58);
            AuthorLbl.Name = "AuthorLbl";
            AuthorLbl.Size = new Size(42, 15);
            AuthorLbl.TabIndex = 2;
            AuthorLbl.Text = "author";
            AuthorLbl.Click += label2_Click;
            // 
            // DescriptionLbl
            // 
            DescriptionLbl.Location = new Point(19, 89);
            DescriptionLbl.Name = "DescriptionLbl";
            DescriptionLbl.Size = new Size(785, 59);
            DescriptionLbl.TabIndex = 3;
            DescriptionLbl.Text = "desc";
            // 
            // DownloadBtn
            // 
            DownloadBtn.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            DownloadBtn.Location = new Point(842, 13);
            DownloadBtn.Name = "DownloadBtn";
            DownloadBtn.Size = new Size(57, 48);
            DownloadBtn.TabIndex = 4;
            DownloadBtn.Text = "+";
            DownloadBtn.UseVisualStyleBackColor = true;
            DownloadBtn.Click += DownloadBtn_Click;
            // 
            // PodcastInfoUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(DownloadBtn);
            Controls.Add(DescriptionLbl);
            Controls.Add(AuthorLbl);
            Controls.Add(TitleLbl);
            Controls.Add(episodePanel);
            Name = "PodcastInfoUC";
            Size = new Size(902, 459);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel episodePanel;
        private Label TitleLbl;
        private Label AuthorLbl;
        private Label DescriptionLbl;
        private Button DownloadBtn;
    }
}
