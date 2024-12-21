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

        public static void ClearSession()
        {
            UserID = 0;
            Username = null;
            Password = null;
            Email = null;
            LastLogin = DateTime.MinValue;
            CreatedAt = DateTime.MinValue;
        }
    }
}
