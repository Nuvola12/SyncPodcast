namespace HonorsClient.MenueUserControls
{
    partial class MediaControlUC
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
            components = new System.ComponentModel.Container();
            PodcastThumbnail = new PictureBox();
            episodeNameLbl = new Label();
            podcastNameLbl = new Label();
            PlayBtn = new Button();
            panel1 = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            episodeTimerLbl = new Label();
            timer2 = new System.Windows.Forms.Timer(components);
            frwdBtn = new Button();
            bckBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)PodcastThumbnail).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // PodcastThumbnail
            // 
            PodcastThumbnail.Location = new Point(5, 4);
            PodcastThumbnail.Name = "PodcastThumbnail";
            PodcastThumbnail.Size = new Size(95, 95);
            PodcastThumbnail.TabIndex = 0;
            PodcastThumbnail.TabStop = false;
            // 
            // episodeNameLbl
            // 
            episodeNameLbl.Dock = DockStyle.Top;
            episodeNameLbl.Font = new Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Point);
            episodeNameLbl.Location = new Point(0, 0);
            episodeNameLbl.MaximumSize = new Size(int.MaxValue, int.MaxValue);
            episodeNameLbl.Name = "episodeNameLbl";
            episodeNameLbl.Size = new Size(707, 31);
            episodeNameLbl.TabIndex = 1;
            // 
            // podcastNameLbl
            // 
            podcastNameLbl.AutoSize = true;
            podcastNameLbl.Location = new Point(131, 79);
            podcastNameLbl.Name = "podcastNameLbl";
            podcastNameLbl.Size = new Size(0, 15);
            podcastNameLbl.TabIndex = 2;
            // 
            // PlayBtn
            // 
            PlayBtn.Location = new Point(843, 55);
            PlayBtn.Name = "PlayBtn";
            PlayBtn.Size = new Size(62, 44);
            PlayBtn.TabIndex = 3;
            PlayBtn.Text = "Play";
            PlayBtn.UseVisualStyleBackColor = true;
            PlayBtn.Click += PlayBtn_Click;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(episodeNameLbl);
            panel1.Location = new Point(111, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(707, 38);
            panel1.TabIndex = 5;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 5000;
            timer1.Tick += timer1_Tick;
            // 
            // episodeTimerLbl
            // 
            episodeTimerLbl.Location = new Point(399, 4);
            episodeTimerLbl.Name = "episodeTimerLbl";
            episodeTimerLbl.Size = new Size(106, 38);
            episodeTimerLbl.TabIndex = 6;
            // 
            // timer2
            // 
            timer2.Enabled = true;
            timer2.Interval = 1000;
            timer2.Tick += timer2_Tick;
            // 
            // frwdBtn
            // 
            frwdBtn.Location = new Point(502, 4);
            frwdBtn.Name = "frwdBtn";
            frwdBtn.Size = new Size(46, 38);
            frwdBtn.TabIndex = 7;
            frwdBtn.Text = "+5";
            frwdBtn.UseVisualStyleBackColor = true;
            frwdBtn.Click += frwdBtn_Click;
            // 
            // bckBtn
            // 
            bckBtn.Location = new Point(347, 4);
            bckBtn.Name = "bckBtn";
            bckBtn.Size = new Size(46, 38);
            bckBtn.TabIndex = 8;
            bckBtn.Text = "-5";
            bckBtn.UseVisualStyleBackColor = true;
            bckBtn.Click += bckBtn_Click;
            // 
            // MediaControlUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(bckBtn);
            Controls.Add(frwdBtn);
            Controls.Add(episodeTimerLbl);
            Controls.Add(panel1);
            Controls.Add(PlayBtn);
            Controls.Add(podcastNameLbl);
            Controls.Add(PodcastThumbnail);
            Name = "MediaControlUC";
            Size = new Size(908, 102);
            Load += MediaControlUC_Load;
            ((System.ComponentModel.ISupportInitialize)PodcastThumbnail).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PodcastThumbnail;
        private Label episodeNameLbl;
        private Label podcastNameLbl;
        private Button PlayBtn;
        private Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private Label episodeTimerLbl;
        private System.Windows.Forms.Timer timer2;
        private Button frwdBtn;
        private Button bckBtn;
    }
}
