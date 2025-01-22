namespace HR_Department.DeskTop
{
    partial class authorization
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
            notVisibalePassword = new PictureBox();
            visibalePassword = new PictureBox();
            loginButton = new Button();
            passwordBox = new TextBox();
            loginBox = new TextBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            Autorization = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)notVisibalePassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)visibalePassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(90, 148, 230);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(983, 668);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gray;
            panel2.Controls.Add(notVisibalePassword);
            panel2.Controls.Add(visibalePassword);
            panel2.Controls.Add(loginButton);
            panel2.Controls.Add(passwordBox);
            panel2.Controls.Add(loginBox);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(Autorization);
            panel2.Location = new Point(240, 157);
            panel2.Name = "panel2";
            panel2.Size = new Size(489, 324);
            panel2.TabIndex = 0;
            // 
            // notVisibalePassword
            // 
            notVisibalePassword.Cursor = Cursors.Hand;
            notVisibalePassword.Image = Properties.Resources.eye_off_icon;
            notVisibalePassword.Location = new Point(411, 176);
            notVisibalePassword.Name = "notVisibalePassword";
            notVisibalePassword.Size = new Size(44, 39);
            notVisibalePassword.SizeMode = PictureBoxSizeMode.StretchImage;
            notVisibalePassword.TabIndex = 7;
            notVisibalePassword.TabStop = false;
            notVisibalePassword.Click += notVisibalePassword_Click;
            // 
            // visibalePassword
            // 
            visibalePassword.Cursor = Cursors.Hand;
            visibalePassword.Image = Properties.Resources.eye_icon;
            visibalePassword.Location = new Point(411, 176);
            visibalePassword.Name = "visibalePassword";
            visibalePassword.Size = new Size(44, 39);
            visibalePassword.SizeMode = PictureBoxSizeMode.StretchImage;
            visibalePassword.TabIndex = 6;
            visibalePassword.TabStop = false;
            visibalePassword.Click += visibalePassword_Click;
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.FromArgb(34, 184, 194);
            loginButton.Cursor = Cursors.Hand;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatStyle = FlatStyle.Popup;
            loginButton.ForeColor = Color.White;
            loginButton.Location = new Point(85, 252);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(320, 38);
            loginButton.TabIndex = 5;
            loginButton.Text = "Вход";
            loginButton.UseVisualStyleBackColor = false;
            // 
            // passwordBox
            // 
            passwordBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            passwordBox.Location = new Point(85, 176);
            passwordBox.Name = "passwordBox";
            passwordBox.PlaceholderText = "Пароль";
            passwordBox.Size = new Size(320, 39);
            passwordBox.TabIndex = 4;
            passwordBox.UseSystemPasswordChar = true;
            // 
            // loginBox
            // 
            loginBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            loginBox.Location = new Point(85, 103);
            loginBox.Multiline = true;
            loginBox.Name = "loginBox";
            loginBox.PlaceholderText = "Имя пользователя";
            loginBox.Size = new Size(320, 47);
            loginBox.TabIndex = 3;
            loginBox.TextChanged += loginBox_TextChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.locked_icon;
            pictureBox2.Location = new Point(37, 176);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(44, 47);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.user_icon;
            pictureBox1.Location = new Point(37, 103);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(44, 47);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // Autorization
            // 
            Autorization.Font = new Font("Comic Sans MS", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Autorization.ForeColor = Color.White;
            Autorization.Location = new Point(153, 10);
            Autorization.Name = "Autorization";
            Autorization.Size = new Size(202, 43);
            Autorization.TabIndex = 0;
            Autorization.Text = "Авторизация";
            // 
            // authorization
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 668);
            Controls.Add(panel1);
            Name = "authorization";
            Text = "authorization";
            Load += authorization_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)notVisibalePassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)visibalePassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label Autorization;
        private PictureBox pictureBox2;
        private TextBox passwordBox;
        private TextBox loginBox;
        private Button loginButton;
        private PictureBox visibalePassword;
        private PictureBox notVisibalePassword;
    }
}