namespace Login_and_create_account_systems
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel_backimg = new Panel();
            pictureBox1 = new PictureBox();
            panel_signup = new Panel();
            btnClear = new Button();
            label_password = new Label();
            label_email = new Label();
            label_username = new Label();
            exit = new PictureBox();
            btnSignUp = new Button();
            checkbxterms = new CheckBox();
            txtPassword = new TextBox();
            showPassword = new PictureBox();
            pictureBox7 = new PictureBox();
            txtEmail = new TextBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            label3 = new Label();
            txtUserName = new TextBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            panel_backimg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel_signup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)showPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
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
            // panel_signup
            // 
            panel_signup.BackColor = Color.White;
            panel_signup.Controls.Add(btnClear);
            panel_signup.Controls.Add(label_password);
            panel_signup.Controls.Add(label_email);
            panel_signup.Controls.Add(label_username);
            panel_signup.Controls.Add(exit);
            panel_signup.Controls.Add(btnSignUp);
            panel_signup.Controls.Add(checkbxterms);
            panel_signup.Controls.Add(txtPassword);
            panel_signup.Controls.Add(showPassword);
            panel_signup.Controls.Add(pictureBox7);
            panel_signup.Controls.Add(txtEmail);
            panel_signup.Controls.Add(pictureBox4);
            panel_signup.Controls.Add(pictureBox5);
            panel_signup.Controls.Add(label3);
            panel_signup.Controls.Add(txtUserName);
            panel_signup.Controls.Add(pictureBox3);
            panel_signup.Controls.Add(pictureBox2);
            panel_signup.Controls.Add(label2);
            panel_signup.Controls.Add(label1);
            panel_signup.Dock = DockStyle.Right;
            panel_signup.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel_signup.ForeColor = Color.Black;
            panel_signup.Location = new Point(650, 0);
            panel_signup.MaximumSize = new Size(450, 700);
            panel_signup.MinimumSize = new Size(450, 700);
            panel_signup.Name = "panel_signup";
            panel_signup.Size = new Size(450, 700);
            panel_signup.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.White;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Nirmala UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Image = (Image)resources.GetObject("btnClear.Image");
            btnClear.Location = new Point(40, 565);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(366, 73);
            btnClear.TabIndex = 20;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.BackColor = Color.FromArgb(192, 129, 247);
            label_password.Font = new Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_password.ForeColor = Color.White;
            label_password.Location = new Point(84, 343);
            label_password.Name = "label_password";
            label_password.Size = new Size(76, 20);
            label_password.TabIndex = 19;
            label_password.Text = "Password";
            // 
            // label_email
            // 
            label_email.AutoSize = true;
            label_email.BackColor = Color.FromArgb(192, 129, 247);
            label_email.Font = new Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_email.ForeColor = Color.White;
            label_email.Location = new Point(84, 252);
            label_email.Name = "label_email";
            label_email.Size = new Size(47, 20);
            label_email.TabIndex = 18;
            label_email.Text = "Email";
            // 
            // label_username
            // 
            label_username.AutoSize = true;
            label_username.BackColor = Color.FromArgb(192, 129, 247);
            label_username.Font = new Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_username.ForeColor = Color.White;
            label_username.Location = new Point(84, 162);
            label_username.Name = "label_username";
            label_username.Size = new Size(80, 20);
            label_username.TabIndex = 17;
            label_username.Text = "Username";
            // 
            // exit
            // 
            exit.Image = (Image)resources.GetObject("exit.Image");
            exit.Location = new Point(398, 12);
            exit.Name = "exit";
            exit.Size = new Size(40, 40);
            exit.SizeMode = PictureBoxSizeMode.Zoom;
            exit.TabIndex = 16;
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
            btnSignUp.Location = new Point(40, 476);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(366, 73);
            btnSignUp.TabIndex = 14;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = false;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // checkbxterms
            // 
            checkbxterms.AutoSize = true;
            checkbxterms.FlatStyle = FlatStyle.Flat;
            checkbxterms.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkbxterms.Location = new Point(151, 436);
            checkbxterms.Name = "checkbxterms";
            checkbxterms.Size = new Size(255, 24);
            checkbxterms.TabIndex = 13;
            checkbxterms.Text = "I accept your terms and conditions";
            checkbxterms.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(192, 129, 247);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(84, 361);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(240, 31);
            txtPassword.TabIndex = 12;
            txtPassword.Text = "Password";
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // showPassword
            // 
            showPassword.Image = (Image)resources.GetObject("showPassword.Image");
            showPassword.Location = new Point(338, 357);
            showPassword.Name = "showPassword";
            showPassword.Size = new Size(40, 40);
            showPassword.SizeMode = PictureBoxSizeMode.Zoom;
            showPassword.TabIndex = 11;
            showPassword.TabStop = false;
            showPassword.Click += showPassword_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(41, 340);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(366, 73);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 10;
            pictureBox7.TabStop = false;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(192, 129, 247);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = Color.White;
            txtEmail.Location = new Point(84, 270);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(240, 31);
            txtEmail.TabIndex = 9;
            txtEmail.Text = "Email";
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(338, 266);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(40, 40);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 8;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(41, 250);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(366, 73);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 7;
            pictureBox5.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Cursor = Cursors.Hand;
            label3.Font = new Font("Nirmala UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(126, 34, 206);
            label3.Location = new Point(208, 122);
            label3.Name = "label3";
            label3.Size = new Size(62, 23);
            label3.TabIndex = 6;
            label3.Text = "Sign in";
            label3.Click += label3_Click;
            // 
            // txtUserName
            // 
            txtUserName.BackColor = Color.FromArgb(192, 129, 247);
            txtUserName.BorderStyle = BorderStyle.None;
            txtUserName.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUserName.ForeColor = Color.White;
            txtUserName.Location = new Point(84, 180);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(240, 31);
            txtUserName.TabIndex = 5;
            txtUserName.Text = "Username";
            txtUserName.TextChanged += txtUserName_TextChanged;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(338, 176);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(40, 40);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(41, 160);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(366, 73);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Nirmala UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(42, 122);
            label2.Name = "label2";
            label2.Size = new Size(171, 23);
            label2.TabIndex = 1;
            label2.Text = "Create an account or";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Nirmala UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(42, 55);
            label1.Name = "label1";
            label1.Size = new Size(165, 54);
            label1.TabIndex = 0;
            label1.Text = "Sign up";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(panel_signup);
            Controls.Add(panel_backimg);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel_backimg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel_signup.ResumeLayout(false);
            panel_signup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)showPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_backimg;
        private Panel panel_signup;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label3;
        private TextBox txtUserName;
        private Button btnSignUp;
        private CheckBox checkbxterms;
        private TextBox txtPassword;
        private PictureBox showPassword;
        private PictureBox pictureBox7;
        private TextBox txtEmail;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox exit;
        private Label label_password;
        private Label label_email;
        private Label label_username;
        private Button btnClear;
    }
}
