namespace HonorsClient.MenueUserControls
{
    partial class SearchResponseUC
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
            panel1 = new Panel();
            thumbnailPB = new PictureBox();
            AuthorLbl = new Label();
            textLbl = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)thumbnailPB).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(thumbnailPB);
            panel1.Controls.Add(AuthorLbl);
            panel1.Controls.Add(textLbl);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(862, 100);
            panel1.TabIndex = 0;
            // 
            // thumbnailPB
            // 
            thumbnailPB.Location = new Point(15, 7);
            thumbnailPB.Name = "thumbnailPB";
            thumbnailPB.Size = new Size(60, 60);
            thumbnailPB.TabIndex = 3;
            thumbnailPB.TabStop = false;
            // 
            // AuthorLbl
            // 
            AuthorLbl.AutoSize = true;
            AuthorLbl.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            AuthorLbl.Location = new Point(264, 57);
            AuthorLbl.Name = "AuthorLbl";
            AuthorLbl.Size = new Size(68, 20);
            AuthorLbl.TabIndex = 2;
            AuthorLbl.Text = "AUTHOR";
            // 
            // textLbl
            // 
            textLbl.AutoSize = true;
            textLbl.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            textLbl.Location = new Point(172, 11);
            textLbl.Name = "textLbl";
            textLbl.Size = new Size(69, 30);
            textLbl.TabIndex = 1;
            textLbl.Text = "TITLE";
            // 
            // button1
            // 
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(856, 94);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SearchResponseUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "SearchResponseUC";
            Size = new Size(862, 100);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)thumbnailPB).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label textLbl;
        private Button button1;
        private PictureBox thumbnailPB;
        private Label AuthorLbl;
    }
}
