namespace HonorsClient.UserControls
{
    partial class SettingsUC
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
            volumeTB = new TrackBar();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)volumeTB).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(330, 0);
            label1.Name = "label1";
            label1.Size = new Size(122, 37);
            label1.TabIndex = 1;
            label1.Text = "Settings";
            // 
            // volumeTB
            // 
            volumeTB.AutoSize = false;
            volumeTB.Location = new Point(47, 128);
            volumeTB.Maximum = 100;
            volumeTB.Name = "volumeTB";
            volumeTB.Size = new Size(745, 45);
            volumeTB.TabIndex = 2;
            volumeTB.Value = 50;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(374, 97);
            label2.Name = "label2";
            label2.Size = new Size(78, 28);
            label2.TabIndex = 3;
            label2.Text = "Volume";
            label2.Click += label2_Click;
            // 
            // SettingsUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(volumeTB);
            Controls.Add(label1);
            Name = "SettingsUC";
            Size = new Size(908, 561);
            ((System.ComponentModel.ISupportInitialize)volumeTB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TrackBar volumeTB;
        private Label label2;
    }
}
