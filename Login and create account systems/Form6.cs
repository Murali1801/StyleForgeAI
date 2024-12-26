
using System;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Net.Http.Headers;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Drawing.Text;

namespace Login_and_create_account_systems
{
    public partial class Form6 : Form
    {
        private string connectionString = "Data Source=styleforge-ms-sql-server.ch0q4qge64ch.eu-north-1.rds.amazonaws.com;Initial Catalog=StyleForgeDB;Persist Security Info=True;User ID=admin;Password=StyleForge#123;Trust Server Certificate=True";
        private string imgHippoApiUrl = "https://api.imghippo.com/v1/upload"; // Replace with actual ImgHippo API URL
        private string imgHippoApiKey = "191d6566b275d0609a6c3b38e36f8bc3";
        public string imagePath;
        public string destinationPath;
        public string newimagePath;
        public string imageUrl;
        public string apiKey = "191d6566b275d0609a6c3b38e36f8bc3";

        public string GetApiKey()
        {
            // Try to get the API key from environment variables
            //apiKey = Environment.GetEnvironmentVariable("IMGHIPPO_API_KEY");
            if (!string.IsNullOrEmpty(apiKey))
            {
                return apiKey;
            }

            // If not found in environment variables, try app config
            apiKey = GetApiKeyFromAppConfig();
            if (!string.IsNullOrEmpty(apiKey))
            {
                return apiKey;
            }

            MessageBox.Show("API key is not available. Please set it in the environment variables or app config.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "191d6566b275d0609a6c3b38e36f8bc3";
        }

        public string GetApiKeyFromAppConfig()
        {
            apiKey = ConfigurationManager.AppSettings["IMGHIPPO_API_KEY"];
            return apiKey;
        }

        public Form6()
        {
            InitializeComponent();
            HideNav();
            LoadImageFromDatabase();
            LoadProfileFromDatabase();
        }

        private void HideNav() => panel_hidden.Visible = true;

        private void ToggleNavigationPanel()
        {
            if (panel_hidden.Visible)
            {
                panel_hidden.Visible = false;
                this.Size = new Size(1240, 800);
            }
            else
            {
                panel_hidden.Visible = true;
                this.Size = new Size(1400, 800);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e) => ToggleNavigationPanel();

        private void pictureBox2_Click(object sender, EventArgs e) => NavigateToForm3();

        private void button2_Click(object sender, EventArgs e) => NavigateToForm3();

        private void NavigateToForm3()
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e) => NavigateToForm7();

        private void pictureBox7_Click(object sender, EventArgs e) => NavigateToForm7();

        private void NavigateToForm7()
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e) => NavigateToForm8();

        private void button4_Click(object sender, EventArgs e) => NavigateToForm8();

        private void NavigateToForm8()
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void exit_Click(object sender, EventArgs e) => LogOut();

        private void button5_Click(object sender, EventArgs e) => LogOut();

