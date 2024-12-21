using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Login_and_create_account_systems
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            HideInvalidLabel();
            HideLabel();
        }


        //Hide Label
        private void HideLabel()
        {
            label_username.Visible = false;
            label_password.Visible = false;
        }


        //Label Appear
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            txtUserName.Focus();
            label_username.Visible = true;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.Focus();
            label_password.Visible = true;
        }


        //Show Password
        private void showPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }


        //Application Exit
        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Sign Up Form
        private void label_signup_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }


        //Hide Invalid Label
        private void HideInvalidLabel()
        {
            label_invalidusername.Visible = false;
            label_invalidpassword.Visible = false;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string username = txtUserName.Text;
            string password = txtPassword.Text;

            if (IsValidLogin(username, password))
            {
                MessageBox.Show("Login Successful!");
                Form3 form = new Form3();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.");
                label_invalidusername.Visible = true;
                label_invalidpassword.Visible = true;
            }
        }

        private bool IsValidLogin(string username, string password)
        {
            string connectionString = "Data Source=styleforge-ms-sql-server.ch0q4qge64ch.eu-north-1.rds.amazonaws.com;Initial Catalog=StyleForgeDB;Persist Security Info=True;User ID=admin;Password=StyleForge#123;Trust Server Certificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                   
                    string query = @"SELECT UserID, Username, Password, Email, LastLogin, CreatedAt 
                             FROM Users WHERE Username = @Username AND Password = @Password";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                      
                        UserSession.UserID = reader.GetInt32(0);
                        UserSession.Username = reader.GetString(1);
                        UserSession.Password = reader.GetString(2);
                        UserSession.Email = reader.GetString(3);
                        UserSession.LastLogin = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        UserSession.CreatedAt = reader.GetDateTime(5);

                        reader.Close(); 

                        
                        UpdateLastLogin(conn, username);

                        return true;
                    }
                    else
                    {
                        return false; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }

        
        private void UpdateLastLogin(SqlConnection conn, string username)
        {
            string updateQuery = "UPDATE Users SET LastLogin = @LastLogin WHERE Username = @Username";

            using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
            {
                updateCmd.Parameters.AddWithValue("@LastLogin", DateTime.Now);
                updateCmd.Parameters.AddWithValue("@Username", username);

                updateCmd.ExecuteNonQuery();
            }
        }



        private void label_forgotpassword_Click(object sender, EventArgs e)
        {
            UserSession.Username = string.Empty;
            Form4 form = new Form4();
            form.Show();
            this.Hide();
        }
    }
}
