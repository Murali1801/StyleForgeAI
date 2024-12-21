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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            HideLabel();
        }

        private void HideLabel()
        {
            label_currentpassword.Visible = false;
            label_newpassword.Visible = false;
            label_confirmpassword.Visible = false;

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

           
            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New Password and Confirm Password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (ChangePassword(UserSession.Username, currentPassword, newPassword))
            {
                MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            txtCurrentPassword.Focus();
            label_currentpassword.Visible = true;
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            txtNewPassword.Focus();
            label_newpassword.Visible = true;
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            txtConfirmPassword.Focus();
            label_confirmpassword.Visible = true;
        }

        private void showCurrentPassword_Click(object sender, EventArgs e)
        {
            if (txtCurrentPassword.PasswordChar == '*')
            {
                txtCurrentPassword.PasswordChar = '\0';
            }
            else
            {
                txtCurrentPassword.PasswordChar = '*';
            }
        }

        private void showNewPassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.PasswordChar == '*')
            {
                txtNewPassword.PasswordChar = '\0';
            }
            else
            {
                txtNewPassword.PasswordChar = '*';
            }
        }

        private void showConfirmPassword_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.PasswordChar == '*')
            {
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtConfirmPassword.PasswordChar = '*';
            }
        }

        private bool ChangePassword(string username, string currentPassword, string newPassword)
        {
            string connectionString = "Data Source=styleforge-ms-sql-server.ch0q4qge64ch.eu-north-1.rds.amazonaws.com;Initial Catalog=StyleForgeDB;Persist Security Info=True;User ID=admin;Password=StyleForge#123;Trust Server Certificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                   
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", currentPassword);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        
                        string updateQuery = "UPDATE Users SET Password = @NewPassword WHERE Username = @Username";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@NewPassword", newPassword);
                        updateCmd.Parameters.AddWithValue("@Username", username);

                        updateCmd.ExecuteNonQuery();

                        Form2 form2 = new Form2();
                        form2.Show();
                        this.Hide();

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

    }
}
