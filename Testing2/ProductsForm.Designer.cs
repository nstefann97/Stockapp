namespace Testing2
{
    partial class ProductsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsForm));
            this.usernameLabel = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.loginButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.exitIconLabel = new System.Windows.Forms.Label();
            this.prevOrders = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.usernameLabel.Location = new System.Drawing.Point(185, 54);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(153, 33);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Welcome,";
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.welcomeLabel.Location = new System.Drawing.Point(343, 57);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(93, 32);
            this.welcomeLabel.TabIndex = 1;
            this.welcomeLabel.Text = "label2";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(631, 9);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(30, 29);
            this.bunifuCustomLabel1.TabIndex = 2;
            this.bunifuCustomLabel1.Text = "X";
            this.bunifuCustomLabel1.Click += new System.EventHandler(this.bunifuCustomLabel1_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.SteelBlue;
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.loginButton.Location = new System.Drawing.Point(349, 490);
            this.loginButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(151, 54);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Request";
            this.loginButton.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SteelBlue;
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(548, 9);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 26);
            this.button2.TabIndex = 4;
            this.button2.Text = "Sign out";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // exitIconLabel
            // 
            this.exitIconLabel.AutoSize = true;
            this.exitIconLabel.BackColor = System.Drawing.Color.Transparent;
            this.exitIconLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.exitIconLabel.Location = new System.Drawing.Point(26, 555);
            this.exitIconLabel.Name = "exitIconLabel";
            this.exitIconLabel.Size = new System.Drawing.Size(619, 17);
            this.exitIconLabel.TabIndex = 6;
            this.exitIconLabel.Text = "If you no longer see certain products, you either requested them or you don\'t hav" +
    "e acces to them";
            // 
            // prevOrders
            // 
            this.prevOrders.BackColor = System.Drawing.Color.SteelBlue;
            this.prevOrders.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.prevOrders.Location = new System.Drawing.Point(216, 498);
            this.prevOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.prevOrders.Name = "prevOrders";
            this.prevOrders.Size = new System.Drawing.Size(109, 42);
            this.prevOrders.TabIndex = 7;
            this.prevOrders.Text = "View previous orders";
            this.prevOrders.UseVisualStyleBackColor = false;
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(673, 581);
            this.Controls.Add(this.prevOrders);
            this.Controls.Add(this.exitIconLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.usernameLabel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ProductsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label welcomeLabel;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label exitIconLabel;
        private System.Windows.Forms.Button prevOrders;
    }
}