using Microsoft.Data.SqlClient;

namespace Login_and_create_account_systems
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HideLabel();
        }

        //Hide Label
        private void HideLabel()
        {
            label_username.Visible = false;
            label_password.Visible = false;
            label_email.Visible = false;
        }


        //Label Appear
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

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.Focus();
            label_password.Visible = true;
        }

        //Application Exit
        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Clear All Label
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
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


        //Login Form
        private void label3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        //Login Form
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) ||
           string.IsNullOrWhiteSpace(txtEmail.Text) ||
           string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!checkbxterms.Checked)
            {
                MessageBox.Show("You must agree to the terms.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save to the database
            string connectionString = "Data Source=STORM\\SQLEXPRESS;Initial Catalog=StyleForgeAI;Integrated Security=True;Trust Server Certificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string email = txtEmail.Text;
                    if (!email.Contains("@") || !email.EndsWith(".com"))
                    {
                        MessageBox.Show("Invalid email format. Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string query = "INSERT INTO Users (Username, Email, Password, CreatedAt) VALUES (@Username, @Email, @Password, @CreatedAt)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", txtUserName.Text);
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        command.Parameters.AddWithValue("@Password", txtPassword.Text);
                        command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Signup successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Form2 form = new Form2();
                            form.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Signup failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
