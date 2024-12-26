﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public partial class Form3 : Form
    {
        private string connectionString = "Data Source=styleforge-ms-sql-server.ch0q4qge64ch.eu-north-1.rds.amazonaws.com;Initial Catalog=StyleForgeDB;Persist Security Info=True;User ID=admin;Password=StyleForge#123;Trust Server Certificate=True";
        public string destinationPath = GlobalSettings.DestinationPath;
        public string imageUrl;
        public Form3()
        {
            InitializeComponent();
            HideNav();
            showLastLogin();
            LoadImageFromDatabase();
            //LoadImageFromPath(destinationPath);
            LoadProfileFromDatabase();
            HideMeasurements();
        }

        private void HideMeasurements() => panel_mhidden.Visible = false;
        private void ShowMeasurements() => panel_mhidden.Visible = panel_mhidden.Visible == false ? true : false;

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

        /*private void LoadImageFromPath(string imagePath)
        {
            try
            {
                // Check if the image path is valid
                if (!string.IsNullOrEmpty(destinationPath) && File.Exists(destinationPath))
                {
                    // Load the image from the specified path
                    Image image = Image.FromFile(destinationPath);

                    // Set the image to the PictureBox
                    image = CorrectImageOrientation(image);
                    pictureBox4.Image = image;

                    // Optionally, you can adjust the PictureBox size mode if needed
                    pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage; // or other modes like AutoSize, CenterImage, etc.
                }
                else
                {
                    MessageBox.Show("The specified image path is invalid or the file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur while loading the image
                MessageBox.Show($"An error occurred while loading the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        private void LoadImageFromDatabase()
        {
            string connectionString = "Data Source=styleforge-ms-sql-server.ch0q4qge64ch.eu-north-1.rds.amazonaws.com;Initial Catalog=StyleForgeDB;Persist Security Info=True;User ID=admin;Password=StyleForge#123;Trust Server Certificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT FullBodyBin FROM Users WHERE Username = @Username";
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
            byte[] imageBytes = ExecuteDatabaseQuery("SELECT ProfilePicture FROM Users WHERE Username = @Username");

            if (imageBytes != null)
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Image profileimg = Image.FromStream(ms);
                    profileimg = CorrectImageOrientation(profileimg);
                    profile.Image = profileimg;
                }
            }
            else
            {
                MessageBox.Show("No profile picture found.");
            }
        }


        private byte[] ExecuteDatabaseQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", UserSession.Username);

                    return cmd.ExecuteScalar() as byte[];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return null;
                }
            }
        }
        private string LoadImageUrlFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 ImageUrl FROM UserImages WHERE UserID = @UserID ORDER BY KeyID DESC", conn);
                    cmd.Parameters.AddWithValue("@UserID", UserSession.UserID);

                    imageUrl = cmd.ExecuteScalar() as string;

                    if (!string.IsNullOrEmpty(imageUrl))
                    {
                        // Load and display the image from the URL
                        //DisplayImageFromUrl(imageUrl);
                        //MessageBox.Show(imageUrl);
                    }
                    else
                    {
                        MessageBox.Show("No image URL found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return imageUrl;
        }



        public string jsonresult;

        private async void CallMeasurementEngineApi()
        {
            try
            {
                // Fetch the image URL from your database
                string fetchedImageUrl = LoadImageUrlFromDatabase();

                string apikey = "fw_3Zm3kcX4SQ3d5GKexgtRdrvW";

                // Prepare the JSON payload
                var payload = new
                {
                    image_url = fetchedImageUrl,
                    api_key = apikey
                };

                string jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

                // Send the request to the API
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://styleforge-measurement-engine-api-v1-168486608630.asia-south1.run.app/measurement-engine-api", content);
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    jsonresult = jsonResponse;

                    Debug.WriteLine(jsonresult);

                    // Parse the JSON response dynamically
                    var jsonObject = JObject.Parse(jsonResponse);

                    if (jsonObject["status"]?.ToString() == "success")
                    {
                        var data = jsonObject["data"];

                        if (data != null)
                        {
                            // Store values in UserSession
                            UserSession.SubjectHeight = data["subject-height"]?.ToString();
                            UserSession.SubjectShoulder = data["subject-shoulder"]?.ToString();
                            UserSession.SubjectChest = data["subject-chest"]?.ToString();
                            UserSession.SubjectWaist = data["subject-waist"]?.ToString();
                            UserSession.SubjectHip = data["subject-hip"]?.ToString();
                            UserSession.SubjectArm = data["subject-arm"]?.ToString();
                            UserSession.WaistToHipRatio = data["waist-to-hip-ratio"]?.ToString();

                            // Populate the text boxes with the values
                            label_height.Text = UserSession.SubjectHeight;
                            label_shoulder.Text = UserSession.SubjectShoulder;
                            label_chest.Text = UserSession.SubjectChest;
                            label_waist.Text = UserSession.SubjectWaist;
                            label_hip.Text = UserSession.SubjectHip;
                            label_arm.Text = UserSession.SubjectArm;
                            label_ratio.Text = UserSession.WaistToHipRatio;

                            // Save measurements to the database with override logic
                            using (SqlConnection conn = new SqlConnection(connectionString))
                            {
                                conn.Open();

                                // Check if the user already has a record in the table
                                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM UserMeasurements WHERE UserID = @UserID", conn);
                                checkCmd.Parameters.AddWithValue("@UserID", UserSession.UserID);

                                int recordCount = (int)checkCmd.ExecuteScalar();

                                if (recordCount > 0)
                                {
                                    // Update existing record
                                    SqlCommand updateCmd = new SqlCommand(@"
                                    UPDATE UserMeasurements
                                    SET 
                                        Height = @Height,
                                        Shoulder = @Shoulder,
                                        Chest = @Chest,
                                        Waist = @Waist,
                                        Hip = @Hip,
                                        Arm = @Arm,
                                        WaistToHipRatio = @WaistToHipRatio,
                                        MeasurementDate = GETDATE()
                                    WHERE UserID = @UserID", conn);

                                    updateCmd.Parameters.AddWithValue("@UserID", UserSession.UserID);
                                    updateCmd.Parameters.AddWithValue("@Height", UserSession.SubjectHeight);
                                    updateCmd.Parameters.AddWithValue("@Shoulder", UserSession.SubjectShoulder);
                                    updateCmd.Parameters.AddWithValue("@Chest", UserSession.SubjectChest);
                                    updateCmd.Parameters.AddWithValue("@Waist", UserSession.SubjectWaist);
                                    updateCmd.Parameters.AddWithValue("@Hip", UserSession.SubjectHip);
                                    updateCmd.Parameters.AddWithValue("@Arm", UserSession.SubjectArm);
                                    updateCmd.Parameters.AddWithValue("@WaistToHipRatio", UserSession.WaistToHipRatio);

                                    updateCmd.ExecuteNonQuery();
                                }
                                else
                                {
                                    // Insert new record
                                    SqlCommand insertCmd = new SqlCommand(@"
                                    INSERT INTO UserMeasurements (UserID, Height, Shoulder, Chest, Waist, Hip, Arm, WaistToHipRatio)
                                    VALUES (@UserID, @Height, @Shoulder, @Chest, @Waist, @Hip, @Arm, @WaistToHipRatio)", conn);

                                    insertCmd.Parameters.AddWithValue("@UserID", UserSession.UserID);
                                    insertCmd.Parameters.AddWithValue("@Height", UserSession.SubjectHeight);
                                    insertCmd.Parameters.AddWithValue("@Shoulder", UserSession.SubjectShoulder);
                                    insertCmd.Parameters.AddWithValue("@Chest", UserSession.SubjectChest);
                                    insertCmd.Parameters.AddWithValue("@Waist", UserSession.SubjectWaist);
                                    insertCmd.Parameters.AddWithValue("@Hip", UserSession.SubjectHip);
                                    insertCmd.Parameters.AddWithValue("@Arm", UserSession.SubjectArm);
                                    insertCmd.Parameters.AddWithValue("@WaistToHipRatio", UserSession.WaistToHipRatio);

                                    insertCmd.ExecuteNonQuery();
                                }
                            }

                            MessageBox.Show("Measurements extracted and saved! See Dashboard for results.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ShowMeasurements();
                        }
                        else
                        {
                            MessageBox.Show("No measurement data found in the response.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to extract measurements. Please check the response or API key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calling API: " + ex.Message);
            }
        }

        private void btnFetchMeasurements_Click(object sender, EventArgs e)
        {

            CallMeasurementEngineApi();


        }

        private void label_showm_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // SQL query to fetch user measurements based on UserID
                    SqlCommand cmd = new SqlCommand(@"
                SELECT Height, Shoulder, Chest, Waist, Hip, Arm, WaistToHipRatio
                FROM UserMeasurements
                WHERE UserID = @UserID", conn);

                    // Add parameter for UserID
                    cmd.Parameters.AddWithValue("@UserID", UserSession.UserID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate the textboxes with the values from the database
                            label_height.Text = reader["Height"].ToString();
                            label_shoulder.Text = reader["Shoulder"].ToString();
                            label_chest.Text = reader["Chest"].ToString();
                            label_waist.Text = reader["Waist"].ToString();
                            label_hip.Text = reader["Hip"].ToString();
                            label_arm.Text = reader["Arm"].ToString();
                            label_ratio.Text = reader["WaistToHipRatio"].ToString();

                            //MessageBox.Show("Measurements successfully loaded from the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ShowMeasurements();
                        }
                        else
                        {
                            MessageBox.Show("No measurements found for the current user.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


    }
}
