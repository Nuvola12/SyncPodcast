namespace HonorsClient
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuePanel = new Panel();
            SettingsBtn = new Button();
            LibraryBtn = new Button();
            SearchBtn = new Button();
            controlPanel = new Panel();
            mediaControluc1 = new MenueUserControls.MediaControlUC();
            windowPanel = new Panel();
            menuePanel.SuspendLayout();
            controlPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuePanel
            // 
            menuePanel.BackColor = SystemColors.AppWorkspace;
            menuePanel.Controls.Add(SettingsBtn);
            menuePanel.Controls.Add(LibraryBtn);
            menuePanel.Controls.Add(SearchBtn);
            menuePanel.Dock = DockStyle.Left;
            menuePanel.Location = new Point(0, 0);
            menuePanel.Name = "menuePanel";
            menuePanel.Size = new Size(129, 561);
            menuePanel.TabIndex = 0;
            // 
            // SettingsBtn
            // 
            SettingsBtn.Location = new Point(3, 277);
            SettingsBtn.Name = "SettingsBtn";
            SettingsBtn.Size = new Size(119, 72);
            SettingsBtn.TabIndex = 2;
            SettingsBtn.Text = "Settings";
            SettingsBtn.UseVisualStyleBackColor = true;
            SettingsBtn.Click += SettingsBtn_Click;
            // 
            // LibraryBtn
            // 
            LibraryBtn.Location = new Point(3, 199);
            LibraryBtn.Name = "LibraryBtn";
            LibraryBtn.Size = new Size(119, 72);
            LibraryBtn.TabIndex = 1;
            LibraryBtn.Text = "Library";
            LibraryBtn.UseVisualStyleBackColor = true;
            LibraryBtn.Click += LibraryBtn_Click;
            // 
            // SearchBtn
            // 
            SearchBtn.Location = new Point(3, 121);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(119, 72);
            SearchBtn.TabIndex = 0;
            SearchBtn.Text = "Search";
            SearchBtn.UseVisualStyleBackColor = true;
            SearchBtn.Click += SearchBtn_Click;
            // 
            // controlPanel
            // 
            controlPanel.BackColor = SystemColors.ControlDarkDark;
            controlPanel.Controls.Add(mediaControluc1);
            controlPanel.Dock = DockStyle.Bottom;
            controlPanel.Location = new Point(129, 459);
            controlPanel.Name = "controlPanel";
            controlPanel.Size = new Size(908, 102);
            controlPanel.TabIndex = 1;
            // 
            // mediaControluc1
            // 
            mediaControluc1.Dock = DockStyle.Fill;
            mediaControluc1.Location = new Point(0, 0);
            mediaControluc1.Name = "mediaControluc1";
            mediaControluc1.Size = new Size(908, 102);
            mediaControluc1.TabIndex = 0;
            // 
            // windowPanel
            // 
            windowPanel.Dock = DockStyle.Fill;
            windowPanel.Location = new Point(129, 0);
            windowPanel.Name = "windowPanel";
            windowPanel.Size = new Size(908, 561);
            windowPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1037, 561);
            Controls.Add(controlPanel);
            Controls.Add(windowPanel);
            Controls.Add(menuePanel);
            Name = "MainForm";
            Text = "Honors Project: Synchronous Podcasting";
            menuePanel.ResumeLayout(false);
            controlPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel menuePanel;
        private Button SettingsBtn;
        private Button LibraryBtn;
        private Button SearchBtn;
        private Panel controlPanel;
        private Panel windowPanel;
        private MenueUserControls.MediaControlUC mediaControluc1;
    }
}