        private void LogOut()
        {
            UserSession.ClearSession();
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        

        private async void btnBrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                // Get the current directory of the application (Project directory)
                string projectDirectory = Application.StartupPath;

                // Define the destination path within the project directory
                destinationPath = Path.Combine(projectDirectory, Path.GetFileName(imagePath));

                // Ensure the destination directory exists (in case there's a folder structure)
                string directory = Path.GetDirectoryName(destinationPath);
                Directory.CreateDirectory(directory);

                // Copy the selected image to the project directory
                File.Copy(imagePath, destinationPath, true);


                // Save the new image path to the Users table (or your database)
                SaveImagePathToDatabase(destinationPath);
                SaveImageToDatabase(imageBytes);

                GlobalSettings.DestinationPath = destinationPath;

                // Call ImgHippo API to upload and get the URL
                string imageUrl = await UploadImageToImgHippoAsync(destinationPath, apiKey);

                if (imageUrl != null)
                {
                    // Save the image URL to the UserImages table
                    SaveImageUrlToUserImages(imageUrl);
                    MessageBox.Show("Image Uploaded to Cloud Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Display the image URL and API JSON response
                    //MessageBox.Show($"Image URL: {imageUrl}\nImage Path: {destinationPath}", "Image Upload Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadImageFromDatabase();
                }
                else
                {
                    MessageBox.Show("Failed to upload image to ImgHippo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
        }


        private void SaveImagePathToDatabase(string imagePath)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE Users SET FullBodyPic = @FullBodyPic WHERE UserID = @UserID", conn);
                    cmd.Parameters.AddWithValue("@UserID", UserSession.UserID);
                    cmd.Parameters.AddWithValue("@FullBodyPic", destinationPath);

                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Image path uploaded successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
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


        private async void btnShowPic_Click(object sender, EventArgs e)
        {
            //GetApiKey();
            //LoadImageFromDatabase();
            //await UploadImageToImgHippoAsync(imagePath,apiKey);
            //LoadImageFromPath(destinationPath);
            //SaveImageUrlToUserImages(imageUrl);
            //LoadImageUrlFromDatabase();
            //CallApiAndDisplayOutput();
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
                LoadProfileFromDatabase();
            }
        }

        // New method to upload image to ImgHippo and save URL to the UserImages table


        /*private async Task TestNetworkConnection()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://www.google.com");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Network connection is working.");
                    }
                    else
                    {
                        MessageBox.Show("Network connection failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error testing network connection: {ex.Message}");
                }
            }
        }

        /*private async Task<string> UploadToImgHippoAsync(byte[] imageBytes)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                var imageContent = new ByteArrayContent(imageBytes);
                content.Add(imageContent, "file", "uploaded_image");

                // Include the API key in the request headers
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", imgHippoApiKey);

                try
                {
                    HttpResponseMessage response = await client.PostAsync(imgHippoApiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Assume that the response contains a JSON with the image URL
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        // Example: {"url": "https://img.example.com/image.jpg"}
                        var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                        return responseData.url;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while uploading image: " + ex.Message);
                    return null;
                }
            }
        }

        private async Task<string> UploadToImgHippoAsync(byte[] imageBytes)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                var imageContent = new ByteArrayContent(imageBytes);
                imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                content.Add(imageContent, "file", "uploaded_image.jpg");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", imgHippoApiKey);

                try
                {
                    HttpResponseMessage response = await client.PostAsync(imgHippoApiUrl, content);
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Log response for troubleshooting
                    LogResponse(response, jsonResponse);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                        return responseData.url;
                    }
                    else
                    {
                        MessageBox.Show($"Error: {response.StatusCode} - {jsonResponse}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while uploading image: {ex.Message}");
                    return null;
                }
            }
        }

        private void LogResponse(HttpResponseMessage response, string jsonResponse)
        {
            string logMessage = $"Status Code: {response.StatusCode}\nResponse: {jsonResponse}";
            File.AppendAllText("api_log.txt", logMessage);
        }

        private async void UploadImageToImgHippoAndSaveUrlToUserImages(byte[] imageBytes)
        {
            try
            {
                // Upload the image to ImgHippo API and get the URL
                string imageUrl = await UploadToImgHippoAsync(imageBytes);
                await TestNetworkConnection();
                MessageBox.Show(imageUrl);

                if (imageUrl != null)
                {
                    // Save the image URL in the UserImages table (without modifying existing methods)
                    SaveImageUrlToUserImages(imageUrl);
                }
                else
                {
                    MessageBox.Show("Failed to upload image.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }*/
        private static async Task<string> UploadImageToImgHippoAsync(string imagePath, string apiKey)
        {
            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new StringContent(apiKey), "api_key");
                    content.Add(new StringContent("My Image"), "title");

                    using (var fileStream = File.OpenRead(imagePath))
                    {
                        content.Add(new StreamContent(fileStream), "file", Path.GetFileName(imagePath));

                        var response = await client.PostAsync("https://api.imghippo.com/v1/upload", content);
                        response.EnsureSuccessStatusCode();

                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var json = JObject.Parse(jsonResponse);

                        return json["data"]["url"].ToString(); // Adjust according to actual response format
                    }
                }
            }
        }



        /*private void SaveImageUrlToUserImages(string imageUrl)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO UserImages (UserID, ImageUrl) VALUES (@UserID, @ImageUrl)", conn);
                    cmd.Parameters.AddWithValue("@UserID", UserSession.UserID);
                    cmd.Parameters.AddWithValue("@ImageUrl", imageUrl);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Image URL uploaded successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }*/


