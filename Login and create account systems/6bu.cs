/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;

namespace Login_and_create_account_systems
{
    public partial class Form6 : Form
    {

        public Form6()
        {
            InitializeComponent();
            HideNav();
            LoadProfileFromDatabase();
            LoadImageFromDatabase();

        }

        private void HideNav()
        {
            panel_hidden.Visible = true;

        }
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
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



        /*private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                 string imagePath = openFileDialog.FileName;

                // Convert the selected image to byte[]
                byte[] imageBytes = File.ReadAllBytes(imagePath);

                // Call the method to save it to the database
                SaveImageToDatabase(imageBytes);

            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Display the image in the picture box
                    pictureBox1.Image = new Bitmap(openFileDialog.FileName);

                    // Convert the image to a Base64 string
                    string base64String = ImageToBase64(openFileDialog.FileName);
                    MessageBox.Show(base64String);

                   

                    // Display the Base64 string in a message box or text box
                    MessageBox.Show(base64String);
                }
            }
        }

        private string ImageToBase64(string imagePath)
        {
            byte[] imageBytes = File.ReadAllBytes(imagePath);

            // Call the method to save it to the database
            SaveImageToDatabase(imageBytes);

            return Convert.ToBase64String(imageBytes);

            
        }



        public class ImageUploader
        {
            private readonly string apiKey = "YOUR_API_KEY"; // Replace with your actual API key

            public async Task<string> UploadImageAsync(string imagePath)
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        // API URL
                        string apiUrl = "https://api.imghippo.com/v1/upload";

                        // Read the image file
                        byte[] imageBytes = File.ReadAllBytes(imagePath);
                        ByteArrayContent fileContent = new ByteArrayContent(imageBytes);
                        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg"); // Adjust depending on image type

                        // Set up the MultipartFormDataContent
                        MultipartFormDataContent formData = new MultipartFormDataContent();
                        formData.Add(fileContent, "file", Path.GetFileName(imagePath)); // "file" is the field name in the API
                        formData.Add(new StringContent(apiKey), "api_key"); // Add the API key

                        // Make the POST request to the API
                        HttpResponseMessage response = await client.PostAsync(apiUrl, formData);

                        // Check if the request was successful
                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();

                            // Parse the JSON response
                            JObject jsonResponse = JObject.Parse(responseContent);

                            // Extract the view_url from the response and return it
                            string viewUrl = jsonResponse["data"]?["view_url"]?.ToString();
                            MessageBox.Show(viewUrl);

                            if (!string.IsNullOrEmpty(viewUrl))
                            {
                                return viewUrl;  // Return the view_url
                            }
                            else
                            {
                                Console.WriteLine("Error: view_url not found in response.");
                                return string.Empty;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: " + response.StatusCode);
                            return string.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return string.Empty;
                }
            }


            private void btnUploadmadarchod()
            {
                MessageBox.Show("Clicked Hue Hue BHUE!");

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string imagePath = openFileDialog.FileName;
                        string viewUrl = await uploader.UploadImageAsync(imagePath);

                        if (!string.IsNullOrEmpty(viewUrl))
                        {
                            MessageBox.Show("Image uploaded successfully! View URL: " + viewUrl);
                        }
                        else
                        {
                            MessageBox.Show("Image upload failed.");
                        }



                        string base64String = ImageToBase64(imagePath);
                        if (!string.IsNullOrEmpty(base64String) && base64String.Length > 50)
                        {
                            Console.WriteLine(base64String); // Log first 50 characters
                            MessageBox.Show(base64String);// Display first 50 characters
                        }

                        // Store Base64 string in UserSession
                        UserSession.ImageBase64 = base64String;

                        SaveBase64ImageToDatabase(base64String);
                    }
                }
            }




            private string ImageToBase64(string imagePath)
            {
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(imagePath);

                    // Convert to Base64 string
                    string base64String = Convert.ToBase64String(imageBytes);

                    // Print or show the Base64 string
                    Console.WriteLine(base64String);  // Log to console
                    MessageBox.Show(base64String.Substring(0, 50), "Base64 Preview");  // Show the first 50 characters

                    return base64String;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error converting image to Base64: " + ex.Message);
                    return string.Empty;
                }
            }




            private void SaveBase64ImageToDatabase(string base64String)
            {
                string connectionString = "Data Source=styleforge-ms-sql-server.ch0q4qge64ch.eu-north-1.rds.amazonaws.com;Initial Catalog=StyleForgeDB;Persist Security Info=True;User ID=admin;Password=StyleForge#123;Trust Server Certificate=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "INSERT INTO UserImages (UserID, ImageBase64) VALUES ((SELECT UserID FROM Users WHERE Username = @Username), @ImageBase64)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Username", UserSession.Username);
                        cmd.Parameters.AddWithValue("@ImageBase64", base64String);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Image uploaded successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No rows affected. Please check the data and try again.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }



            private void SaveImageToDatabase(byte[] imageBytes)
            {
                string connectionString = "Data Source=styleforge-ms-sql-server.ch0q4qge64ch.eu-north-1.rds.amazonaws.com;Initial Catalog=StyleForgeDB;Persist Security Info=True;User ID=admin;Password=StyleForge#123;Trust Server Certificate=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        string query = "UPDATE Users SET FullBodyPic = @FullBodyPic WHERE Username = @Username";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@FullBodyPic", imageBytes);
                        cmd.Parameters.AddWithValue("@Username", UserSession.Username); // Assuming Username is stored in session

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Image uploaded successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
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
                    int orientation = img.GetPropertyItem(0x0112).Value[0];

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






            private void btnBrowseFile_Click(object sender, EventArgs e)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;

                    // Convert the selected image to byte[]
                    byte[] imageBytes = File.ReadAllBytes(imagePath);

                    // Call the method to save it to the database
                    SaveImageToDatabase(imageBytes);
                }
            }

            private void btnShowPic_Click(object sender, EventArgs e)
            {
                MessageBox.Show(UserSession.ImageBase64);
                btnUploadmadarchod();
                LoadImageFromDatabase();
            }

            private void btnProfile_Click(object sender, EventArgs e)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;

                    // Convert the selected image to byte[]
                    byte[] imageBytes = File.ReadAllBytes(imagePath);

                    // Call the method to save it to the database
                    SaveProfileToDatabase(imageBytes);
                }
            }

            private void SaveProfileToDatabase(byte[] imageBytes)
            {
                string connectionString = "Data Source=styleforge-ms-sql-server.ch0q4qge64ch.eu-north-1.rds.amazonaws.com;Initial Catalog=StyleForgeDB;Persist Security Info=True;User ID=admin;Password=StyleForge#123;Trust Server Certificate=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        string query = "UPDATE Users SET ProfilePicture = @ProfilePicture WHERE Username = @Username";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ProfilePicture", imageBytes);
                        cmd.Parameters.AddWithValue("@Username", UserSession.Username); // Assuming Username is stored in session

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Image uploaded successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
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

*/