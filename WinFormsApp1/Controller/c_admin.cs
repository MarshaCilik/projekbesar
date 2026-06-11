using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Models;

namespace WinFormsApp1.Controller
{
    public class c_admin : c_user
    {
        public List<Users> ReadAllUser(string DataUser) //method read
        {
            return context.ReadUserDataForAdmin(DataUser);
        }

        public string Validation(Users user)
        {
            if (string.IsNullOrWhiteSpace(user.Nama) ||
                string.IsNullOrWhiteSpace(user.NoTelp) ||
                string.IsNullOrWhiteSpace(user.Email) ||
                string.IsNullOrWhiteSpace(user.Alamat) ||
                string.IsNullOrWhiteSpace(user.NamaKecamatan) ||
                string.IsNullOrWhiteSpace(user.NamaDesa) ||
                string.IsNullOrWhiteSpace(user.Username) ||
                string.IsNullOrWhiteSpace(user.Password)
                )
            {
                return "data kosong";
            }
            return null;
        }

        public string Update(Users user)
        {
            string validation = Validation(user);

            if (validation == null)
            {
                return validation;
            }

            context.Update(user);

            return "data terupdate";
        }
    }
}
