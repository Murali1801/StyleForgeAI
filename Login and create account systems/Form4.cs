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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            HideInvalidLabel();
            HideLabel();
        }

        private void HideLabel()
        {
            label_username.Visible = false;
            label_newpassword.Visible = false;
            label_confirmpassword.Visible = false;
            label_email.Visible = false;
        }

        private void HideInvalidLabel()
        {
            label_invalidusername.Visible = false;
            label_invalidemail.Visible = false;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_signup_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }





        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=STORM\\SQLEXPRESS;Initial Catalog=StyleForgeAI;Integrated Security=True;Trust Server Certificate=True";

            string email = txtEmail.Text;
            string username = txtUserName.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;


            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New Password and Confirm Password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Email = @Email";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Username", username);
                        checkCommand.Parameters.AddWithValue("@Email", email);

                        int userExists = (int)checkCommand.ExecuteScalar();
                        if (userExists == 0)
                        {
                            MessageBox.Show("Invalid Username or Email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            label_invalidemail.Visible = true;
                            label_invalidusername.Visible = true;
                            return;
                        }
                    }


                    string updateQuery = "UPDATE Users SET Password = @NewPassword WHERE Username = @Username AND Email = @Email";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@NewPassword", newPassword);
                        updateCommand.Parameters.AddWithValue("@Username", username);
                        updateCommand.Parameters.AddWithValue("@Email", email);

                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password reset successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            Form2 form2 = new Form2();
                            form2.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Password reset failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            txtUserName.Focus();
            label_username.Visible = true;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtEmail.Focus();
            label_email.Visible = true;
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
    }
}
