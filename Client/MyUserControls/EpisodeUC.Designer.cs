namespace HonorsClient.MyUserControls
{
    partial class EpisodeUC
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
            titleLbl = new Label();
            DescriptionLbl = new Label();
            button1 = new Button();
            QueueBtn = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            TimeInfoLbl = new Label();
            SuspendLayout();
            // 
            // titleLbl
            // 
            titleLbl.AutoSize = true;
            titleLbl.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            titleLbl.Location = new Point(6, 2);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(69, 30);
            titleLbl.TabIndex = 2;
            titleLbl.Text = "TITLE";
            // 
            // DescriptionLbl
            // 
            DescriptionLbl.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            DescriptionLbl.Location = new Point(7, 36);
            DescriptionLbl.Name = "DescriptionLbl";
            DescriptionLbl.Size = new Size(671, 53);
            DescriptionLbl.TabIndex = 3;
            DescriptionLbl.Text = "AUTHOR";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(819, 83);
            button1.Name = "button1";
            button1.Size = new Size(48, 38);
            button1.TabIndex = 4;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // QueueBtn
            // 
            QueueBtn.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            QueueBtn.Location = new Point(765, 83);
            QueueBtn.Name = "QueueBtn";
            QueueBtn.Size = new Size(48, 38);
            QueueBtn.TabIndex = 5;
            QueueBtn.Text = "P";
            QueueBtn.UseVisualStyleBackColor = true;
            QueueBtn.Click += QueueBtn_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // TimeInfoLbl
            // 
            TimeInfoLbl.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TimeInfoLbl.Location = new Point(47, 83);
            TimeInfoLbl.Name = "TimeInfoLbl";
            TimeInfoLbl.Size = new Size(285, 38);
            TimeInfoLbl.TabIndex = 6;
            // 
            // EpisodeUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            Controls.Add(TimeInfoLbl);
            Controls.Add(QueueBtn);
            Controls.Add(button1);
            Controls.Add(DescriptionLbl);
            Controls.Add(titleLbl);
            Name = "EpisodeUC";
            Size = new Size(873, 124);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLbl;
        private Label DescriptionLbl;
        private Button button1;
        private Button QueueBtn;
        private System.Windows.Forms.Timer timer1;
        private Label TimeInfoLbl;
    }
}
