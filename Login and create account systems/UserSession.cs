using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_and_create_account_systems
{
    internal class UserSession
    {
        public static int UserID { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string Email { get; set; }
        public static DateTime LastLogin { get; set; }
        public static DateTime CreatedAt { get; set; }

        public static string ImageBase64 { get; set; }

        public static string SubjectHeight { get; set; }
        public static string SubjectShoulder { get; set; }
        public static string SubjectChest { get; set; }
        public static string SubjectWaist { get; set; }
        public static string SubjectHip { get; set; }
        public static string SubjectArm { get; set; }
        public static string WaistToHipRatio { get; set; }

        public static string jsonmeasurements { get; set; }

        public static string topWearQuery { get; set; }

        public static string bottomWearQuery { get; set; }

        public static string shoesQuery { get; set; }

        public static string colorRecommendationsQuery { get; set; }

        public static string crawlerApiResponse { get; set; }

        public static string pythonPath = @"C:\Users\mural\AppData\Local\Programs\Python\Python310\python.exe";  // Path to Python
        public static string scriptPath = @"D:\img_down\imgdown.py";
        public static string outputImgPath = @"D:\img_down\outputs";


        public static void ClearSession()
        {
            UserID = 0;
            Username = null;
            Password = null;
            Email = null;
            LastLogin = DateTime.MinValue;
            CreatedAt = DateTime.MinValue;
            ImageBase64 = null;
            SubjectHeight = null;
            SubjectShoulder = null;
            SubjectChest = null;
            SubjectWaist = null;
            SubjectHip = null;
            SubjectArm = null;
            WaistToHipRatio = null;
            topWearQuery = null;
            bottomWearQuery = null;
            shoesQuery = null;
            colorRecommendationsQuery = null;
            crawlerApiResponse = null;

            try
            {
                if (Directory.Exists(outputImgPath))
                {
                    foreach (string file in Directory.GetFiles(outputImgPath))
                    {
                        File.Delete(file); // Delete each file
                    }
                    Console.WriteLine("All images cleared successfully.");
                }
                else
                {
                    Console.WriteLine("Image directory does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing images: {ex.Message}");
            }
        }
    }
}
