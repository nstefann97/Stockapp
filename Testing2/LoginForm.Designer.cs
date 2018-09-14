using System;
using System.Windows.Forms;

namespace Testing2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.usernameLabel = new System.Windows.Forms.Label(); //label1
            this.usernamePanel = new System.Windows.Forms.Panel(); //panel1
            this.passwordLabel = new System.Windows.Forms.Label(); //label2
            this.memberLoginLabel = new System.Windows.Forms.Label(); //label3

            this.loginButton = new System.Windows.Forms.Button(); //button1

            this.usernameTextBox = new System.Windows.Forms.TextBox(); //textBox1
            this.passwordTextBox = new System.Windows.Forms.TextBox(); //textBox2
            this.microsoftLogoPictureBox = new System.Windows.Forms.PictureBox(); //pictureBox1

            this.exitIconLabel = new System.Windows.Forms.Label(); //label4

            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.microsoftLogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.usernameLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(174, 278);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(76, 24);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "Username";
            // 
            // panel1
            // 
            this.usernamePanel.BackColor = System.Drawing.SystemColors.ControlText;
            this.usernamePanel.Location = new System.Drawing.Point(65, 148);
            this.usernamePanel.Name = "usernamePanel";
            this.usernamePanel.Size = new System.Drawing.Size(284, 2);
            this.usernamePanel.TabIndex = 2;
            // 
            // label2
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.BackColor = System.Drawing.Color.Transparent;
            this.passwordLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(176, 343);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(74, 24);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Password";
            // 
            // label3
            // 
            this.memberLoginLabel.AutoSize = true;
            this.memberLoginLabel.BackColor = System.Drawing.Color.Transparent;
            this.memberLoginLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberLoginLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.memberLoginLabel.Location = new System.Drawing.Point(131, 153);
            this.memberLoginLabel.Name = "memberLoginLabel";
            this.memberLoginLabel.Size = new System.Drawing.Size(149, 36);
            this.memberLoginLabel.TabIndex = 4;
            this.memberLoginLabel.Text = "Member login";
            // 
            // button1
            // 
            this.loginButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.loginButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.loginButton.Location = new System.Drawing.Point(147, 445);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(133, 40);
            this.loginButton.TabIndex = 6;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
           
            this.AcceptButton = loginButton;/*if enter key is pressed, login button is virtually pressed*/
            // 
            // textBox1
            // 
            this.usernameTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.usernameTextBox.Location = new System.Drawing.Point(121, 305);
            this.usernameTextBox.Name = "textBox1";
            this.usernameTextBox.Size = new System.Drawing.Size(177, 22);
            this.usernameTextBox.TabIndex = 7;
            // 
            // textBox2
            // 
            this.passwordTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.passwordTextBox.Location = new System.Drawing.Point(121, 370);
            this.passwordTextBox.MaxLength = 17;
            this.passwordTextBox.Name = "textBox2";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(177, 22);
            this.passwordTextBox.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.microsoftLogoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.microsoftLogoPictureBox.BackgroundImage = ((System.Drawing.Image)
                (resources.GetObject("pictureBox1.BackgroundImage")));
            this.microsoftLogoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.microsoftLogoPictureBox.Location = new System.Drawing.Point(65, 68);
            this.microsoftLogoPictureBox.Name = "microsoftLogoPictureBox";
            this.microsoftLogoPictureBox.Size = new System.Drawing.Size(270, 79);
            this.microsoftLogoPictureBox.TabIndex = 9;
            this.microsoftLogoPictureBox.TabStop = false;
            // 
            // label4
            // 
            this.exitIconLabel.AutoSize = true;
            this.exitIconLabel.BackColor = System.Drawing.Color.Transparent;
            this.exitIconLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitIconLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exitIconLabel.Location = new System.Drawing.Point(375, 9);
            this.exitIconLabel.Name = "exitIconLabel";
            this.exitIconLabel.Size = new System.Drawing.Size(23, 26);
            this.exitIconLabel.TabIndex = 10;
            this.exitIconLabel.Text = "X";
            this.exitIconLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(410, 602);
            this.Controls.Add(this.exitIconLabel);
            this.Controls.Add(this.microsoftLogoPictureBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.memberLoginLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernamePanel);
            this.Controls.Add(this.usernameLabel);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            ((System.ComponentModel.ISupportInitialize)(this.microsoftLogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Panel usernamePanel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label memberLoginLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.PictureBox microsoftLogoPictureBox;

        public TextBox GetUsernameTextBox1()
        {
            return usernameTextBox;
        }

        public void SetUsernameTextBox(TextBox value)
        {
            usernameTextBox = value;
        }

        private Label exitIconLabel;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}
