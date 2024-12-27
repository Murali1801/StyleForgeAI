using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
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
        //public string jsonresult { get; set; }
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



        /*//public string jsonresult;

        //private async void CallMeasurementEngineApi()
        //{
        //    try
        //    {
        //        // Fetch the image URL from your database
        //        string fetchedImageUrl = LoadImageUrlFromDatabase();

        //        string apikey = "fw_3Zm3kcX4SQ3d5GKexgtRdrvW";

        //        // Prepare the JSON payload
        //        var payload = new
        //        {
        //            image_url = fetchedImageUrl,
        //            api_key = apikey
        //        };

        //        string jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

        //        // Send the request to the API
        //        using (HttpClient client = new HttpClient())
        //        {
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        //            HttpResponseMessage response = await client.PostAsync("https://styleforge-measurement-engine-api-v1-168486608630.asia-south1.run.app/measurement-engine-api", content);
        //            string jsonResponse = await response.Content.ReadAsStringAsync();
        //            jsonresult = jsonResponse;

        //            Debug.WriteLine(jsonresult);

        //            // Parse the JSON response dynamically
        //            var jsonObject = JObject.Parse(jsonResponse);

        //            if (jsonObject["status"]?.ToString() == "success")
        //            {
        //                var data = jsonObject["data"];

        //                if (data != null)
        //                {
        //                    // Store values in UserSession
        //                    UserSession.SubjectHeight = data["subject-height"]?.ToString();
        //                    UserSession.SubjectShoulder = data["subject-shoulder"]?.ToString();
        //                    UserSession.SubjectChest = data["subject-chest"]?.ToString();
        //                    UserSession.SubjectWaist = data["subject-waist"]?.ToString();
        //                    UserSession.SubjectHip = data["subject-hip"]?.ToString();
        //                    UserSession.SubjectArm = data["subject-arm"]?.ToString();
        //                    UserSession.WaistToHipRatio = data["waist-to-hip-ratio"]?.ToString();

        //                    // Populate the text boxes with the values
        //                    label_height.Text = UserSession.SubjectHeight;
        //                    label_shoulder.Text = UserSession.SubjectShoulder;
        //                    label_chest.Text = UserSession.SubjectChest;
        //                    label_waist.Text = UserSession.SubjectWaist;
        //                    label_hip.Text = UserSession.SubjectHip;
        //                    label_arm.Text = UserSession.SubjectArm;
        //                    label_ratio.Text = UserSession.WaistToHipRatio;

        //                    // Save measurements to the database with override logic
        //                    using (SqlConnection conn = new SqlConnection(connectionString))
        //                    {
        //                        conn.Open();

        //                        // Check if the user already has a record in the table
        //                        SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM UserMeasurements WHERE UserID = @UserID", conn);
        //                        checkCmd.Parameters.AddWithValue("@UserID", UserSession.UserID);

        //                        int recordCount = (int)checkCmd.ExecuteScalar();

        //                        if (recordCount > 0)
        //                        {
        //                            // Update existing record
        //                            SqlCommand updateCmd = new SqlCommand(@"
        //                            UPDATE UserMeasurements
        //                            SET 
        //                                Height = @Height,
        //                                Shoulder = @Shoulder,
        //                                Chest = @Chest,
        //                                Waist = @Waist,
        //                                Hip = @Hip,
        //                                Arm = @Arm,
        //                                WaistToHipRatio = @WaistToHipRatio,
        //                                MeasurementDate = GETDATE()
        //                            WHERE UserID = @UserID", conn);

        //                            updateCmd.Parameters.AddWithValue("@UserID", UserSession.UserID);
        //                            updateCmd.Parameters.AddWithValue("@Height", UserSession.SubjectHeight);
        //                            updateCmd.Parameters.AddWithValue("@Shoulder", UserSession.SubjectShoulder);
        //                            updateCmd.Parameters.AddWithValue("@Chest", UserSession.SubjectChest);
        //                            updateCmd.Parameters.AddWithValue("@Waist", UserSession.SubjectWaist);
        //                            updateCmd.Parameters.AddWithValue("@Hip", UserSession.SubjectHip);
        //                            updateCmd.Parameters.AddWithValue("@Arm", UserSession.SubjectArm);
        //                            updateCmd.Parameters.AddWithValue("@WaistToHipRatio", UserSession.WaistToHipRatio);

        //                            updateCmd.ExecuteNonQuery();
        //                        }
        //                        else
        //                        {
        //                            // Insert new record
        //                            SqlCommand insertCmd = new SqlCommand(@"
        //                            INSERT INTO UserMeasurements (UserID, Height, Shoulder, Chest, Waist, Hip, Arm, WaistToHipRatio)
        //                            VALUES (@UserID, @Height, @Shoulder, @Chest, @Waist, @Hip, @Arm, @WaistToHipRatio)", conn);

        //                            insertCmd.Parameters.AddWithValue("@UserID", UserSession.UserID);
        //                            insertCmd.Parameters.AddWithValue("@Height", UserSession.SubjectHeight);
        //                            insertCmd.Parameters.AddWithValue("@Shoulder", UserSession.SubjectShoulder);
        //                            insertCmd.Parameters.AddWithValue("@Chest", UserSession.SubjectChest);
        //                            insertCmd.Parameters.AddWithValue("@Waist", UserSession.SubjectWaist);
        //                            insertCmd.Parameters.AddWithValue("@Hip", UserSession.SubjectHip);
        //                            insertCmd.Parameters.AddWithValue("@Arm", UserSession.SubjectArm);
        //                            insertCmd.Parameters.AddWithValue("@WaistToHipRatio", UserSession.WaistToHipRatio);

        //                            insertCmd.ExecuteNonQuery();
        //                        }
        //                    }

        //                    MessageBox.Show("Measurements extracted and saved! See Dashboard for results.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    ShowMeasurements();
        //                }
        //                else
        //                {
        //                    MessageBox.Show("No measurement data found in the response.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Failed to extract measurements. Please check the response or API key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error calling API: " + ex.Message);
        //    }
        //}*/

       

        private void label_showm_Click(object sender, EventArgs e)
        {
            FetchMeasurements();
        }
        public string formattedOutput;
        private void FetchMeasurements()
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
                            // Extract values from the database
                            double height = Convert.ToDouble(reader["Height"]);
                            double shoulder = Convert.ToDouble(reader["Shoulder"]);
                            double chest = Convert.ToDouble(reader["Chest"]);
                            double waist = Convert.ToDouble(reader["Waist"]);
                            double hip = Convert.ToDouble(reader["Hip"]);
                            double arm = Convert.ToDouble(reader["Arm"]);
                            double waistToHipRatio = Convert.ToDouble(reader["WaistToHipRatio"]);

                            // Format the output string
                            formattedOutput = $"subject-height: {height}, subject-shoulder: {shoulder}, subject-chest: {chest}, subject-waist: {waist}, subject-hip: {hip}, subject-arm: {arm}, waist-to-hip-ratio: {waistToHipRatio}";

                            // Output the formatted string
                            MessageBox.Show(formattedOutput, "Measurements", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Optionally, you can still populate the labels if needed
                            label_height.Text = height.ToString();
                            label_shoulder.Text = shoulder.ToString();
                            label_chest.Text = chest.ToString();
                            label_waist.Text = waist.ToString();
                            label_hip.Text = hip.ToString();
                            label_arm.Text = arm.ToString();
                            label_ratio.Text = waistToHipRatio.ToString();

                            // MessageBox.Show("Measurements successfully loaded from the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button9_Click(object sender, EventArgs e)
        {
            CallRSEQApi();
        }

        //string jsonresult = GlobalSettings.JSONresult;
        

        /*public static string ParseJsonToSingleString(string jsonString)
        {
            JObject json = JObject.Parse(jsonString);
            JObject data = (JObject)json["data"];

            string result = string.Join(", ", data.Properties().Select(prop => $"{prop.Name}: {prop.Value}"));
            return result;
        }*/
        private async void CallRSEQApi()
        {
            try
            {
                //int curruserid = UserSession.UserID;

                //string fetchedImageUrl = LoadImageUrlFromDatabase();

                //Debug.WriteLine(formattedOutput);

                string apikey = "fw_3Zm3kcX4SQ3d5GKexgtRdrvW";
                string jsonrseq = "| **Height Range** | **Tops** | **Bottoms** | **Shoes** | **Accessories** | **Color Sense** | |------------------|------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------| | **160–167 cm** | - Fitted t-shirts or polo shirts<br>- Vertical stripes or small patterns<br>- Waist-length jackets | - Slim-fit jeans or chinos<br>- Cropped or ankle-length trousers<br>- Darker colors for elongation | - Low-profile sneakers<br>- Chelsea boots with slight heels<br>- Minimalist designs | - Slim belts<br>- Medium-sized bags<br>- Sleek caps or beanies | - Monochrome outfits<br>- Contrast light tops with dark bottoms for balance | | **167–174 cm** | - Slim-fit or tailored shirts<br>- V-neck sweaters<br>- Layered outfits with proportions | - Tapered or straight-leg pants<br>- Mid-rise trousers<br>- Neutral or solid colors | - Low or mid-profile sneakers<br>- Desert boots or loafers | - Leather belts<br>- Medium-to-small backpacks<br>- Simple watches or bracelets | - Earth tones or muted palettes<br>- Incorporate subtle patterns for variety | | **174–181 cm** | - Casual t-shirts and shirts with added layering<br>- Neutral colors or subtle patterns<br>- Slim jackets | - Straight-leg or slightly relaxed pants<br>- Dark or earthy tones | - Sneakers, loafers, or boots<br>- Avoid overly flat or exaggerated platforms | - Medium-width belts<br>- Messenger bags or crossbody bags<br>- Simple caps | - Neutral tones with bold accent pieces<br>- Dark tops for a slimming effect | | **181–188 cm** | - Slim-fit button-ups<br>- Long-sleeve t-shirts<br>- Tailored blazers for casual events | - Slightly relaxed fit pants<br>- Avoid overly slim styles for balance | - Casual leather sneakers<br>- Brogue boots for added style | - Larger backpacks or shoulder bags<br>- Statement watches | - Classic tones like navy, gray, or white<br>- Use vertical patterns to emphasize height | | **188–195 cm** | - Tailored shirts or turtlenecks<br>- Longline t-shirts or sweaters<br>- Coats ending mid-thigh for balance | - Straight-cut pants<br>- Avoid cropped pants unless paired with boots | - High-top sneakers or boots<br>- Classic leather shoes | - Structured bags<br>- Wider belts for balance<br>- Subtle scarves or accessories | - Deep tones like burgundy, forest green, or charcoal<br>- Avoid overly busy patterns for balance |";
                //string jsonbody = "{ "subject-height":177.5,"subject-shoulder":46.5,"subject-chest":89.5,"subject-waist":76,"subject-hip":94.5,"subject-arm":57,"waist-to-hip-ratio":0.805}";
                FetchMeasurements();
                Debug.WriteLine(formattedOutput);

                // Prepare the JSON payload correctly
                var payload = new
                {
                    // Ensure this key matches what the API expects (image_url should be replaced by url if needed)
                    api_key = apikey,
                    recommendation_table = jsonrseq,
                    body_analysis_table = formattedOutput,
                };

                string jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

                // Send the request to the API
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://styleforge-rseq-api-v2-168486608630.asia-south1.run.app/rseq-api-v2\r\n", content);
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    //jsonresult = jsonResponse;
                    //GlobalSettings.JSONresult = jsonResponse;
                    Debug.WriteLine(jsonResponse);
                    //MessageBox.Show(jsonResponse);

                    //SQl Query
                    /*using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE Users SET UserMeasurments = @UserMeasurments WHERE UserID = @UserID", conn);
                        cmd.Parameters.AddWithValue("@UserID", UserSession.UserID);
                        cmd.Parameters.AddWithValue("@UserMeasurments", jsonresult);

                        cmd.ExecuteNonQuery();
                    }*/

                    MessageBox.Show(jsonResponse, "RSEQ Extracted! See Dashboard for Results", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calling API: " + ex.Message);
            }
        }
    }
}
