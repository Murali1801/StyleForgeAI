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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            HideNav();
            showLastLogin();    
            LoadProfileFromDatabase();  
            LoadImageFromDatabase();
        }

        private void HideNav()
        {
            panel_hidden.Visible = true;

        }

        private void showLastLogin()
        {
            label_usernameses.Text = UserSession.Username;
        }

        //Application Exit


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (panel_hidden.Visible == false)
            {
                panel_hidden.Visible = true;
                this.Size = new Size(1400, 800);
            }
            else
            {
                panel_hidden.Visible = false;
                this.Size = new Size(1240, 800);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            UserSession.ClearSession();
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserSession.ClearSession();
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void LoadImageFromDatabase()
        {
            string connectionString = "Data Source=styleforge-ms-sql-server.ch0q4qge64ch.eu-north-1.rds.amazonaws.com;Initial Catalog=StyleForgeDB;Persist Security Info=True;User ID=admin;Password=StyleForge#123;Trust Server Certificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT FullBodyPic FROM Users WHERE Username = @Username";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", UserSession.Username);

                    object result = cmd.ExecuteScalar(); // Get the image data

                    if (result != DBNull.Value && result is byte[] imageBytes)
                    {
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            Image img = Image.FromStream(ms);

                            // Fix the rotation using EXIF metadata
                            img = CorrectImageOrientation(img);

                            pictureBox4.Image = img;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No profile picture found or data is NULL.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while loading the image: " + ex.Message);
                }
            }
        }

        // Corrects the image orientation based on EXIF data
        private Image CorrectImageOrientation(Image img)
        {
            if (img.PropertyIdList.Contains(0x0112)) // 0x0112 = PropertyTagOrientation
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                int orientation = img.GetPropertyItem(0x0112).Value[0];
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                switch (orientation)
                {
                    case 3: // Rotate 180
                        img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 6: // Rotate 90 clockwise
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 8: // Rotate 90 counterclockwise
                        img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                }

                // Remove the orientation property to prevent future issues
                img.RemovePropertyItem(0x0112);
            }

            return img;
        }


        private void LoadProfileFromDatabase()
        {
            string connectionString = "Data Source=styleforge-ms-sql-server.ch0q4qge64ch.eu-north-1.rds.amazonaws.com;Initial Catalog=StyleForgeDB;Persist Security Info=True;User ID=admin;Password=StyleForge#123;Trust Server Certificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT ProfilePicture FROM Users WHERE Username = @Username";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", UserSession.Username);

                    byte[] imageBytes = (byte[])cmd.ExecuteScalar();

                    if (imageBytes != null)
                    {
                        // Convert byte[] to Image and display in PictureBox
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            profile.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No profile picture found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
