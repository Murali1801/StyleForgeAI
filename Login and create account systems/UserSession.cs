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
        }
    }
}
