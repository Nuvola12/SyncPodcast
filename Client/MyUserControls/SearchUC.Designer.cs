namespace HonorsClient.UserControls
{
    partial class SearchUC
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
            SearchTextBox = new TextBox();
            SearchBtn = new Button();
            SearchResponsePanel = new Panel();
            SuspendLayout();
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(18, 15);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(766, 23);
            SearchTextBox.TabIndex = 0;
            // 
            // SearchBtn
            // 
            SearchBtn.Location = new Point(790, 15);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(115, 23);
            SearchBtn.TabIndex = 1;
            SearchBtn.Text = "SEARCH";
            SearchBtn.UseVisualStyleBackColor = true;
            SearchBtn.Click += SearchBtn_ClickAsync;
            // 
            // SearchResponsePanel
            // 
            SearchResponsePanel.AutoScroll = true;
            SearchResponsePanel.Location = new Point(18, 44);
            SearchResponsePanel.Name = "SearchResponsePanel";
            SearchResponsePanel.Size = new Size(887, 514);
            SearchResponsePanel.TabIndex = 2;
            // 
            // SearchUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(SearchResponsePanel);
            Controls.Add(SearchBtn);
            Controls.Add(SearchTextBox);
            Name = "SearchUC";
            Size = new Size(908, 561);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SearchTextBox;
        private Button SearchBtn;
        private Panel SearchResponsePanel;
    }
}