        private void SaveImageUrlToUserImages(string imageUrl)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO UserImages (UserID, ImageUrl) VALUES (@UserID, @ImageUrl)", conn);
                    cmd.Parameters.AddWithValue("@UserID", UserSession.UserID);
                    cmd.Parameters.AddWithValue("@ImageUrl", imageUrl);

                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Image URL uploaded successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadImageUrlFromDatabase()
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
            //return imageUrl;
        }

        /*private string GetImageUrlFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ImageUrl FROM UserImages WHERE UserID = @UserID", conn);
                    cmd.Parameters.AddWithValue("@UserID", UserSession.UserID);

                    return cmd.ExecuteScalar() as string;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving image URL: " + ex.Message);
                    return null;
                }
            }
        }*/

        /*private async Task<string> UploadImageToImgHippoAsync(string imagePath, string apiKey)
        {
            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new StringContent(apiKey), "api_key");
                    content.Add(new StringContent("My Image"), "title");

                    using (var fileStream = File.OpenRead(imagePath))
                    {
                        content.Add(new StreamContent(fileStream), "file", Path.GetFileName(imagePath));

                        var response = await client.PostAsync("https://api.imghippo.com/v1/upload", content);
                        response.EnsureSuccessStatusCode();

                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var json = JObject.Parse(jsonResponse);

                        return json["data"]["url"].ToString(); // Adjust according to actual response format
                    }
                }
            }
        }*/


        public string jsonresult;
        private async void CallApiAndDisplayOutput()
        {
            try
            {
                // Retrieve the image URL from the database
                LoadImageUrlFromDatabase();
                
                string apikey = "fw_3Zm3kcX4SQ3d5GKexgtRdrvW";

                if (string.IsNullOrEmpty(imageUrl))
                {
                    MessageBox.Show("No image URL found for this user.");
                    return;
                }

                // Prepare the JSON payload correctly
                var payload = new
                {
                    image_url = imageUrl, // Ensure this key matches what the API expects (image_url should be replaced by url if needed)
                    api_key = apikey
                };

                string jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

                // Send the request to the API
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://styleforge-measurement-engine-api-v1-168486608630.asia-south1.run.app/measurement-engine-api\r\n", content);
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    jsonresult = jsonResponse;
                    //GlobalSettings.JSONresult = jsonResponse;
                    Debug.WriteLine(jsonresult);
                    // Display the output from the API in a messagebox in JSON format
                    //MessageBox.Show(jsonResponse, "API Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calling API: " + ex.Message);
            }
        }



        /*private async void DisplayImageFromUrl(string imageUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        Image image = Image.FromStream(ms);
                        pictureBox4.Image = image; // Replace pictureBox4 with your PictureBox control
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image from URL: " + ex.Message);
            }
        }*/


        private void SaveImageToDatabase(byte[] imageBytes)
        {
            string connectionString = "Data Source=styleforge-ms-sql-server.ch0q4qge64ch.eu-north-1.rds.amazonaws.com;Initial Catalog=StyleForgeDB;Persist Security Info=True;User ID=admin;Password=StyleForge#123;Trust Server Certificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "UPDATE Users SET FullBodyBin = @FullBodyBin WHERE Username = @Username";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FullBodyBin", imageBytes);
                    cmd.Parameters.AddWithValue("@Username", UserSession.Username); // Assuming Username is stored in session

                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Image uploaded successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void SaveProfileToDatabase(byte[] imageBytes)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE Users SET ProfilePicture = @ProfilePicture WHERE Username = @Username", conn);
                    cmd.Parameters.AddWithValue("@Username", UserSession.Username);
                    cmd.Parameters.AddWithValue("@ProfilePicture", imageBytes);

                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Profile picture uploaded successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
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

        private void ExecuteDatabaseCommand(string query, byte[] imageBytes)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", UserSession.Username);
                    cmd.Parameters.AddWithValue("@FullBodyPic", imageBytes);

                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Image uploaded successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
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

        private void LoadImageFromDatabase()
        {
            byte[] imageBytes = ExecuteDatabaseQuery("SELECT FullBodyBin FROM Users WHERE Username = @Username");

            if (imageBytes != null)
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Image img = Image.FromStream(ms);
                    img = CorrectImageOrientation(img);
                    pictureBox4.Image = img;
                }
            }
            else
            {
                MessageBox.Show("No profile picture found or data is NULL.");
            }
        }

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

                img.RemovePropertyItem(0x0112);
            }

            return img;
        }


        private void UploadProfileImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                SaveProfileToDatabase(imageBytes);
            }
        }
    }
}