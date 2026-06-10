using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class usersDataLogin
    {
        public string username { get; set; }
        public string password { get; set; }

        public usersDataLogin(string username, string password)
        {
            this.password = password;
            this.username = username;
        }
    }
}
