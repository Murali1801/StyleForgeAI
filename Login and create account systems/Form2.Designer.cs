namespace Login_and_create_account_systems
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            panel_backimg = new Panel();
            pictureBox1 = new PictureBox();
            panel_Login = new Panel();
            label_invalidpassword = new Label();
            label_invalidusername = new Label();
            label_forgotpassword = new Label();
            checkBox1 = new CheckBox();
            label4 = new Label();
            label_password = new Label();
            label_username = new Label();
            exit = new PictureBox();
            btnSignUp = new Button();
            txtPassword = new TextBox();
            showPassword = new PictureBox();
            pictureBox7 = new PictureBox();
            label_signup = new Label();
            txtUserName = new TextBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            panel_backimg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel_Login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)showPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel_backimg
            // 
            panel_backimg.Controls.Add(pictureBox1);
            panel_backimg.Dock = DockStyle.Left;
            panel_backimg.Location = new Point(0, 0);
            panel_backimg.Name = "panel_backimg";
            panel_backimg.Size = new Size(650, 700);
            panel_backimg.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(650, 700);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel_Login
            // 
            panel_Login.BackColor = Color.White;
            panel_Login.Controls.Add(label_invalidpassword);
            panel_Login.Controls.Add(label_invalidusername);
            panel_Login.Controls.Add(label_forgotpassword);
            panel_Login.Controls.Add(checkBox1);
            panel_Login.Controls.Add(label4);
            panel_Login.Controls.Add(label_password);
            panel_Login.Controls.Add(label_username);
            panel_Login.Controls.Add(exit);
            panel_Login.Controls.Add(btnSignUp);
            panel_Login.Controls.Add(txtPassword);
            panel_Login.Controls.Add(showPassword);
            panel_Login.Controls.Add(pictureBox7);
            panel_Login.Controls.Add(label_signup);
            panel_Login.Controls.Add(txtUserName);
            panel_Login.Controls.Add(pictureBox3);
            panel_Login.Controls.Add(pictureBox2);
            panel_Login.Controls.Add(label2);
            panel_Login.Controls.Add(label1);
            panel_Login.Dock = DockStyle.Right;
            panel_Login.Location = new Point(650, 0);
            panel_Login.Name = "panel_Login";
            panel_Login.Size = new Size(450, 700);
            panel_Login.TabIndex = 1;
            // 
            // label_invalidpassword
            // 
            label_invalidpassword.AutoSize = true;
            label_invalidpassword.Font = new Font("Nirmala UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_invalidpassword.ForeColor = Color.Red;
            label_invalidpassword.Location = new Point(84, 418);
            label_invalidpassword.Name = "label_invalidpassword";
            label_invalidpassword.Size = new Size(134, 23);
            label_invalidpassword.TabIndex = 43;
            label_invalidpassword.Text = "Password invalid";
            // 
            // label_invalidusername
            // 
            label_invalidusername.AutoSize = true;
            label_invalidusername.Font = new Font("Nirmala UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_invalidusername.ForeColor = Color.Red;
            label_invalidusername.Location = new Point(84, 311);
            label_invalidusername.Name = "label_invalidusername";
            label_invalidusername.Size = new Size(141, 23);
            label_invalidusername.TabIndex = 42;
            label_invalidusername.Text = "Username invalid";
            // 
            // label_forgotpassword
            // 
            label_forgotpassword.AutoSize = true;
            label_forgotpassword.Font = new Font("Nirmala UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_forgotpassword.ForeColor = Color.Black;
            label_forgotpassword.Location = new Point(236, 450);
            label_forgotpassword.Name = "label_forgotpassword";
            label_forgotpassword.Size = new Size(171, 23);
            label_forgotpassword.TabIndex = 41;
            label_forgotpassword.Text = "I forgot my password";
            label_forgotpassword.Click += label_forgotpassword_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.FlatStyle = FlatStyle.Flat;
            checkBox1.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox1.Location = new Point(42, 449);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(125, 24);
            checkBox1.TabIndex = 40;
            checkBox1.Text = "Remember me";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Nirmala UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(77, 577);
            label4.Name = "label4";
            label4.Size = new Size(195, 23);
            label4.TabIndex = 39;
            label4.Text = "Don't have an account ?";
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.BackColor = Color.FromArgb(192, 129, 247);
            label_password.Font = new Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_password.ForeColor = Color.White;
            label_password.Location = new Point(84, 345);
            label_password.Name = "label_password";
            label_password.Size = new Size(76, 20);
            label_password.TabIndex = 38;
            label_password.Text = "Password";
            // 
            // label_username
            // 
            label_username.AutoSize = true;
            label_username.BackColor = Color.FromArgb(192, 129, 247);
            label_username.Font = new Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_username.ForeColor = Color.White;
            label_username.Location = new Point(84, 237);
            label_username.Name = "label_username";
            label_username.Size = new Size(80, 20);
            label_username.TabIndex = 36;
            label_username.Text = "Username";
            // 
            // exit
            // 
            exit.Image = (Image)resources.GetObject("exit.Image");
            exit.Location = new Point(398, 12);
            exit.Name = "exit";
            exit.Size = new Size(40, 40);
            exit.SizeMode = PictureBoxSizeMode.Zoom;
            exit.TabIndex = 35;
            exit.TabStop = false;
            exit.Click += exit_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.BackColor = Color.White;
            btnSignUp.Cursor = Cursors.Hand;
            btnSignUp.FlatAppearance.BorderSize = 0;
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.Font = new Font("Nirmala UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignUp.ForeColor = Color.White;
            btnSignUp.Image = (Image)resources.GetObject("btnSignUp.Image");
            btnSignUp.Location = new Point(40, 491);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(366, 73);
            btnSignUp.TabIndex = 34;
            btnSignUp.Text = "Login";
            btnSignUp.UseVisualStyleBackColor = false;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(192, 129, 247);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(84, 363);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(240, 31);
            txtPassword.TabIndex = 32;
            txtPassword.Text = "Password";
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // showPassword
            // 
            showPassword.Image = (Image)resources.GetObject("showPassword.Image");
            showPassword.Location = new Point(338, 359);
            showPassword.Name = "showPassword";
            showPassword.Size = new Size(40, 40);
            showPassword.SizeMode = PictureBoxSizeMode.Zoom;
            showPassword.TabIndex = 31;
            showPassword.TabStop = false;
            showPassword.Click += showPassword_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(41, 342);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(366, 73);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 30;
            pictureBox7.TabStop = false;
            // 
            // label_signup
            // 
            label_signup.AutoSize = true;
            label_signup.Cursor = Cursors.Hand;
            label_signup.Font = new Font("Nirmala UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_signup.ForeColor = Color.FromArgb(126, 34, 206);
            label_signup.Location = new Point(278, 577);
            label_signup.Name = "label_signup";
            label_signup.Size = new Size(68, 23);
            label_signup.TabIndex = 26;
            label_signup.Text = "Sign up";
            label_signup.Click += label_signup_Click;
            // 
            // txtUserName
            // 
            txtUserName.BackColor = Color.FromArgb(192, 129, 247);
            txtUserName.BorderStyle = BorderStyle.None;
            txtUserName.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUserName.ForeColor = Color.White;
            txtUserName.Location = new Point(84, 255);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(240, 31);
            txtUserName.TabIndex = 25;
            txtUserName.Text = "Username";
            txtUserName.TextChanged += txtUserName_TextChanged;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(338, 251);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(40, 40);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 24;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(41, 235);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(366, 73);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 23;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Nirmala UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(43, 183);
            label2.Name = "label2";
            label2.Size = new Size(215, 23);
            label2.TabIndex = 22;
            label2.Text = "Login with your credentials";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Nirmala UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(35, 116);
            label1.Name = "label1";
            label1.Size = new Size(297, 54);
            label1.TabIndex = 21;
            label1.Text = "Welcome Back";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(panel_Login);
            Controls.Add(panel_backimg);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            panel_backimg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel_Login.ResumeLayout(false);
            panel_Login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)showPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_backimg;
        private PictureBox pictureBox1;
        private Panel panel_Login;
        private Label label_password;
        private Label label_username;
        private PictureBox exit;
        private Button btnSignUp;
        private TextBox txtPassword;
        private PictureBox showPassword;
        private PictureBox pictureBox7;
        private Label label_signup;
        private TextBox txtUserName;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label_forgotpassword;
        private CheckBox checkBox1;
        private Label label_invalidpassword;
        private Label label_invalidusername;
    }
}