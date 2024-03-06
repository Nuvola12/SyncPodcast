namespace HonorsClient
{
    partial class LoginForm
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
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            loginBtn = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 190);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(37, 266);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 1);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Location = new Point(37, 347);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 1);
            panel3.TabIndex = 2;
            // 
            // usernameTextBox
            // 
            usernameTextBox.BackColor = SystemColors.Menu;
            usernameTextBox.BorderStyle = BorderStyle.None;
            usernameTextBox.Location = new Point(37, 249);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(200, 16);
            usernameTextBox.TabIndex = 3;
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = SystemColors.Menu;
            passwordTextBox.BorderStyle = BorderStyle.None;
            passwordTextBox.Location = new Point(37, 330);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(200, 16);
            passwordTextBox.TabIndex = 4;
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(72, 382);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(127, 56);
            loginBtn.TabIndex = 5;
            loginBtn.Text = "LOGIN";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 450);
            Controls.Add(loginBtn);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginBtn;
    }
}